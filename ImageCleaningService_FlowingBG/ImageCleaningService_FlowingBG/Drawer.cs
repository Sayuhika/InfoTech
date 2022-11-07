using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Numerics;

namespace ImageCleaningService_FlowingBG
{
    internal class Drawer
    {
        /// <summary>
        /// Конвертирует Bitmap в BitmapImage для использования в качестве ресурса у объекта интерфейса Image
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static BitmapImage ConvertToSource(Bitmap src)
        {
            var ms = new MemoryStream();
            src.Save(ms, ImageFormat.Png);
            var image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }

        public static byte[,] GetBitmapPixels(Bitmap image)
        {
            int width = image.Width, height = image.Height;
            var pixeldata = image.LockBits(
                new(0, 0, width, height),
                ImageLockMode.ReadOnly,
                image.PixelFormat);
            int stride = pixeldata.Stride, depth = Image.GetPixelFormatSize(pixeldata.PixelFormat) / 8;
            if (depth < 3) throw new ArgumentException();
            byte[] data = new byte[height * stride];
            Marshal.Copy(pixeldata.Scan0, data, 0, data.Length);
            image.UnlockBits(pixeldata);
            byte[,] pixels = new byte[width, height];
            Parallel.For(0, width, i =>
                Parallel.For(0, height, j => {
                    int k = i * depth + j * stride;
                    double v = data[k] * .299 + data[k + 1] * .587 + data[k + 2] * .114;
                    pixels[i, j] = (byte)Math.Clamp(v, 0.0, 255.0);
                })
            );
            return pixels;
        }

        public static Complex[,] BitmapToArray2D(Bitmap image)
        {
            int size_x = image.Width;
            int size_y = image.Height;

            Complex[,] array2D = new Complex[size_x, size_y];

            for (int x = 0; x < size_x; x++)
                for (int y = 0; y < size_y; y++)
                    array2D[x, y] = image.GetPixel(x, y).R;

            return array2D;
        }

        public static Bitmap GetBitmap(byte[,] pixels)
        {
            int width = pixels.GetLength(0), height = pixels.GetLength(1);
            var data = new byte[4 * width * height];
            Parallel.For(0, width, i =>
                Parallel.For(0, height, j => {
                    int k = 4 * (i + j * width);
                    data[k] = data[k + 1] = data[k + 2] = pixels[i, j];
                    data[k + 3] = 255;
                })
            );

            var Result = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var resultdata = Result.LockBits(
                new(0, 0, width, height),
                ImageLockMode.WriteOnly,
                Result.PixelFormat);
            Marshal.Copy(data, 0, resultdata.Scan0, data.Length);
            Result.UnlockBits(resultdata);
            return Result;
        }

        /// <summary>
        /// Преобразует изображение формата Complex[,] в формат Bitmap
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Bitmap GetBitmap(Complex[,] image, bool isSpectrum = false, bool scale = false)
        {
            int width = image.GetLength(0), height = image.GetLength(1);
            var buffer = new byte[width * height * 4];

            var max = double.NegativeInfinity;
            var min = double.PositiveInfinity;

            Func<int, int, double> func;

            if (isSpectrum)
            {
                if (scale)
                {
                    func = (i, j) =>
                    {
                        int x = (i + width / 2) % width;
                        int y = (j + height / 2) % height;

                        if ((x == 0 && y == 0)) return 0;
  
                        return Math.Log(image[x, y].Magnitude + 1);
                    };
                }
                else 
                {
                    func = (i, j) =>
                    {
                        int x = (i + width / 2) % width;
                        int y = (j + height / 2) % height;

                        if ((x == 0 && y == 0)) return 0;

                        return image[x, y].Magnitude;
                    };
                }
            }
            else
            {
                func = (i, j) =>
                {
                    return image[i, j].Real;
                };
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Находим минимальное и максимальное значение интенсивности изображения
                    // Эти значения будут определять раскраску изображения
                    if (max < func(x, y)) max = func(x, y);
                    if (min > func(x, y)) min = func(x, y);
                }
            }

            System.Threading.Tasks.Parallel.For(0, width, x => {
                System.Threading.Tasks.Parallel.For(0, height, y => {
                    double v = (func(x, y) - min) / (max - min);
                    int k = y * width + x;
                    buffer[4 * k] = buffer[4 * k + 1] = buffer[4 * k + 2] = (byte)(255 * v);
                    buffer[4 * k + 3] = 255;
                });
            });

            var Result = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var resultdata = Result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, Result.PixelFormat);
            Marshal.Copy(buffer, 0, resultdata.Scan0, buffer.Length);
            Result.UnlockBits(resultdata);
            return Result;
        }
    }
}
