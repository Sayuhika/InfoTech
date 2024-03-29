﻿using System;
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
    }
}
