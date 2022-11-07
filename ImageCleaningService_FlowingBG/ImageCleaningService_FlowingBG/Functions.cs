using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImageCleaningService_FlowingBG
{
    internal class Functions
    {
        public static byte[,] AddNoiseToImage(byte[,] image, double ampMult = 1.0) 
        {
            int size_x = image.GetLength(0);
            int size_y = image.GetLength(1);
            byte[,] imageN = new byte[size_x, size_y];

            // Параметры гауссовского купола
            Random rand = new();
            double SigmaX = rand.Next(size_x / 2) + size_x / 5;
            double SigmaY = rand.Next(size_y / 2) + size_y / 5;
            double cX = rand.Next(size_x);
            double cY = rand.Next(size_y);

            Parallel.For(0, size_x, x => {
                Parallel.For(0, size_y, y => {
                    double nv = Math.Exp(-((x - cX) * (x - cX) / (2 * SigmaX * SigmaX)) - ((y - cY) * (y - cY) / (2 * SigmaY * SigmaY)));
                    imageN[x, y] = (byte)((image[x, y] + 255.0 * ampMult * nv) / (1.0 + ampMult));
                });
            });

            return imageN;
        }

        public static byte[,] SubtractImage(byte[,] main_image, byte[,] subtrahend_image, double subkoff = 1) 
        {            
            int width = main_image.GetLength(0);
            int height = main_image.GetLength(1);

            if (width != subtrahend_image.GetLength(0) || height != subtrahend_image.GetLength(1))
                throw new ArgumentException();
            
            byte[,] substract_image = new byte[width, height];

            // Вычитание одного изображения из другого с некоторым коэффициентом
            Parallel.For(0, width, i =>
                Parallel.For(0, height, j =>
                {
                    double v = main_image[i, j] - subtrahend_image[i, j] * subkoff;
                    substract_image[i, j] = (byte)Math.Clamp(v, 0.0, 255.0);
                })
            );

            return substract_image;
        }

        public static void GetEpsilons(byte[,] mainImage, byte[,] noisyImage, byte[,] clearsedImage, out double epsilon1, out double epsilon2)
        {
            epsilon1 = epsilon2 = 0;
            double energy = 0;

            int size_x = mainImage.GetLength(0);
            int size_y = mainImage.GetLength(1);

            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    epsilon1 += (mainImage[x, y] - noisyImage[x, y]) * (mainImage[x, y] - noisyImage[x, y]);
                    epsilon2 += (mainImage[x, y] - clearsedImage[x, y]) * (mainImage[x, y] - clearsedImage[x, y]);
                    energy += mainImage[x, y] * mainImage[x, y];
                }
            }

            epsilon1 /= energy;
            epsilon2 /= energy;
        }
    }
}
