using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using System.Numerics;

namespace ImageCleaningService
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

            if (scale)
            {
                func = (i, j) =>
                {
                    int x = (i + width / 2) % width;
                    int y = (j + height / 2) % height;

                    int p = 1;

                    if ((x < p && y < p ) ) 
                    {
                        return 0;
                    }
                    if (isSpectrum) 
                        return Math.Log(image[x, y].Magnitude + 1);
                    else 
                        return Math.Log(image[x, y].Real + 1);
                };
            }
            else
            {
                func = (i, j) =>
                {
                    if (isSpectrum)
                        return image[i, j].Magnitude;
                    else
                        return image[i, j].Real;
                };
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Находим минимальное и максимальное значение интенсивности изображения
                    // Эти значения будут определять раскраску изображения
                    if (max < func(x,y)) max = func(x, y);
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
