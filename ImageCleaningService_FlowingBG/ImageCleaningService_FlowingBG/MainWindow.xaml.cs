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
using System.Drawing;
using Microsoft.Win32;
using System.Numerics;

namespace ImageCleaningService_FlowingBG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isImageLoad = false;
        Bitmap bwImage;
        byte[,] imageO, imageN, imageC, noise;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDo_Click(object sender, RoutedEventArgs e)
        {
            if (isImageLoad)
            {
                imageO = Drawer.GetBitmapPixels(bwImage);
                imageN = Functions.AddNoiseToImage(imageO, 4.0);

                if (FilterMod.IsChecked == true)
                    noise = Filter.ApplyMedian(imageN, int.Parse(blursize.Text));
                else 
                    noise = Filter.Apply(imageN,Filter.GetKernel(Filter.KernelType.Blur,int.Parse(blursize.Text)));

                imageC = Functions.SubtractImage(imageN, noise, double.Parse(subkoff.Text));

                // Отрисовка изображений
                ImageO.Source = Drawer.ConvertToSource(bwImage);
                showNoisePart_Click(this, new RoutedEventArgs());
                ImageC.Source = Drawer.ConvertToSource(Drawer.GetBitmap(imageC));

                // Расчет отклонений
                double eps1, eps2;

                Functions.GetEpsilons(imageO, imageN, imageC, out eps1, out eps2);

                epsilon1.Text = eps1.ToString();
                epsilon2.Text = eps2.ToString();
            }
            else
            {
                Button_OpenImage(sender, e);
                ButtonDo_Click(sender, e);
            }
        }

        private void Button_OpenImage(object sender, RoutedEventArgs e)
        {
            Bitmap rgbImage = new Bitmap(1, 1);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                rgbImage = new Bitmap(openFileDialog.FileName);
                bwImage = new Bitmap(openFileDialog.FileName);
            }

            for (int row = 0; row < rgbImage.Width; row++) // Indicates row number
            {
                for (int column = 0; column < rgbImage.Height; column++) // Indicate column number
                {
                    var colorValue = rgbImage.GetPixel(row, column); // Get the color pixel
                    var averageValue = (int)Math.Round(.299 * colorValue.R + .587 * colorValue.G + .114 * colorValue.B);
                    bwImage.SetPixel(row, column, System.Drawing.Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }
            isImageLoad = true;
            ImageO.Source = Drawer.ConvertToSource(bwImage);
        }

        private void ButtonDoResearch_Click(object sender, RoutedEventArgs e)
        {
            if (isImageLoad)
            {
                // Исходное изображение
                byte[,] image = Drawer.GetBitmapPixels(bwImage);
                // Зашумленное изображение
                imageN = Functions.AddNoiseToImage(Drawer.GetBitmapPixels(bwImage), 4.0);

                int N = 20;
                double[] epses1 = new double[N];
                double[] epses2 = new double[N];

                // Расчеты
                for (int i = 0; i < N; i++)
                {
                    if (FilterMod.IsChecked == true)
                        noise = Filter.ApplyMedian(imageN, i + 10);
                    else
                        noise = Filter.Apply(imageN, Filter.GetKernel(Filter.KernelType.Blur, i + 10));

                    var imageC = Functions.SubtractImage(imageN, noise, double.Parse(subkoff.Text));

                    double eps1, eps2;

                    Functions.GetEpsilons(image, imageN, imageC, out eps1, out eps2);

                    epses1[i] = eps1;
                    epses2[i] = eps2;
                }

                // Рисуем график
                PlotViewModel plot = new();
                ResearchLinear.DataContext = plot;
                plot.Points = new[] { 
                    epses1.Select((x, i) => new OxyPlot.DataPoint(i, x)).ToList(),
                    epses2.Select((x, i) => new OxyPlot.DataPoint(i, x)).ToList() };
            }
            else
            {
                Button_OpenImage(sender, e);
                ButtonDoResearch_Click(sender, e);
            }
        }

        private void showNoisePart_Click(object sender, RoutedEventArgs e)
        {
            if (showNoisePart.IsChecked.Value) 
            {
                ImageN.Source = Drawer.ConvertToSource(Drawer.GetBitmap(noise));
            }
            else
            {
                ImageN.Source = Drawer.ConvertToSource(Drawer.GetBitmap(imageN));
            }
        }
    }
}
