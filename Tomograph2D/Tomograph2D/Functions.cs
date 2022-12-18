using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Tomograph2D
{
    internal class Functions
    {
        public static void xray(byte[,] image, ref List<double[]> Matrix, ref List<double> P, double factor = 3) 
        {
            int size_x = image.GetLength(0);
            int size_y = image.GetLength(1);

            Random rand = new Random();

            // Вертикальное сканирование
            for (int x = 0; x < size_x; x++)
            {
                double sum = 0;
                double[] mtx_v = new double[size_x * size_y];

                for (int y = 0; y < size_y; y++)
                {
                    sum += image[x, y];
                    mtx_v[y * size_x + x] = 1;
                }

                P.Add(sum);
                Matrix.Add(mtx_v);
            }

            for (int i = 0; i < size_x * factor; i++) 
            {
                double x0 = rand.Next(size_x);
                double y0 = 0;
                double x1 = rand.Next(size_x);
                double y1 = size_y - 1;
                double sum = 0;
                double[] mtx_v = new double[size_x * size_y];

                for (int y = 0; y < size_y; y++)
                {
                    int x = (int)Math.Round(x0 + (y - y0) * (x1 - x0) / (y1 - y0));
                    sum += image[x, y];
                    mtx_v[y * size_x + x] = 1;
                }

                P.Add(sum);
                Matrix.Add(mtx_v);
            }

            // Горизонтальное сканирование
            for (int y = 0; y < size_y; y++)
            {
                double sum = 0;
                double[] mtx_v = new double[size_x * size_y];

                for (int x = 0; x < size_x; x++)
                {
                    sum += image[x, y];
                    mtx_v[y * size_x + x] = 1;
                }

                P.Add(sum);
                Matrix.Add(mtx_v);
            }

            for (int i = 0; i < size_y * factor; i++)
            {
                double x0 = 0;
                double y0 = rand.Next(size_y);
                double x1 = size_x - 1;
                double y1 = rand.Next(size_y);
                double sum = 0;
                double[] mtx_v = new double[size_x * size_y];

                for (int x = 0; x < size_x; x++)
                {
                    int y = (int)Math.Round(y0 + (x - x0) * (y1 - y0) / (x1 - x0));
                    sum += image[x, y];
                    mtx_v[y * size_x + x] = 1;
                }

                P.Add(sum);
                Matrix.Add(mtx_v);
            }
        }

        public static void GetEpsilons(byte[,] image, byte[,] rec_image, out double epsilon)
        {
            epsilon = 0;
            double energy = 0;

            int size_x = image.GetLength(0);
            int size_y = image.GetLength(1);

            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    epsilon += (image[x, y] - rec_image[x, y]) * (image[x, y] - rec_image[x, y]);
                    energy += image[x, y] * image[x, y];
                }
            }

            epsilon /= energy;
        }
    }
}
