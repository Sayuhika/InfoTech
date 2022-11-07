using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Numerics;

namespace PhaseProblemFienup
{
    public partial class FormMain : Form
    {
        double accuracy;
        bool isBusy = false;
        private FormData formData;
        private Fienup fienupProcess;
        Complex[] signalData;
        Complex[] signalDataRepair;
        Complex[] phaseData;
        Complex[] ampSpectreData;
        public FormMain()
        {
            InitializeComponent();
            formData = new FormData();
        }

        private void drowFunction(Chart chart, short mode, params Complex[][] data)
        {
            chart.Series.Clear();

            for (int j = 0; j < data.Length; j++)
            {
                Series newSeries = new Series("");

                for (int i = 0; i < data[0].Length; i++)
                {
                    switch (mode)
                    {
                        case 0:
                            newSeries.Points.AddXY(i, data[j][i].Real);
                            break;
                        case 1:
                            newSeries.Points.AddXY(i, data[j][i].Imaginary);
                            break;
                        case 2:
                            newSeries.Points.AddXY(i, data[j][i].Magnitude);
                            break;
                        case 3:
                            newSeries.Points.AddXY(i, data[j][i].Phase);
                            break;
                    }
                }

                newSeries.ChartType = SeriesChartType.Line;
                chart.Series.Add(newSeries);
            }
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = data[0].Length - 1;
        }
        private void buttonSetData_Click(object sender, EventArgs e)
        {
            if (formData.ShowDialog() == DialogResult.OK)
            {
                signalData = new Complex[formData.signalLength];
                double EnergyKoff = 0;

                for (int i = 0; i < formData.signalLength; i++)
                {

                    double GS1 = formData.amplitudeGC1 * Math.Exp(-0.5 * (i - formData.meanGC1) * (i - formData.meanGC1) / (formData.deviationGC1 * formData.deviationGC1));
                    double GS2 = formData.amplitudeGC2 * Math.Exp(-0.5 * (i - formData.meanGC2) * (i - formData.meanGC2) / (formData.deviationGC2 * formData.deviationGC2));
                    double GS3 = formData.amplitudeGC3 * Math.Exp(-0.5 * (i - formData.meanGC3) * (i - formData.meanGC3) / (formData.deviationGC3 * formData.deviationGC3));

                    signalData[i] = GS1 + GS2 + GS3;
                }

                // Амплитудный спектр
                ampSpectreData = Fourier.FFourier(signalData, true);

                // Энергия спектра
                for (int i = 0; i < formData.signalLength; i++)
                {
                    EnergyKoff += ampSpectreData[i].Magnitude * ampSpectreData[i].Magnitude;
                }

                    if (formData.checkBoxNoiseMode.Checked)
                {
                    Random rand = new Random();
                    double sumRE = 0;
                    double sumIM = 0;
                    Complex noiseValue;
                    EnergyKoff = EnergyKoff * Convert.ToDouble(formData.textBoxNoisePercentage.Text) / 100 / formData.signalLength;
                    for (int i = 0; i < formData.signalLength; i++)
                    {
                        // Генерация шума
                        sumRE = sumIM = 0;

                        for (int j = 0; j < 12; j++) {
                            sumRE += rand.NextDouble();
                            sumIM += rand.NextDouble();
                        };

                        noiseValue = (sumRE / (12) - 0.5)  + (sumIM / (12) - 0.5)*Complex.ImaginaryOne;

                        ampSpectreData[i] = ampSpectreData[i] + noiseValue * EnergyKoff;
                    }
                }
                // Начальная отрисовка данных
                drowFunction(chartSignal, 0, signalData);
                drowFunction(chartAmpSpectr, 2, ampSpectreData);
            }

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            isBusy = !isBusy;
            if (!isBusy)
            {
                timer.Stop();
                buttonAutoShift.Enabled = true;
                buttonReverse.Enabled = true;
            }
            else
            {
                buttonAutoShift.Enabled = false;
                buttonReverse.Enabled = false;

                signalData = new Complex[formData.signalLength];
                signalDataRepair = new Complex[formData.signalLength];
           
                double EnergyKoff = 0;

                for (int i = 0; i < formData.signalLength; i++)
                {

                    double GS1 = formData.amplitudeGC1 * Math.Exp(-0.5 * (i - formData.meanGC1) * (i - formData.meanGC1) / (formData.deviationGC1 * formData.deviationGC1));
                    double GS2 = formData.amplitudeGC2 * Math.Exp(-0.5 * (i - formData.meanGC2) * (i - formData.meanGC2) / (formData.deviationGC2 * formData.deviationGC2));
                    double GS3 = formData.amplitudeGC3 * Math.Exp(-0.5 * (i - formData.meanGC3) * (i - formData.meanGC3) / (formData.deviationGC3 * formData.deviationGC3));

                    signalData[i] = GS1 + GS2 + GS3;
                }

                // Амплитудный спектр
                ampSpectreData = Fourier.FFourier(signalData, true);

                // Энергия спектра
                for (int i = 0; i < formData.signalLength; i++)
                {
                    EnergyKoff += ampSpectreData[i].Magnitude * ampSpectreData[i].Magnitude;
                }

                if (formData.checkBoxNoiseMode.Checked)
                {
                    Random rand = new Random();
                    double sumRE = 0;
                    double sumIM = 0;
                    Complex noiseValue;
                    EnergyKoff = EnergyKoff * Convert.ToDouble(formData.textBoxNoisePercentage.Text) / 100 / formData.signalLength;
                    for (int i = 0; i < formData.signalLength; i++)
                    {
                        // Генерация шума
                        sumRE = sumIM = 0;

                        for (int j = 0; j < 12; j++)
                        {
                            sumRE += rand.NextDouble();
                            sumIM += rand.NextDouble();
                        };

                        noiseValue = (sumRE / (12) - 0.5) + (sumIM / (12) - 0.5) * Complex.ImaginaryOne;

                        ampSpectreData[i] = ampSpectreData[i] + noiseValue * EnergyKoff;
                    }
                }

                signalData.CopyTo(signalDataRepair, 0);
                ampSpectreData = Fourier.FFourier(signalDataRepair, true);

                fienupProcess = new Fienup();
                fienupProcess.init(ampSpectreData);
                accuracy = 1;
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int count = 0;
            while (count < 20)
            {
                accuracy = fienupProcess.iterate(ref signalDataRepair, ref phaseData);

                drowFunction(chartSignal, 0, signalData, signalDataRepair);
                drowFunction(chartPhaseSpectr, 0, phaseData);
                textBoxCount.Text = fienupProcess.count.ToString();

                if (accuracy < formData.accuracy)
                {
                    timer.Stop();
                    buttonAutoShift.Enabled = true;
                    buttonReverse.Enabled = true;
                    isBusy = false;
                    break;
                }

                count++;
            }  
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            Complex[] signalDataRepairReverse = new Complex[signalDataRepair.Length];

            for (int i = 0; i < signalDataRepair.Length; i++)
            {
                signalDataRepairReverse[i] = signalDataRepair[signalDataRepair.Length - i - 1];
            }

            signalDataRepair = signalDataRepairReverse;

            drowFunction(chartSignal, 0, signalData, signalDataRepair);
        }

        private void buttonAutoShift_Click(object sender, EventArgs e)
        {
            double minDev = double.PositiveInfinity;
            int minI = 0;

            for (int i = 0; i < signalData.Length; i++)
            {
                double curDev = 0;

                for (int j = 0; j < signalData.Length; j++)
                {
                    curDev += (signalData[j].Real - signalDataRepair[(j + i) % signalData.Length].Real) * (signalData[j].Real - signalDataRepair[(j + i) % signalData.Length].Real);
                }

                if (curDev < minDev)
                {
                    minDev = curDev;
                    minI = i;
                }
            }

            Complex[] signalDataRepairShift = new Complex[signalDataRepair.Length];

            for (int i = 0; i < signalData.Length; i++)
            {
                signalDataRepairShift[i] = signalDataRepair[(i + minI) % signalDataRepair.Length];
            }

            signalDataRepair = signalDataRepairShift;
            drowFunction(chartSignal, 0, signalData, signalDataRepair);

            textBoxDev.Text = (minDev / signalDataRepair.Length).ToString();
        }
    }
}
