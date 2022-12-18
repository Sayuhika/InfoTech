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
    public partial class MainWindow : Window
    {
        bool isImageLoad = false;
        Bitmap bwImage;
        byte[,] imageO, imageN, imageC, noise;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки.
        /// 
        /// Выполняет разовую отчистку изображения от плавного фона с заданными параметрами.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDo_Click(object sender, RoutedEventArgs e)
        {
            if (isImageLoad)
            {
                if (imageO == null) imageO = Drawer.GetBitmapPixels(bwImage);
                if (imageN == null) ButtonCreateNoise_Click(this, new RoutedEventArgs());

                double k;

                if (FilterMod.IsChecked == true) 
                {
                    noise = Filter.ApplyMedian(imageN, int.Parse(blursize.Text));
                    k = double.Parse(subkoff_m.Text);
                }                   
                else 
                {
                    noise = Filter.Apply(imageN, Filter.GetKernel(Filter.KernelType.Blur, int.Parse(blursize.Text)));
                    k = double.Parse(subkoff_l.Text);
                }

                imageC = Functions.SubtractImage(imageN, noise, k);

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
                Button_OpenImage(this, new RoutedEventArgs());
                ButtonDo_Click(this, new RoutedEventArgs());
            }
        }

        /// <summary>
        /// Обработчик кнопки.
        /// 
        /// Генерация плавного фона (шума).
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateNoise_Click(object sender, RoutedEventArgs e)
        {
            if (isImageLoad)
            {
                if (imageO == null) imageO = Drawer.GetBitmapPixels(bwImage);
                imageN = Functions.AddNoiseToImage(imageO, 4.0);
                showNoisePart_Click(this, new RoutedEventArgs());
            }
            else 
            {
                Button_OpenImage(this, new RoutedEventArgs());
                ButtonCreateNoise_Click(this, new RoutedEventArgs());
            }
        }

        /// <summary>
        /// Обработчик кнопки.
        /// 
        /// Открыть внешнее изображение и перевести его в ЧБ.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Обработчик кнопки.
        /// 
        /// Исследовательская часть программы.
        /// 
        /// Создает фильтры различного рамзера и считает отклонение между исходным изображением и восстановленным
        /// Строит график из полученных отклонений в зависимости от размера фильтра.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDoResearch_Click(object sender, RoutedEventArgs e)
        {
            if (isImageLoad)
            {
                // Исходное изображение
                byte[,] image = Drawer.GetBitmapPixels(bwImage);

                // Зашумленное изображение
                if (imageN == null) ButtonCreateNoise_Click(this, new RoutedEventArgs());

                int N = int.Parse(stepCount.Text);
                int step = int.Parse(stepSize.Text);
                int startFS = int.Parse(blursize.Text);
                double k_l = double.Parse(subkoff_l.Text);
                double k_m = double.Parse(subkoff_m.Text);

                List<OxyPlot.DataPoint> epses1_l = new();
                List<OxyPlot.DataPoint> epses2_l = new();
                List<OxyPlot.DataPoint> epses1_m = new();
                List<OxyPlot.DataPoint> epses2_m = new();

                // Расчеты
                for (int i = 0; i < N; i++)
                {
                    int fs = startFS + i * step;
                    double eps1, eps2;

                    // Линейный фильтр
                    var noise_l = Filter.Apply(imageN, Filter.GetKernel(Filter.KernelType.Blur, fs));
                    imageC = Functions.SubtractImage(imageN, noise_l, k_l);
                    Functions.GetEpsilons(image, imageN, imageC, out eps1, out eps2);
                    epses1_l.Add(new OxyPlot.DataPoint(fs, eps1));
                    epses2_l.Add(new OxyPlot.DataPoint(fs, eps2));

                    // Медианный фильтр
                    var noise_m = Filter.ApplyMedian(imageN, fs);
                    imageC = Functions.SubtractImage(imageN, noise_m, k_m);
                    Functions.GetEpsilons(image, imageN, imageC, out eps1, out eps2);
                    epses1_m.Add(new OxyPlot.DataPoint(fs, eps1));
                    epses2_m.Add(new OxyPlot.DataPoint(fs, eps2));
                }

                // Графики
                // Линейный фильтр
                PlotViewModel plot_l = new();
                plot_l.Points = new[] { new List<OxyPlot.DataPoint>()};
                ResearchLinear.DataContext = plot_l;
                plot_l.Points[0] = epses2_l;

                // Медианный фильтр
                PlotViewModel plot_m = new();
                plot_m.Points = new[] { new List<OxyPlot.DataPoint>() };
                ResearchMedian.DataContext = plot_m;
                plot_m.Points[0] = epses2_m;
            }
            else
            {
                Button_OpenImage(sender, e);
                ButtonDoResearch_Click(sender, e);
            }
        }

        /// <summary>
        /// Функция определеяет что нужно отрисовать на текущий момент:
        /// Зашумленное изображение или его размытый аналог (выделенный шум).
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
