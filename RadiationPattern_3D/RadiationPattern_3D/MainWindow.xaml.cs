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
using OpenTK.Wpf;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Input;

namespace RadiationPattern_3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool[,] AntennaData;
        public double[,] I;
        public double phi = 0, theta = 0, r = 100;
        public double phiStart, thetaStart;
        public const double delta_fi = 5;
        public const double delta_tetta = 5;
        public const double delta_r = 10;
        public const double mouseScale = 0.01;
        public Point MousePositionStart;
        public double maxI;
        public MainWindow()
        {
            InitializeComponent();

            InitializeAntennasData(11);          
            AntennaDataImage.Source = Drawer.ConvertToSource(Drawer.CreateAntennaDataImage(AntennaData));

            I = new double[1, 1];

            var settings = new GLWpfControlSettings
            {
                MajorVersion = 2,
                MinorVersion = 1
            };
            OpenTkControl.Start(settings);
        }

        private void InitializeAntennasData(int size) 
        {
            AntennaData = new bool[size,size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    AntennaData[x, y] = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            phi = 0;
            theta = 0; 
            r = 100;
            I = Functions.GetRadiationPattern(AntennaData, int.Parse(R.Text), double.Parse(d_koff.Text), double.Parse(lambda.Text), out maxI);
        }

        private void AntennaDataImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(AntennaDataImage);

            int size = int.Parse(antennaDataSize.Text);
            int x = (int)(mousePosition.X / AntennaDataImage.ActualWidth * size);
            int y = (int)(mousePosition.Y / AntennaDataImage.ActualHeight * size);

            AntennaData[x, y] = !AntennaData[x, y];
            AntennaDataImage.Source = Drawer.ConvertToSource(Drawer.CreateAntennaDataImage(AntennaData));
        }

        private void OpenTkControl_OnRender(TimeSpan delta)
        {
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            double scale = 1.0 + 100 / r;
            GL.Scale(scale, scale, scale);
            GL.Rotate(theta, 1.0, 0.0, 0.0);
            GL.Rotate(phi, 0.0, 1.0, 0.0);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            double size = 200;
            GL.Ortho(-size, size, -size, size, -500, 500);

            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            Drawer.DrawRadiationPattern(I, maxI);
        }

        private void OpenTkControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed) 
            {
                Point MouseCurrentPosition = e.GetPosition(OpenTkControl);
                phi = phiStart + delta_fi * mouseScale * (MouseCurrentPosition.X - MousePositionStart.X);
                theta = thetaStart + delta_tetta * mouseScale * (MouseCurrentPosition.Y - MousePositionStart.Y);
            }
            else 
            {
                phiStart = phi;
                thetaStart = theta;
                MousePositionStart = e.GetPosition(OpenTkControl);
            }
        }

        private void OpenTkControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MousePositionStart = Mouse.GetPosition(OpenTkControl);
        }

        private void OpenTkControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void OpenTkControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) 
            {
                r += delta_r;
            }
            else if (e.Delta < 0)
            {
                r -= delta_r;
            }
        }

        private void antennaDataSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            InitializeAntennasData(int.Parse(antennaDataSize.Text));

            try
            {
                AntennaDataImage.Source = Drawer.ConvertToSource(Drawer.CreateAntennaDataImage(AntennaData));
            }
            catch (NullReferenceException) { }
        }
    }
}
