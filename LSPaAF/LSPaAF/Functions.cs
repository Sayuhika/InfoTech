using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;


namespace LSPaAF
{
    class Functions
    {
        private static readonly double AxisMaxValue = Convert.ToDouble(decimal.MaxValue);
        private static readonly double AxisMinValue = Convert.ToDouble(decimal.MinValue);

        public static double[] Convolution(double[] signal, double[] impsig)
        {
            int n = signal.Length;
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                double res = 0;
                for (int k = 0; k < n; k++)
                {
                    res += signal[k] * impsig[(n + i - k) % n];
                }

                result[i] = res;
            }

            return result;
        }

        public static void DrawGraphResearch(Chart chart, double[] data, double SNRmax, double SNRmin)
        {
            chart.Series.Clear();
            double max = 0;

            
            Series newSeries = new Series("");

            if (max < data.Max())
            {
                max = data.Max();
            }
            for (int i = 0; i < data.Length; i++)
            {
                var valueX = SNRmin + i * (SNRmax - SNRmin) / (data.Length - 1);
                var valueY = data[i];

                var pointValueX = GetMaxAxisValue(valueX);
                var pointValueY = GetMaxAxisValue(valueY);

                newSeries.Points.AddXY(pointValueX, pointValueY);
            }

            newSeries.ChartType = SeriesChartType.Line;
            chart.Series.Add(newSeries);
 
            chart.ChartAreas[0].AxisY.Maximum = GetMaxAxisValue(max);
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = GetMaxAxisValue(SNRmax);
            chart.ChartAreas[0].AxisX.Minimum = SNRmin;
        }

        public static void DrawGraphs(Chart chart, params double[][] data)
        {
            chart.Series.Clear();
            double max = 0;
            double min = 0;

            for (int j = 0; j < data.Length; j++)
            {
                Series newSeries = new Series("");

                if (max < data[j].Max())
                {
                    max = data[j].Max();
                }
                if (min > data[j].Min())
                {
                    min = data[j].Min();
                }
                for (int i = 0; i < data[0].Length; i++)
                {
                    var valueY = data[j][i];
                    var pointValueY = GetMaxAxisValue(valueY);

                    newSeries.Points.AddXY(i, pointValueY);
                }

                newSeries.ChartType = SeriesChartType.Line;
                chart.Series.Add(newSeries);
            }

            chart.ChartAreas[0].AxisY.Maximum = GetMaxAxisValue(max);
            chart.ChartAreas[0].AxisY.Minimum = GetMinAxisValue(min);
        }
        private static double GetMaxAxisValue(double calculatedValue)
        {
            return calculatedValue > AxisMaxValue ? AxisMaxValue : calculatedValue;
        }
        private static double GetMinAxisValue(double calculatedValue)
        {
            return calculatedValue < AxisMinValue ? AxisMinValue : calculatedValue;
        }

        public static double Deviation(double[] data1, double[] data2)
        {
            double result = 0;

            for (int i = 0; i < data1.Length; i++)
            {
                result += (data1[i] - data2[i])*(data1[i] - data2[i]);
            }

            return result;
        }

        public static Func<Object, double[]> threadJob = (HJMprocessor) =>
        {
            DoWorkEventArgs e = new DoWorkEventArgs(null);
            e.Result = false;

            while (!(bool)e.Result)
            {
                (HJMprocessor as HJM).Iterate(null, e);
            }

            return (HJMprocessor as HJM).GetRecSignal();
        };

    }
}
