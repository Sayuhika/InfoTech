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
    public partial class FormSignalData : Form
    {
        public double paramA1 { get { return double.Parse(numericUpDownParamA1.Value.ToString()); } }
        public double paramA2 { get { return double.Parse(numericUpDownParamA2.Value.ToString()); } }
        public double paramA3 { get { return double.Parse(numericUpDownParamA3.Value.ToString()); } }
        public double paramB1 { get { return double.Parse(numericUpDownParamB1.Value.ToString()); } }
        public double paramB2 { get { return double.Parse(numericUpDownParamB2.Value.ToString()); } }
        public double paramB3 { get { return double.Parse(numericUpDownParamB3.Value.ToString()); } }
        public double paramC1 { get { return double.Parse(numericUpDownParamC1.Value.ToString()); } }
        public double paramC2 { get { return double.Parse(numericUpDownParamC2.Value.ToString()); } }
        public double paramC3 { get { return double.Parse(numericUpDownParamC3.Value.ToString()); } }
        public int signalLenght { get { return int.Parse(textBoxSigLength.Text.ToString()); } }

        public FormSignalData()
        {
            InitializeComponent();
        }
    }
}
