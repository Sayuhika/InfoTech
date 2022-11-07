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
    public partial class FormData : Form
    {
        public double amplitudeGC1 { get { return double.Parse(textBoxAmplitude1.Text); } }
        public double amplitudeGC2 { get { return double.Parse(textBoxAmplitude2.Text); } }
        public double amplitudeGC3 { get { return double.Parse(textBoxAmplitude3.Text); } }
        public double meanGC1 { get { return double.Parse(textBoxMean1.Text); } }
        public double meanGC2 { get { return double.Parse(textBoxMean2.Text); } }
        public double meanGC3 { get { return double.Parse(textBoxMean3.Text); } }
        public double deviationGC1 { get { return double.Parse(textBoxDeviation1.Text); } }
        public double deviationGC2 { get { return double.Parse(textBoxDeviation2.Text); } }
        public double deviationGC3 { get { return double.Parse(textBoxDeviation3.Text); } }
        public double accuracy { get { return double.Parse(textBoxTAU.Text); } }
        public int signalLength { get { return int.Parse(textBoxSigLength.Text); } }
        public double SNR { get { return double.Parse(textBoxSNR.Text); } }
        public bool noiseMode { get { return checkBoxNoiseMode.Checked; } }

        public FormData()
        {
            InitializeComponent();
        }

        private void checkBoxNoiseMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoiseMode.Checked)
            {
                textBoxSNR.ReadOnly = false;
            }
            else
            {
                textBoxSNR.ReadOnly = true;
            }
        }
    }
}
