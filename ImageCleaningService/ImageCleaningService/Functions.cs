using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace ImageCleaningService
{
    internal class Functions
    {
        public static Complex[,] CreateSignal(int image_size_X, int image_size_Y, List<GaussParamsViewModel> List_GPs)
        {
            Complex[,] signal = new Complex[image_size_X, image_size_Y];

            for (int i = 0; i < image_size_X; i++)
            {
                for (int j = 0; j < image_size_Y; j++)
                {
                    for (int k = 0; k < List_GPs.Count; k++)
                    {
                        signal[i, j] += List_GPs[k].GaussFunction(i, j);
                    }
                }
            }

            return signal;
        }

        public static void AddNoiseToSignal(Complex[,] signal, double SNR, out Complex[,] noisySignal)
        {
            Random rand = new Random();
            int image_size_X = signal.GetLength(0);
            int image_size_Y = signal.GetLength(1);

            noisySignal = new Complex[image_size_X, image_size_Y];

            double energySignal = 0;
            double energyNoise = 0;

            for (int i = 0; i < image_size_X; i++)
            {
                for (int j = 0; j < image_size_Y; j++)
                {
                    for (int k = 0; k < 12; k++)
                    {
                        noisySignal[i, j] += (rand.NextDouble() * 2 - 1);
                    }

                    noisySignal[i, j] /= 12;

                    energyNoise += noisySignal[i, j].Real * noisySignal[i, j].Real;
                    energySignal += signal[i, j].Real * signal[i, j].Real;
                }
            }

            double koffN = Math.Sqrt(energySignal / energyNoise / (Math.Pow(10, 0.1 * SNR)));

            for (int i = 0; i < image_size_X; i++)
            {
                for (int j = 0; j < image_size_Y; j++)
                {
                    noisySignal[i, j] = signal[i, j] + koffN * noisySignal[i, j];
                }
            }
        }

        /// <summary>
        /// Приводит стороны изображения к значению 2 в степени.
        /// Необходимо для дальнейшего использования в быстром преобразовании Фурье.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Complex[,] ImageUpdateForFourier(Complex[,] image, bool interpolation = true)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            int new_size_X = 1;
            int new_size_Y = 1;

            while (new_size_X < image.GetLength(0)) 
            {
                new_size_X *= 2;
            }
            while (new_size_Y < image.GetLength(1))
            {
                new_size_Y *= 2;
            }

            Complex[,] updatedImage = new Complex[new_size_X, new_size_Y];

            if (interpolation)
            {
                Func<double, double, double, double> Lerp = (s, e, t) => s + (e - s) * t;
                Func<double, double, double, double, double, double, double> BLerp = (c00, c10, c01, c11, tx, ty) => Lerp(Lerp(c00, c10, tx), Lerp(c01, c11, tx), ty);
                Parallel.For(0, new_size_X, x =>
                {
                    Parallel.For(0, new_size_Y, y =>
                    {
                        double gx = (double)x / new_size_X * (width - 1);
                        double gy = (double)y / new_size_Y * (height - 1);
                        int gxi = (int)gx, gyi = (int)gy;
                        double v = BLerp(image[gxi, gyi].Real, image[gxi + 1, gyi].Real, image[gxi, gyi + 1].Real, image[gxi + 1, gyi + 1].Real, gx - gxi, gy - gyi);
                        updatedImage[x, y] = v;
                    });
                });
            } else
            {
                Parallel.For(0, width, x =>
                {
                    Parallel.For(0, height, y =>
                    {
                        updatedImage[x, y] = image[x,y];
                    });
                });
            }
			return updatedImage;
        }

        /// <summary>
        /// Быстрое преобразование Фурье
        /// </summary>
        /// <param name="data">Комплексный сигнал</param>
        /// <param name="mode">Преобразование: false - прямое, true - обратное</param>
        /// <returns></returns>
        private static Complex[] FFourier(Complex[] data, bool mode)
        {
            int i, j, istep;
            int m, mmax;
            int n = data.Length;
            double r, r1, theta, w_r, w_i, temp_r, temp_i;
            Complex[] result = new Complex[n];
            data.CopyTo(result, 0);

            r = Math.PI * (mode ? (-1) : (1));
            j = 0;
            for (i = 0; i < n; i++)
            {
                if (i < j)
                {
                    temp_r = result[j].Real;
                    temp_i = result[j].Imaginary;
                    result[j] = result[i];
                    result[i] = new Complex(temp_r, temp_i);
                }
                m = n >> 1;
                while (j >= m) { j -= m; m = (m + 1) / 2; }
                j += m;
            }
            mmax = 1;
            while (mmax < n)
            {
                istep = mmax << 1;
                r1 = r / mmax;
                for (m = 0; m < mmax; m++)
                {
                    theta = r1 * m;
                    w_r = Math.Cos(theta);
                    w_i = Math.Sin(theta);
                    for (i = m; i < n; i += istep)
                    {
                        j = i + mmax;
                        temp_r = w_r * result[j].Real - w_i * result[j].Imaginary;
                        temp_i = w_r * result[j].Imaginary + w_i * result[j].Real;
                        result[j] = new Complex(result[i].Real - temp_r, result[i].Imaginary - temp_i);
                        result[i] += new Complex(temp_r, temp_i);
                    }
                }
                mmax = istep;
            }
            if (!mode)
                for (i = 0; i < n; i++)
                {
                    result[i] /= (double)n;
                }

            return result;
        }

        /// <summary>
        /// Возвращает спектр из изображения если mode = false
        /// Возвращает изображение из спектра если mode = true
        /// </summary>
        /// <param name="image">Изображение</param>
        /// <param name="mode">Преобразование: false - прямое, true - обратное</param>
        /// <returns></returns>
        public static Complex[,] FFourier(Complex[,] image, bool mode) 
        {
            int size_x = image.GetLength(0);
            int size_y = image.GetLength(1);
            Complex[,] spectrum = new Complex[size_x, size_y];

            Parallel.For(0, size_x, x => 
            {
                var row = new Complex[size_y];

                for (int y = 0; y < size_y; y++)
                {
                    row[y] = image[x, y];
                }

                row = FFourier(row, mode);

                for (int y = 0; y < size_y; y++)
                {
                    spectrum[x,y] = row[y];
                }
            });
            Parallel.For(0, size_y, y =>
            {
                var collum = new Complex[size_x];

                for (int x = 0; x < size_x; x++)
                {
                    collum[x] = spectrum[x, y];
                }

                collum = FFourier(collum, mode);

                for (int x = 0; x < size_x; x++)
                {
                    spectrum[x, y] = collum[x];
                }
            });
            return spectrum;
        }

        public static Complex[,] ClearSpectrum(Complex[,] spectrum, double saveEnergyPercentage, out int rc)
        {
            int size_x = spectrum.GetLength(0);
            int size_y = spectrum.GetLength(1);

            Complex[,] clearsedSpectrum = new Complex[size_x, size_y];

            double fullEnergy = 0;

            // Считаем энергию спектра
            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    fullEnergy += spectrum[x, y].Magnitude;
                    clearsedSpectrum[x, y] = spectrum[x, y];
                }
            }

            double maxEnergy = fullEnergy * saveEnergyPercentage * 0.01;
            double curEnergy = 0;
            double e1 = 0;
            double e2 = 0;
            double e3 = 0;
            double e4 = 0;
            rc = 0;
            int stoprc;

            // Костыль для прямоугольных изображений
            if (size_x < size_y) { stoprc = size_x; }
            else { stoprc = size_y; }

            while (rc < stoprc && curEnergy < maxEnergy) 
            {
                // Левый верхний угол спектра
                for (int x = 0; x < rc; x++) 
                {
                    e1 += spectrum[x, rc].Magnitude;
                }
                for (int y = 0; y < rc - 1; y++)
                {
                    e1 += spectrum[rc, y].Magnitude;
                }

                // Левый нижний угол спектра
                for (int x = 0; x < rc; x++)
                {
                    e2 += spectrum[x, size_y - 1 - rc].Magnitude;
                }
                for (int y = 0; y < rc - 1; y++)
                {
                    e2 += spectrum[rc, size_y - 1 - y].Magnitude;
                }

                // Правый верхний угол спектра
                for (int x = 0; x < rc; x++)
                {
                    e3 += spectrum[size_x - 1 - x, rc].Magnitude;
                }
                for (int y = 0; y < rc - 1; y++)
                {
                    e3 += spectrum[size_x - 1- rc, y].Magnitude;
                }

                // Правый нижний угол спектра
                for (int x = 0; x < rc; x++)
                {
                    e4 += spectrum[size_x - 1 - x, size_y - 1 - rc].Magnitude;
                }
                for (int y = 0; y < rc - 1; y++)
                {
                    e4 += spectrum[size_x - 1 - rc, size_y - 1 - y].Magnitude;
                }

                curEnergy = e1 + e2 + e3 + e4;
                rc++;
            }
            
            // Зануляем спектр
            for (int x = rc; x < size_x - rc; x++)
            {
                for (int y = 0; y < rc; y++)
                {
                    clearsedSpectrum[x, y] = Complex.Zero;
                }
            }
            for (int x = rc; x < size_x - rc; x++)
            {
                for (int y = size_y - rc; y < size_y; y++)
                {
                    clearsedSpectrum[x, y] = Complex.Zero;
                }
            }
            for (int x = 0; x < size_x; x++)
            {
                for (int y = rc; y < size_y - rc; y++)
                {
                    clearsedSpectrum[x, y] = Complex.Zero;
                }
            }

            return clearsedSpectrum;
        }

        public static void GetEpsilons(Complex[,] mainImage, Complex[,] noisyImage, Complex[,] clearsedImage, out double epsilon1, out double epsilon2) 
        {
            epsilon1 = epsilon2 = 0;
            double energy = 0;

            int size_x = mainImage.GetLength(0);
            int size_y = mainImage.GetLength(1);

            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    epsilon1 += (mainImage[x, y].Real - noisyImage[x, y].Real) * (mainImage[x, y].Real - noisyImage[x, y].Real);
                    epsilon2 += (mainImage[x, y].Real - clearsedImage[x, y].Real) * (mainImage[x, y].Real - clearsedImage[x, y].Real);
                    energy += mainImage[x, y].Real * mainImage[x, y].Real;
                }
            }

            epsilon1 /= energy;
            epsilon2 /= energy;
        }
    }
}
