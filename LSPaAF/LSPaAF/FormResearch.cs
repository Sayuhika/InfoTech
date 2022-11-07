using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSPaAF
{
    public partial class FormResearch : Form
    {
        FormData formData;

        double SNRmax, SNRmin, accuracy;
        int dotesCount, iteratesCount, testsCount;
        double[] signalData, impSigData, convolutionData, devValuesData;

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarResearch.Value = e.ProgressPercentage + 1;
            Functions.DrawGraphResearch(chartResearchGraph, devValuesData, SNRmax, SNRmin);
        }

        // Объявление потоков для расчёта точек
        Task<double[]>[] threadsDataPointsCalculator;

        public FormResearch()
        {
            InitializeComponent();
            formData = new FormData();
        }

        private void buttonSignalSetup_Click(object sender, EventArgs e)
        {
            formData.groupBoxNoise.Visible = false;
            formData.ShowDialog(); 
        }

        private void buttonResearchStartStop_Click(object sender, EventArgs e)
        {
            buttonSignalSetup.Enabled = false;
            buttonResearchStartStop.Enabled = false;

            SNRmax = double.Parse(textBoxResearchSNRMax.Text);
            SNRmin = double.Parse(textBoxResearchSNRMin.Text);
            dotesCount = int.Parse(textBoxResearchMaxDotes.Text);
            accuracy = double.Parse(textBoxResearchAccuracy.Text);
            iteratesCount = int.Parse(textBoxResearchMaxIterates.Text);
            testsCount = int.Parse(textBoxResearchTestsCount.Text);           

            //============================================================================================================
            // Начальная инициализация всех сигналов 
            //============================================================================================================

            // Длинна сигналов // Число отсчетов
            int SigLen = formData.signalLength;

            // Создаем отсчеты сигнала из Гауссовских куполов
            signalData = new double[SigLen];

            for (int i = 0; i < SigLen; i++)
            {

                double GS1 = formData.amplitudeGC1 * Math.Exp(-0.5 * (i - formData.meanGC1) * (i - formData.meanGC1) / (formData.deviationGC1 * formData.deviationGC1));
                double GS2 = formData.amplitudeGC2 * Math.Exp(-0.5 * (i - formData.meanGC2) * (i - formData.meanGC2) / (formData.deviationGC2 * formData.deviationGC2));
                double GS3 = formData.amplitudeGC3 * Math.Exp(-0.5 * (i - formData.meanGC3) * (i - formData.meanGC3) / (formData.deviationGC3 * formData.deviationGC3));

                signalData[i] = GS1 + GS2 + GS3;
            }

            // Создаем случайные отсчеты импульсной характеристики
            impSigData = new double[SigLen];
            Random rand = new Random();

            double ImpSigAmp = 1;
            //double ImpSigDev = rand.NextDouble() * SigLen / 4;
            double ImpSigDev = 4;
            for (int i = 0; i < SigLen; i++)
            {
                impSigData[i] = ImpSigAmp * Math.Exp(-0.5 * (i) * (i) / (ImpSigDev * ImpSigDev)) + ImpSigAmp * Math.Exp(-0.5 * (i - SigLen + 1) * (i - SigLen + 1) / (ImpSigDev * ImpSigDev));
            }

            // Создаем отсчеты свертки
            convolutionData = Functions.Convolution(signalData, impSigData);

            // Начинаем эксперементы
            progressBarResearch.Maximum = dotesCount;
            progressBarResearch.Value = 0;

            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //============================================================================================================
            // Запуск обработки сигналов и проведение экспериментов 
            //============================================================================================================
            devValuesData = new double[dotesCount];

            for(int k = 0; k < dotesCount; k++)
            {
                double SNR = SNRmin + k * (SNRmax - SNRmin) / (dotesCount - 1);

                var noisyData = new double[convolutionData.Length];
                // Накладываем шум на свертку
                double energyCoeff = 0;

                for (int i = 0; i < convolutionData.Length; i++)
                {
                    energyCoeff += convolutionData[i] * convolutionData[i];
                }

                energyCoeff *= Math.Pow(10, -0.1 * SNR) / convolutionData.Length;
                Random rand = new Random();

                for (int i = 0; i < convolutionData.Length; i++)
                {
                    double noise = 0;

                    for (int j = 0; j < 20; j++)
                    {
                        noise += rand.NextDouble();
                    }

                    noisyData[i] = convolutionData[i] + energyCoeff * (noise - 10) / 20;
                }

                threadsDataPointsCalculator = new Task<double[]>[testsCount];
                var HJMprocessor = new HJM[testsCount];
                
                for (int l = 0; l < testsCount; l++)
                {
                    HJMprocessor[l] = new HJM();
                    HJMprocessor[l].accuracy = accuracy;
                    HJMprocessor[l].maxIterates = iteratesCount;
                    HJMprocessor[l].impSigData = signalData;
                    HJMprocessor[l].convolutionData = noisyData;

                    HJMprocessor[l].Init(rand.Next());
                    threadsDataPointsCalculator[l] = Task.Factory.StartNew(Functions.threadJob, HJMprocessor[l]);
                };
                
                Task.WaitAll(threadsDataPointsCalculator);

                devValuesData[k] = 0;
                for (int i = 0; i < testsCount; i++)
                {
                    devValuesData[k] += Functions.Deviation(impSigData, threadsDataPointsCalculator[i].Result);
                }

                devValuesData[k] /= testsCount;
                backgroundWorker.ReportProgress(k);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Functions.DrawGraphResearch(chartResearchGraph, devValuesData, SNRmax, SNRmin);
            buttonSignalSetup.Enabled = true;
            buttonResearchStartStop.Enabled = true;
        }
    }
}
