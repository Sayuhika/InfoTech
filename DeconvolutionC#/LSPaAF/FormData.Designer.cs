namespace LSPaAF
{
    partial class FormData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBoxNoise = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxSNR = new System.Windows.Forms.TextBox();
            this.checkBoxNoiseMode = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTAU = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSigLength = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDeviation3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMean3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAmplitude3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDeviation1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMean1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAmplitude1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDeviation2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMean2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAmplitude2 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxImpSigDev = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxImpSigAmpl = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.groupBoxNoise.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSaveData.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.buttonSaveData.FlatAppearance.BorderSize = 3;
            this.buttonSaveData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.buttonSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveData.Location = new System.Drawing.Point(575, 184);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(164, 75);
            this.buttonSaveData.TabIndex = 19;
            this.buttonSaveData.Text = "Применить";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBoxNoise);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.textBoxTAU);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.textBoxSigLength);
            this.groupBox5.Location = new System.Drawing.Point(200, 174);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(369, 94);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дополнительно";
            // 
            // groupBoxNoise
            // 
            this.groupBoxNoise.Controls.Add(this.groupBox6);
            this.groupBoxNoise.Controls.Add(this.checkBoxNoiseMode);
            this.groupBoxNoise.Location = new System.Drawing.Point(184, 19);
            this.groupBoxNoise.Name = "groupBoxNoise";
            this.groupBoxNoise.Size = new System.Drawing.Size(169, 66);
            this.groupBoxNoise.TabIndex = 17;
            this.groupBoxNoise.TabStop = false;
            this.groupBoxNoise.Text = "Шум";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxSNR);
            this.groupBox6.Location = new System.Drawing.Point(87, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(72, 39);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ОСШ (дБ):";
            // 
            // textBoxSNR
            // 
            this.textBoxSNR.Location = new System.Drawing.Point(6, 13);
            this.textBoxSNR.Name = "textBoxSNR";
            this.textBoxSNR.ReadOnly = true;
            this.textBoxSNR.Size = new System.Drawing.Size(59, 20);
            this.textBoxSNR.TabIndex = 7;
            this.textBoxSNR.Text = "10";
            // 
            // checkBoxNoiseMode
            // 
            this.checkBoxNoiseMode.AutoSize = true;
            this.checkBoxNoiseMode.Location = new System.Drawing.Point(6, 32);
            this.checkBoxNoiseMode.Name = "checkBoxNoiseMode";
            this.checkBoxNoiseMode.Size = new System.Drawing.Size(75, 17);
            this.checkBoxNoiseMode.TabIndex = 10;
            this.checkBoxNoiseMode.Text = "Включить";
            this.checkBoxNoiseMode.UseVisualStyleBackColor = true;
            this.checkBoxNoiseMode.CheckedChanged += new System.EventHandler(this.checkBoxNoiseMode_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 27);
            this.label11.TabIndex = 15;
            this.label11.Text = "Точность:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTAU
            // 
            this.textBoxTAU.Location = new System.Drawing.Point(129, 56);
            this.textBoxTAU.Name = "textBoxTAU";
            this.textBoxTAU.Size = new System.Drawing.Size(49, 20);
            this.textBoxTAU.TabIndex = 14;
            this.textBoxTAU.Text = "1e-9";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 27);
            this.label10.TabIndex = 13;
            this.label10.Text = "Длина сигнала:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSigLength
            // 
            this.textBoxSigLength.Location = new System.Drawing.Point(129, 29);
            this.textBoxSigLength.Name = "textBoxSigLength";
            this.textBoxSigLength.Size = new System.Drawing.Size(49, 20);
            this.textBoxSigLength.TabIndex = 12;
            this.textBoxSigLength.Text = "50";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(727, 156);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры формы сигнала";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxDeviation3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBoxMean3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBoxAmplitude3);
            this.groupBox3.Location = new System.Drawing.Point(486, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 125);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Гауссовский купол 3";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 27);
            this.label7.TabIndex = 5;
            this.label7.Text = "Среднеквадратичное отклонение:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDeviation3
            // 
            this.textBoxDeviation3.Location = new System.Drawing.Point(123, 90);
            this.textBoxDeviation3.Name = "textBoxDeviation3";
            this.textBoxDeviation3.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeviation3.TabIndex = 4;
            this.textBoxDeviation3.Text = "4";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 27);
            this.label8.TabIndex = 3;
            this.label8.Text = "Математическое ожидание:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMean3
            // 
            this.textBoxMean3.Location = new System.Drawing.Point(123, 55);
            this.textBoxMean3.Name = "textBoxMean3";
            this.textBoxMean3.Size = new System.Drawing.Size(100, 20);
            this.textBoxMean3.TabIndex = 2;
            this.textBoxMean3.Text = "40";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Амплитуда:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAmplitude3
            // 
            this.textBoxAmplitude3.Location = new System.Drawing.Point(123, 19);
            this.textBoxAmplitude3.Name = "textBoxAmplitude3";
            this.textBoxAmplitude3.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmplitude3.TabIndex = 0;
            this.textBoxAmplitude3.Text = "4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDeviation1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxMean1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxAmplitude1);
            this.groupBox1.Location = new System.Drawing.Point(6, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 125);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Гауссовский купол 1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Среднеквадратичное отклонение:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDeviation1
            // 
            this.textBoxDeviation1.Location = new System.Drawing.Point(123, 90);
            this.textBoxDeviation1.Name = "textBoxDeviation1";
            this.textBoxDeviation1.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeviation1.TabIndex = 4;
            this.textBoxDeviation1.Text = "6";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Математическое ожидание:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMean1
            // 
            this.textBoxMean1.Location = new System.Drawing.Point(123, 55);
            this.textBoxMean1.Name = "textBoxMean1";
            this.textBoxMean1.Size = new System.Drawing.Size(100, 20);
            this.textBoxMean1.TabIndex = 2;
            this.textBoxMean1.Text = "15";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Амплитуда:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAmplitude1
            // 
            this.textBoxAmplitude1.Location = new System.Drawing.Point(123, 19);
            this.textBoxAmplitude1.Name = "textBoxAmplitude1";
            this.textBoxAmplitude1.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmplitude1.TabIndex = 0;
            this.textBoxAmplitude1.Text = "3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxDeviation2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxMean2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxAmplitude2);
            this.groupBox2.Location = new System.Drawing.Point(246, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 125);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Гауссовский купол 2";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Среднеквадратичное отклонение:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDeviation2
            // 
            this.textBoxDeviation2.Location = new System.Drawing.Point(123, 90);
            this.textBoxDeviation2.Name = "textBoxDeviation2";
            this.textBoxDeviation2.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeviation2.TabIndex = 4;
            this.textBoxDeviation2.Text = "2";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "Математическое ожидание:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMean2
            // 
            this.textBoxMean2.Location = new System.Drawing.Point(123, 55);
            this.textBoxMean2.Name = "textBoxMean2";
            this.textBoxMean2.Size = new System.Drawing.Size(100, 20);
            this.textBoxMean2.TabIndex = 2;
            this.textBoxMean2.Text = "30";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Амплитуда:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAmplitude2
            // 
            this.textBoxAmplitude2.Location = new System.Drawing.Point(123, 19);
            this.textBoxAmplitude2.Name = "textBoxAmplitude2";
            this.textBoxAmplitude2.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmplitude2.TabIndex = 0;
            this.textBoxAmplitude2.Text = "2";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.textBoxImpSigDev);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.textBoxImpSigAmpl);
            this.groupBox7.Location = new System.Drawing.Point(12, 174);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(182, 92);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Параметры фильтра";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 27);
            this.label12.TabIndex = 5;
            this.label12.Text = "Среднеквадратичное отклонение:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxImpSigDev
            // 
            this.textBoxImpSigDev.Location = new System.Drawing.Point(123, 56);
            this.textBoxImpSigDev.Name = "textBoxImpSigDev";
            this.textBoxImpSigDev.Size = new System.Drawing.Size(45, 20);
            this.textBoxImpSigDev.TabIndex = 4;
            this.textBoxImpSigDev.Text = "2";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Амплитуда:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxImpSigAmpl
            // 
            this.textBoxImpSigAmpl.Location = new System.Drawing.Point(123, 19);
            this.textBoxImpSigAmpl.Name = "textBoxImpSigAmpl";
            this.textBoxImpSigAmpl.Size = new System.Drawing.Size(45, 20);
            this.textBoxImpSigAmpl.TabIndex = 0;
            this.textBoxImpSigAmpl.Text = "1";
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 275);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Name = "FormData";
            this.Text = "Параметры входного сигнала";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxNoise.ResumeLayout(false);
            this.groupBoxNoise.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TextBox textBoxSNR;
        public System.Windows.Forms.CheckBox checkBoxNoiseMode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxTAU;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSigLength;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDeviation3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMean3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAmplitude3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDeviation1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMean1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAmplitude1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDeviation2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMean2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAmplitude2;
        public System.Windows.Forms.GroupBox groupBoxNoise;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxImpSigDev;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxImpSigAmpl;
    }
}