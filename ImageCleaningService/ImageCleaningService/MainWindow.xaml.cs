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

namespace ImageCleaningService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GaussParamsViewModel> List_GPs;
        int img_size_X, img_size_Y;
        Bitmap bwImage;

        public MainWindow()
        {
            InitializeComponent();
            GC_count.TextChanged += GC_count_TextChanged;
            List_GPs = new List<GaussParamsViewModel>();
            GC_count_TextChanged(this, null);
        }

        private void GC_count_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Получение размера изображения
            img_size_X = int.Parse(this.image_size_X.Text);
            img_size_Y = int.Parse(this.image_size_Y.Text);

            if  (int.TryParse(GC_count.Text, out int n)) 
            {
                if (n > 100)
                {
                    if(System.Windows.MessageBox.Show("Давай не будем все усложнять?", "ВНИМАНИЕ, АПАСНА", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) 
                    {
                        GC_count.Text = List_GPs.Count.ToString();
                        return; 
                    } else 
                    {
                        System.Windows.MessageBox.Show("Храни Господь оперативку", "ТЕБЯ ПРОСИЛИ ПО ХОРОШЕМУ");
                    };
                }
                for (int i = List_GPs.Count; i < n; i++)
                {
                    // Добавляем поля для данных о куполах
                    var GP = new GaussParamsViewModel { Title = $"Gaussian cupola {i}" };

                    GP.RandomParams(img_size_X, img_size_Y);
                    StackPanelGCs.Children.Add(new GaussParams { DataContext = GP });
                    List_GPs.Add(GP);
                }
                while (List_GPs.Count > n) 
                {
                    // Удаляем поля для данных о куполах
                    List_GPs.RemoveAt(List_GPs.Count - 1);
                    StackPanelGCs.Children.RemoveAt(List_GPs.Count);
                }
            } else 
            {
                System.Media.SystemSounds.Beep.Play();
            }

        }

        private void ButtonDo_Click(object sender, RoutedEventArgs e)
        {
            // Получение размера изображения
            img_size_X = int.Parse(this.image_size_X.Text);
            img_size_Y = int.Parse(this.image_size_Y.Text);
            Complex[,] mainImage = new Complex[img_size_X, img_size_Y];

            if ((bool)this.checkBox_useLocalImage.IsChecked) 
            {
                mainImage = Drawer.BitmapToArray2D(bwImage);
            }
            else 
            {
                mainImage = Functions.CreateSignal(img_size_X, img_size_Y, List_GPs);
            }

            Functions.AddNoiseToSignal(mainImage, double.Parse(this.SNR.Text), out var noisyImage);

            // Находим спектры изображений
            Complex[,] temp_mainImage = Functions.ImageUpdateForFourier(mainImage, (bool)this.checkBox_useInterpolation.IsChecked);
            var mainSpectrum = Functions.FFourier(temp_mainImage, false);
            Complex[,] temp_noisyImage = Functions.ImageUpdateForFourier(noisyImage, (bool)this.checkBox_useInterpolation.IsChecked);
            var noisySpectrum = Functions.FFourier(temp_noisyImage, false);
            int rc;
            var clearsedSpectrum = Functions.ClearSpectrum(noisySpectrum, double.Parse(this.saveEnergyPercentage.Text), out rc);

            var clearsedImage = Functions.FFourier(clearsedSpectrum, true);

            double eps1, eps2;

            Functions.GetEpsilons(mainImage, noisyImage, clearsedImage,out eps1, out eps2);

            this.epsilon1.Text = eps1.ToString();
            this.epsilon2.Text = eps2.ToString();

            // Рисуем изображения и спектры
            ImageO.Source = Drawer.ConvertToSource(Drawer.GetBitmap(temp_mainImage));
            ImageN.Source = Drawer.ConvertToSource(Drawer.GetBitmap(temp_noisyImage));
            //ImageO.Source = Drawer.ConvertToSource(Drawer.GetBitmap(mainImage));
            //ImageN.Source = Drawer.ConvertToSource(Drawer.GetBitmap(noisyImage));
            ImageC.Source = Drawer.ConvertToSource(Drawer.GetBitmap(clearsedImage));

            SpectrumO.Source = Drawer.ConvertToSource(Drawer.GetBitmap(mainSpectrum, true, true));
            SpectrumN.Source = Drawer.ConvertToSource(Drawer.GetBitmap(noisySpectrum, true, true));
            Bitmap clSp = Drawer.GetBitmap(clearsedSpectrum, true, true);
            //Выделяем обрезаный спектр
            int clSp_x = clearsedSpectrum.GetLength(0);
            int clSp_y = clearsedSpectrum.GetLength(1);
            for (int i = 0; i < rc; i++)
            {
                clSp.SetPixel(clSp_x / 2 + i, clSp_y / 2 + rc, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 - i, clSp_y / 2 + rc, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 + rc, clSp_y / 2 + i, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 + rc, clSp_y / 2 - i, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 + i, clSp_y / 2 - rc, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 - i, clSp_y / 2 - rc, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 - rc, clSp_y / 2 + i, System.Drawing.Color.Red);
                clSp.SetPixel(clSp_x / 2 - rc, clSp_y / 2 - i, System.Drawing.Color.Red);
            }
            SpectrumC.Source = Drawer.ConvertToSource(clSp);
        }

        private void Button_OpenImage(object sender, RoutedEventArgs e)
        {
            this.checkBox_useLocalImage.IsChecked = true;
            Bitmap rgbImage = new Bitmap(1,1);
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

            ImageO.Source = Drawer.ConvertToSource(bwImage);
        }

        private void Button_GenRandParams(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < List_GPs.Count; i++)
            {
                List_GPs[i].RandomParams(img_size_X, img_size_Y);
            }

            img_size_X = int.Parse(this.image_size_X.Text);
            img_size_Y = int.Parse(this.image_size_Y.Text);

            // Рисуем картинку и зашумленную картинку
            Complex[,] mainImage = new Complex[img_size_X, img_size_Y];

            mainImage = Functions.CreateSignal(img_size_X, img_size_Y, List_GPs);

            Functions.AddNoiseToSignal(mainImage, double.Parse(this.SNR.Text), out var noisyImage);
            ImageO.Source = Drawer.ConvertToSource(Drawer.GetBitmap(mainImage));
            ImageN.Source = Drawer.ConvertToSource(Drawer.GetBitmap(noisyImage));
        }
    }
}
