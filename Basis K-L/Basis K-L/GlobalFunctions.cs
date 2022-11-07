using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Basis_K_L
{
    class GlobalFunctions
    {
        private static readonly double AxisMaxValue = Convert.ToDouble(decimal.MaxValue);
        private static readonly double AxisMinValue = Convert.ToDouble(decimal.MinValue);
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
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = data[0].Length - 1;
        }
        private static double GetMaxAxisValue(double calculatedValue)
        {
            return calculatedValue > AxisMaxValue ? AxisMaxValue : calculatedValue;
        }
        private static double GetMinAxisValue(double calculatedValue)
        {
            return calculatedValue < AxisMinValue ? AxisMinValue : calculatedValue;
        }
    }
}
