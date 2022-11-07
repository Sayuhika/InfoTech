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
using System.ComponentModel;

namespace ImageCleaningService
{
    public partial class GaussParams : UserControl
    {
        public GaussParams()
        {
            InitializeComponent();
        }
    }

    public class GaussParamsViewModel: INotifyPropertyChanged
    {
        public GaussParamsViewModel() { }
        private string title = "Gaussian cupola";
        private double amplitude = 1;
        private double x = 0;
        private double y = 0;
        private double sigmaX = 1;
        private double sigmaY = 1;
        public string Title 
        { 
            get => title; 
            set { title = value; propChanged(nameof(Title)); } 
        }
        public double Amplitude 
        {
            get => amplitude;
            set { amplitude = value; propChanged(nameof(Amplitude)); }
        }
        public double X
        {
            get => x;
            set { x = value; propChanged(nameof(X)); }
        }
        public double Y
        {
            get => y;
            set { y = value; propChanged(nameof(Y)); }
        }
        public double SigmaX
        {
            get => sigmaX;
            set { sigmaX = value; propChanged(nameof(SigmaX)); }
        }
        public double SigmaY
        {
            get => sigmaY;
            set { sigmaY = value; propChanged(nameof(SigmaY)); }
        }

        // Обработка изменения параметров
        private void propChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // Создаем Гауссовские купола
        public double GaussFunction(double cX, double cY) 
        {
            return Amplitude * Math.Exp(-((cX - X) * (cX - X) / (2 * SigmaX * SigmaX)) - ((cY - Y) * (cY - Y) / (2 * SigmaY * SigmaY)));
        }

        public void RandomParams(int sX, int sY) 
        {
            Random random = new Random();

            Amplitude = random.NextDouble();
            X = random.NextDouble() * sX;
            Y = random.NextDouble() * sY;
            SigmaX = random.NextDouble() * sX / 4;
            SigmaY = random.NextDouble() * sY / 4;
        }
    }
}
