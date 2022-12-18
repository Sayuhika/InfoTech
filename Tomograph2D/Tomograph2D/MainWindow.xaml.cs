using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Numerics;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using Accord.Math;

namespace Tomograph2D
{
    public partial class MainWindow : Window
    {
        Bitmap image;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDo_Click(object sender, RoutedEventArgs e)
        {
            List<double[]> Matrix = new();
            List<double> p = new();

            Functions.xray(image.GetBitmapPixels(), ref Matrix, ref p, double.Parse(factor.Text));

            double[,] mtx = new double[Matrix.Count, Matrix[0].Length];
            
            for (int x = 0; x < Matrix[0].Length; x++)
            {
                for (int y = 0; y < Matrix.Count; y++)
                {
                    mtx[y,x] = Matrix[y][x];
                }
            }

            var s = Accord.Math.Matrix.Decompose(mtx, true).Solve(p.ToArray());

            byte[,] rec_img = new byte[image.Width, image.Height];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    rec_img[x, y] = (byte)(s[x + y * image.Width] < 0 ? 0 : s[x + y * image.Width]);
                }
            }

            ImageN.Source = rec_img.GetBitmap().ConvertToSource();

            // Расчет отклонений
            double eps;
            Functions.GetEpsilons(image.GetBitmapPixels(), rec_img, out eps);
            epsilon.Text = eps.ToString();
        }

        private void Button_OpenImage(object sender, RoutedEventArgs e)
        {
            Bitmap rgbImage = new Bitmap(1, 1);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                rgbImage = new Bitmap(openFileDialog.FileName);
                image = new Bitmap(openFileDialog.FileName);
            }

            // Indicates row number
            for (int row = 0; row < rgbImage.Width; row++)
            {
                // Indicate column number
                for (int column = 0; column < rgbImage.Height; column++) 
                {
                    // Get the color pixel
                    var colorValue = rgbImage.GetPixel(row, column); 
                    var averageValue = (int)Math.Round(.299 * colorValue.R + .587 * colorValue.G + .114 * colorValue.B);

                    // Set the value to new pixel
                    image.SetPixel(row, column, System.Drawing.Color.FromArgb(averageValue, averageValue, averageValue)); 
                }
            }

            ImageO.Source = image.ConvertToSource();
        }
    }
}
