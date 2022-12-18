using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCleaningService_FlowingBG
{
    internal class Filter
    {
        public enum KernelType { Blur, Gaussian, Sinc }

        public static double[,] GetKernel(KernelType type, int size)
        {
            switch (type) {
                case KernelType.Blur:
                    return GetBlurKernel(size);
                case KernelType.Gaussian:
                    return GetGaussianKernel(size);
                case KernelType.Sinc:
                    return GetSincKernel(size);
                default:
                    throw new NotImplementedException();
            }
        }

        protected static double[,] GetBlurKernel(int size)
        { 
            var kernel = new double[size, size];
            double q = 1.0 / (size * size);
            Parallel.For(0, size, i => Parallel.For(0, size, j => kernel[i, j] = q));
            return kernel;
        }

        protected static double[,] GetGaussianKernel(int size)
        {
            double[,] kernel = new double[size, size];

            double sum = 0;
            int cX, cY, SigmaX, SigmaY;
            cX = cY = SigmaX = SigmaY = size / 2;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    kernel[x, y] = Math.Exp(-((x - cX) * (x - cX) / (2 * SigmaX * SigmaX)) - ((y - cY) * (y - cY) / (2 * SigmaY * SigmaY)));
                    sum += kernel[x, y];
                }
            }

            Parallel.For(0, size, i => Parallel.For(0, size, j => kernel[i, j] /= sum));
            return kernel;
        }
        
        protected static double[,] GetSincKernel(int size)
        {
            double[,] kernel = new double[size, size];

            double sum = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    double r = Math.Sqrt((x - size / 2 - 1) * (x - size / 2 - 1) + (y - size / 2 - 1) * (y - size / 2 - 1));
                    if (r == 0) kernel[x, y] = 1;
                    else kernel[x, y] = Math.Sin(r) / r;

                    sum += kernel[x, y];
                }
            }

            Parallel.For(0, size, i => Parallel.For(0, size, j => kernel[i, j] /= sum));
            return kernel;
        }

        public static byte[,] Apply(byte[,] pixels, double[,] kernel)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);
            var result = new byte[width, height];
            int kw = kernel.GetLength(0), kh = kernel.GetLength(1);
            int n_kw = kw / 2 + kw % 2;
            int n_kh = kh / 2 + kh % 2;

            Parallel.For(0, width, i =>
                Parallel.For(0, height, j => {
                    double v = 0;
                    for (int ki = -kw / 2; ki < n_kw; ki++)
                        for (int kj = -kh / 2; kj < n_kh; kj++) {
                            int y = (height + j - kj) % height;
                            int x = (width + i - ki) % width;
                            v += kernel[kw / 2 + ki, kh / 2 + kj] * pixels[x, y];
                        }
                    result[i, j] = (byte)Math.Clamp(v, 0.0, 255.0);
                })
            );
            return result;
        }

        public static byte[,] ApplyMedian(byte[,] image, int size)
        {
            int size_x = image.GetLength(0);
            int size_y = image.GetLength(1);
            int n = size / 2 + size % 2;

            byte[,] result = new byte[size_x, size_y];

            Parallel.For(0, size_x, x =>
                Parallel.For(0, size_y, y =>
                {
                    List<byte> temp = new();

                    for (int i = -size / 2; i < n; i++)
                        for (int j = -size / 2; j < n; j++)
                            temp.Add(image[(size_x + x - i) % size_x, (size_y + y - j) % size_y]);

                    temp = temp.OrderByDescending(z => z).ToList();
                    result[x, y] = temp[temp.Count / 2];
                })
            );

            return result;
        }
    }
}
