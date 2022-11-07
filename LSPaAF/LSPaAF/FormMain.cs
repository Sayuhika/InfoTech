﻿using System;
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
    public partial class FormMain : Form
    { 
        bool isBusy = false;
        double[] signalData;
        double[] impSigData;
        double[] convolutionData;
        private FormData formData;
        private HJM HJMprocessor;
        public FormMain()
        {
            InitializeComponent();
            formData = new FormData();
        }
        private void setSettings()
        {
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

            // Накладываем шум
            if (formData.noiseMode)
            {
                double energyCoeff = 0;
                // Считаем энергию сигнала
                for (int i = 0; i < convolutionData.Length; i++)
                {
                    energyCoeff += convolutionData[i] * convolutionData[i];
                }

                energyCoeff *=Math.Pow(10, -0.1 * formData.SNR) / convolutionData.Length;

                for (int i = 0; i < convolutionData.Length; i++)
                {
                    double noise = 0;

                    for (int j = 0; j < 20; j++)
                    {
                        noise += rand.NextDouble();
                    }

                    convolutionData[i] += (noise - 10) / 20 * energyCoeff;
                }
            }

            // Начальная отрисовка графиков
            Functions.DrawGraphs(chartSignal, signalData);
            Functions.DrawGraphs(chartImpSig, impSigData);
            Functions.DrawGraphs(chartConvolution, convolutionData);
        }


        // Обработка кнопоки "Открыть настройку начальных данных"
        private void buttonOpenFormData_Click(object sender, EventArgs e)
        {
            if (formData.ShowDialog() == DialogResult.OK)
            {
                setSettings();
            }
        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var recSig = HJM.RecSignal(e.UserState as double[],signalData);
            Functions.DrawGraphs(chartImpSig, impSigData, recSig);
            Functions.DrawGraphs(chartConvolution, convolutionData, Functions.Convolution(signalData, recSig));
            textBoxImpSigDev.Text = Functions.Deviation(impSigData, recSig).ToString();
            textBoxFunctional.Text = HJM.Functional(e.UserState as double[], signalData, convolutionData).ToString();
        }
        private void IC(object sender, RunWorkerCompletedEventArgs e)
        {
            var impSigValues = HJMprocessor.GetRecSignal();

            Functions.DrawGraphs(chartImpSig, impSigData, impSigValues);
            Functions.DrawGraphs(chartConvolution, convolutionData, Functions.Convolution(signalData, HJMprocessor.GetRecSignal()));

            if ((bool)e.Result||!isBusy)
            {
                isBusy = false;
                buttonFindImpSig.Text = "Восстановить импульсную характеристику (Старт)";
                buttonFindImpSig.Enabled = true;
                Functions.DrawGraphs(chartImpSig, impSigData, HJMprocessor.GetRecSignal());
                Functions.DrawGraphs(chartConvolution, convolutionData, Functions.Convolution(signalData, HJMprocessor.GetRecSignal()));
                textBoxCount.Text = HJMprocessor.counter.ToString();
            }  
            else
            {
                HJMprocessor.RunWorkerAsync();
            }
            textBoxCount.Text = HJMprocessor.counter.ToString();
            textBoxImpSigDev.Text = Functions.Deviation(impSigData, HJMprocessor.GetRecSignal()).ToString();
            textBoxFunctional.Text = HJMprocessor.currDeviation.ToString();
            Update();
        }


        // Обработка кнопки "Восстановить импульсную характеристику"
        private void buttonFindImpSig_Click(object sender, EventArgs e)
        {
            isBusy = !isBusy;
            Random rand = new Random();
            if (!isBusy)
            {
                HJMprocessor.CancelAsync();
                buttonFindImpSig.Enabled = false;
            }
            else
            {
                setSettings();
                HJMprocessor = new HJM();
                HJMprocessor.ProgressChanged += ProgressChanged;
                HJMprocessor.RunWorkerCompleted += IC;
                HJMprocessor.accuracy = formData.accuracy;
                HJMprocessor.impSigData = signalData;
                HJMprocessor.convolutionData = convolutionData;
                HJMprocessor.Init(rand.Next());
                HJMprocessor.RunWorkerAsync();
                buttonFindImpSig.Text = "Восстановить импульсную характеристику (Стоп)";
            }
        }

        // Обработка кнопки "Провести исследование"
        private void buttonReseach_Click(object sender, EventArgs e)
        {
            var form = new FormResearch();
            form.ShowDialog();
        }
    }
}
