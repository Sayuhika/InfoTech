using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basis_K_L
{
    public partial class FormMain : Form
    {
        double[] paramA, paramB, paramC, signal, EVA;
        double[][] EFL, EFR;
        int length;

        private FormSignalData formData;

        public FormMain()
        {
            InitializeComponent();
            formData = new FormSignalData();
            comboBoxSignalForm.SelectedIndex = 0;
        }

        private void buttonMatrixGen_Click(object sender, EventArgs e)
        {
            int M = Convert.ToInt16(textBoxMatrixM.Text);
            int N = Convert.ToInt16(textBoxMatrixN.Text);
            double[,] A = new double[M, N];
            double[,] Ar = new double[M, N];
            double[] x = new double[N];
            double[] b = new double[M];
            double E = 0;
            double nX = 0;
            Random rand = new Random();

            // Заполнение матрицы А
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] = 2 * rand.NextDouble() - 1;
                }
            }
            textBoxDetA.Text = Functions.getDet(A).ToString();

            // Заполнение вектора b
            for (int i = 0; i < M; i++)
            {
                b[i] = 2 * rand.NextDouble() - 1;
            }

            Ar = Functions.Reverse(A);

            // Расчет вектора x
            for (int i = 0; i < N; i++)
            {
                double sum = 0;

                for (int j = 0; j < M; j++)
                {
                    sum += Ar[i, j] * b[j];
                }

                x[i] = sum;
                nX += sum * sum;
            }

            // Расчет невязки
            for (int i = 0; i < M; i++)
            {
                double sum = b[i];
                for (int j = 0; j < N; j++)
                {
                    sum -= A[i, j] * x[j];
                }
                E += sum * sum;
            }
            E /= N;

            // Вывод результатов на экран
            textBoxDiscrepancy.Text = E.ToString();
            textBoxNorma.Text = nX.ToString();

            DataTable matrixTable = new DataTable();
            DataTable xTable = new DataTable();
            DataTable bTable = new DataTable();

            for (int i = 0; i < N; i++)
            {
                matrixTable.Columns.Add("", typeof(double));
            }
            xTable.Columns.Add("", typeof(double));
            bTable.Columns.Add("", typeof(double));
            for (int i = 0; i < M; i++)
            {
                string[] row = new string[N];
                for (int j = 0; j < N; j++)
                {
                    row[j] = string.Format("{0:f5}", A[i, j]);
                }
                matrixTable.Rows.Add(row);
                bTable.Rows.Add(string.Format("{0:f5}", b[i]));
            }
            for (int i = 0; i < N; i++)
            {
                xTable.Rows.Add(string.Format("{0:f5}", x[i]));
            }

            dataGridViewMatrix.DataSource = matrixTable;
            dataGridViewVectorX.DataSource = xTable;
            dataGridViewVectorB.DataSource = bTable;
        }

        private void numericUpDownEV_ValueChanged(object sender, EventArgs e)
        {
            var EV = new double[(int)numericUpDownEV.Value];
            for (int i = 0; i < EV.Length; i++)
            {
                EV[i] = EVA[i];
            }
            GlobalFunctions.DrawGraphs(chartEigenvalues, EV);
            chartEigenvalues.Series.Last().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void buttonOpenFormData_Click(object sender, EventArgs e)
        {
            if (formData.ShowDialog() == DialogResult.OK)
            {
                setSettings();
            }
        }

        private void numericUpDownBF_ValueChanged(object sender, EventArgs e)
        { 
            GlobalFunctions.DrawGraphs(chartBasisFunc, EFL[(int)numericUpDownBF.Value]);
        }

        private void setSettings()
        {
            // Инициализация начальных заданных данных
            paramA = new double[3];
            paramB = new double[3];
            paramC = new double[3];

            paramA[0] = formData.paramA1;
            paramA[1] = formData.paramA2;
            paramA[2] = formData.paramA3;
            paramB[0] = formData.paramB1;
            paramB[1] = formData.paramB2;
            paramB[2] = formData.paramB3;
            paramC[0] = formData.paramC1;
            paramC[1] = formData.paramC2;
            paramC[2] = formData.paramC3;

            length = formData.signalLenght;

            // Инициализация массивов для сигналов
            signal = new double[length];

            // Генерация сигнала в соответствии с указаной формой сигнала
            switch (comboBoxSignalForm.SelectedIndex)
            {
                // Генерация гауссовского сигнала
                case 0:
                    {
                        for (int j = 0; j < length; j++)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                signal[j] += paramA[i] * Math.Exp(-0.5 * (j - paramB[i]) * (j - paramB[i]) / (paramC[i] * paramC[i]));
                            }
                        }

                        break;
                    }

                // Генерация полигармонического сигнала
                case 1:
                    {
                        for (int j = 0; j < length; j++)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                signal[j] += paramA[i] * Math.Sin(paramB[i] * j + paramC[i]);
                            }
                        }

                        break;
                    }

                // Генерация экспоненциально затухающего полигармонического сигнала
                case 2:
                    {
                        for (int j = 0; j < length; j++)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                signal[j] += paramA[i] * Math.Sin(paramB[i] * j + paramC[i]) * Math.Exp(-j * 10/ (length));
                            }
                        }

                        break;
                    }
            }

            // Отрисовка сигнала
            GlobalFunctions.DrawGraphs(chartSignal, signal);


        }

        private void comboBoxSignalForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSignalForm.SelectedIndex)
            {
                case 0:
                    {
                        // Переименовываем поля в соответствии с указаной формой сигнала
                        formData.groupBox1.Text = "Гауссовский купол 1";
                        formData.groupBox2.Text = "Гауссовский купол 2";
                        formData.groupBox3.Text = "Гауссовский купол 3";
                        formData.labelParamB1.Text = formData.labelParamB2.Text = formData.labelParamB3.Text = "Математическое ожидание:";
                        formData.labelParamC1.Text = formData.labelParamC2.Text = formData.labelParamC3.Text = "Среднеквадротичное отклонение:";

                        // Выставляем начальные значения
                        formData.numericUpDownParamA1.Value = 3;
                        formData.numericUpDownParamA2.Value = 2;
                        formData.numericUpDownParamA3.Value = 4;

                        formData.numericUpDownParamB1.DecimalPlaces = formData.numericUpDownParamB2.DecimalPlaces = formData.numericUpDownParamB3.DecimalPlaces = 0;
                        formData.numericUpDownParamB1.Value = 180;
                        formData.numericUpDownParamB2.Value = 350;
                        formData.numericUpDownParamB3.Value = 540;

                        formData.numericUpDownParamC1.DecimalPlaces = formData.numericUpDownParamC2.DecimalPlaces = formData.numericUpDownParamC3.DecimalPlaces = 0;
                        formData.numericUpDownParamC1.Value = 60;
                        formData.numericUpDownParamC2.Value = 20;
                        formData.numericUpDownParamC3.Value = 40;

                        formData.textBoxSigLength.Text = "650";

                        break;
                    }
                case 1:
                    {
                        // Переименовываем поля в соответствии с указаной формой сигнала
                        formData.groupBox1.Text = "Синусойда 1";
                        formData.groupBox2.Text = "Синусойда 2";
                        formData.groupBox3.Text = "Синусойда 3";
                        formData.labelParamB1.Text = formData.labelParamB2.Text = formData.labelParamB3.Text = "Частота:";
                        formData.labelParamC1.Text = formData.labelParamC2.Text = formData.labelParamC3.Text = "Начальная фаза:";

                        // Выставляем начальные значения
                        formData.numericUpDownParamA1.Value = 1;
                        formData.numericUpDownParamA2.Value = 3;
                        formData.numericUpDownParamA3.Value = 2;

                        formData.numericUpDownParamB1.DecimalPlaces = formData.numericUpDownParamB2.DecimalPlaces = formData.numericUpDownParamB3.DecimalPlaces = 3;
                        formData.numericUpDownParamB1.Value = 0.015M;
                        formData.numericUpDownParamB2.Value = 0.030M;
                        formData.numericUpDownParamB3.Value = 0.040M;

                        formData.numericUpDownParamC1.DecimalPlaces = formData.numericUpDownParamC2.DecimalPlaces = formData.numericUpDownParamC3.DecimalPlaces = 3;
                        formData.numericUpDownParamC1.Value = 0.6M;
                        formData.numericUpDownParamC2.Value = 0.2M;
                        formData.numericUpDownParamC3.Value = 0.4M;

                        formData.textBoxSigLength.Text = "1024";

                        break;
                    }
                case 2:
                    {
                        // Переименовываем поля в соответствии с указаной формой сигнала
                        formData.groupBox1.Text = "Синусойда 1";
                        formData.groupBox2.Text = "Синусойда 2";
                        formData.groupBox3.Text = "Синусойда 3";
                        formData.labelParamB1.Text = formData.labelParamB2.Text = formData.labelParamB3.Text = "Частота:";
                        formData.labelParamC1.Text = formData.labelParamC2.Text = formData.labelParamC3.Text = "Начальная фаза:";

                        // Выставляем начальные значения
                        formData.numericUpDownParamA1.Value = 2;
                        formData.numericUpDownParamA2.Value = 3;
                        formData.numericUpDownParamA3.Value = 2;

                        formData.numericUpDownParamB1.DecimalPlaces = formData.numericUpDownParamB2.DecimalPlaces = formData.numericUpDownParamB3.DecimalPlaces = 3;
                        formData.numericUpDownParamB1.Value = 0.25M;
                        formData.numericUpDownParamB2.Value = 0.12M;
                        formData.numericUpDownParamB3.Value = 0.18M;

                        formData.numericUpDownParamC1.DecimalPlaces = formData.numericUpDownParamC2.DecimalPlaces = formData.numericUpDownParamC3.DecimalPlaces = 3;
                        formData.numericUpDownParamC1.Value = 0.6M;
                        formData.numericUpDownParamC2.Value = 0.2M;
                        formData.numericUpDownParamC3.Value = 0.4M;

                        formData.textBoxSigLength.Text = "512";

                        break;
                    }
            }
        }

        private void buttonGenFunctions_Click(object sender, EventArgs e)
        {
            int P = int.Parse(textBoxACMo.Text);
            double[,] R = new double[P, P];

            for (int i = 0; i < P - 1; i++)
            {
                for (int j = 0; j < P - 1; j++)
                {
                    int m = i - j;
                    double koff = 1.0 / (length - Math.Abs(m));

                    int kk = 0;     
                    while (m + kk < -1)
                    {
                        kk++;
                    }

                    for (int k = 1 + kk; k < (length - Math.Abs(m)); k++)
                    {
                        R[i, j] += koff * signal[k] * signal[k + m];
                    }
                }
            }

            // Сингулярное разложение АКМ:
            double[,] U, V;
            var sigma = Functions.SVD(R, out U, out V);

            EVA = new Double[P];
            EFL = new Double[P][];
            EFR = new Double[P][];

            for (int k = 0; k < P; k++)
            {
                EVA[k] = sigma[k,k];
                EFL[k] = new Double[P];
                EFR[k] = new Double[P];
                for (int m = 0; m < P; m++)
                {
                    EFL[k][m] = U[m, k];
                    EFR[k][m] = V[m, k];
                }
            }

            numericUpDownBF.Maximum = P - 1;
            numericUpDownBF.Value = 0;
            numericUpDownEV.Maximum = P;
            numericUpDownEV.Value = P;
            numericUpDownBF_ValueChanged(null,null);
            numericUpDownEV_ValueChanged(null, null);
        }
    }
}
