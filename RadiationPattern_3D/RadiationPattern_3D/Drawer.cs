using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace RadiationPattern_3D
{
    internal class Drawer
    {
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

        public static Bitmap CreateAntennaDataImage(bool[,] antenna_map)
        {
            int size_x = antenna_map.GetLength(0);
            int size_y = antenna_map.GetLength(1);
            int size_p = 10;

            Bitmap result = new(size_x * size_p, size_y * size_p);

            // Проход по блокам
            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    // Проход внутри блока

                    Color fillColor = antenna_map[x, y] ? Color.Green : Color.Gray;

                    for (int i = 1; i < size_p - 1; i++)
                    {
                        for (int j = 1; j < size_p; j++)
                        {
                            result.SetPixel(i + x * size_p, j + y * size_p, fillColor);
                        }
                    }
                }
            }

            return result;
        }
        public static Bitmap TakeScreenshot(int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            byte[] rgbData = new byte[w * h * 3];
            GL.ReadPixels(0, 0, w, h, OpenTK.Graphics.OpenGL.PixelFormat.Rgb,PixelType.UnsignedByte, rgbData);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Marshal.Copy(rgbData, 0, data.Scan0, rgbData.Length);
            bmp.UnlockBits(data);

            return bmp;
        }

        public static void DrawRadiationPattern(double[,] I, double maxI, double power_koff = 0) 
        {
            GL.Color3(Color.Green);
            int size_x = I.GetLength(0);
            int size_y = I.GetLength(1);

            double scale;
            if (power_koff == 0) 
                scale = 0.5 * (size_x + size_y) / maxI;
            else 
                scale = power_koff;

            for (int x = 0; x < size_x - 1; x++)
            {             
                for (int y = 0; y < size_y - 1; y++)
                {
                    if ((I[x, y] < 0) || (I[x + 1, y] < 0) || (I[x, y + 1] < 0) || (I[x + 1, y + 1] < 0)) continue;

                    GL.Begin(PrimitiveType.Polygon);
                    GL.Color3(0, (I[x,y] / maxI), 0.2);
                    GL.Vertex3(x - size_x * 0.5, y - size_y * 0.5, I[x,y] * scale);
                    GL.Vertex3(x + 1 - size_x * 0.5, y - size_y * 0.5, I[x + 1, y] * scale);
                    GL.Vertex3(x + 1 - size_x * 0.5, y + 1 - size_y * 0.5, I[x + 1, y + 1] * scale);
                    GL.Vertex3(x - size_x * 0.5, y + 1 - size_y * 0.5, I[x, y + 1] * scale);
                    GL.End();
                }
            }
        }
    }
}
