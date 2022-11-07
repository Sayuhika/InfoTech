namespace Basis_K_L
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNorma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMatrixGen = new System.Windows.Forms.Button();
            this.textBoxDiscrepancy = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMatrixN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMatrixM = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownEV = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownBF = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOpenFormData = new System.Windows.Forms.Button();
            this.buttonGenFunctions = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxSignalForm = new System.Windows.Forms.ComboBox();
            this.textBoxACMo = new System.Windows.Forms.TextBox();
            this.chartSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chartBasisFunc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chartEigenvalues = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dataGridViewVectorB = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dataGridViewVectorX = new System.Windows.Forms.DataGridView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMatrix = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDetA = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBF)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBasisFunc)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEigenvalues)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVectorB)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVectorX)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxDetA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxNorma);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonMatrixGen);
            this.groupBox1.Controls.Add(this.textBoxDiscrepancy);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 269);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проверка псевдообратной матрицы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Норма решения:";
            // 
            // textBoxNorma
            // 
            this.textBoxNorma.Location = new System.Drawing.Point(15, 177);
            this.textBoxNorma.Name = "textBoxNorma";
            this.textBoxNorma.Size = new System.Drawing.Size(184, 20);
            this.textBoxNorma.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Невязка:";
            // 
            // buttonMatrixGen
            // 
            this.buttonMatrixGen.Location = new System.Drawing.Point(6, 73);
            this.buttonMatrixGen.Name = "buttonMatrixGen";
            this.buttonMatrixGen.Size = new System.Drawing.Size(206, 30);
            this.buttonMatrixGen.TabIndex = 2;
            this.buttonMatrixGen.Text = "Сгенерировать матрицу";
            this.buttonMatrixGen.UseVisualStyleBackColor = true;
            this.buttonMatrixGen.Click += new System.EventHandler(this.buttonMatrixGen_Click);
            // 
            // textBoxDiscrepancy
            // 
            this.textBoxDiscrepancy.Location = new System.Drawing.Point(15, 127);
            this.textBoxDiscrepancy.Name = "textBoxDiscrepancy";
            this.textBoxDiscrepancy.Size = new System.Drawing.Size(184, 20);
            this.textBoxDiscrepancy.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxMatrixN);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxMatrixM);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры матрицы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "N:";
            // 
            // textBoxMatrixN
            // 
            this.textBoxMatrixN.Location = new System.Drawing.Point(128, 19);
            this.textBoxMatrixN.Name = "textBoxMatrixN";
            this.textBoxMatrixN.Size = new System.Drawing.Size(70, 20);
            this.textBoxMatrixN.TabIndex = 4;
            this.textBoxMatrixN.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "M:";
            // 
            // textBoxMatrixM
            // 
            this.textBoxMatrixM.Location = new System.Drawing.Point(28, 19);
            this.textBoxMatrixM.Name = "textBoxMatrixM";
            this.textBoxMatrixM.Size = new System.Drawing.Size(70, 20);
            this.textBoxMatrixM.TabIndex = 2;
            this.textBoxMatrixM.Text = "3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownEV);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numericUpDownBF);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonOpenFormData);
            this.groupBox3.Controls.Add(this.buttonGenFunctions);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.textBoxACMo);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 264);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Построение базиса";
            // 
            // numericUpDownEV
            // 
            this.numericUpDownEV.Location = new System.Drawing.Point(157, 226);
            this.numericUpDownEV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEV.Name = "numericUpDownEV";
            this.numericUpDownEV.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownEV.TabIndex = 12;
            this.numericUpDownEV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEV.ValueChanged += new System.EventHandler(this.numericUpDownEV_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 33);
            this.label8.TabIndex = 13;
            this.label8.Text = "Число отрисовываемых собственных значений";
            // 
            // numericUpDownBF
            // 
            this.numericUpDownBF.Location = new System.Drawing.Point(157, 193);
            this.numericUpDownBF.Name = "numericUpDownBF";
            this.numericUpDownBF.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownBF.TabIndex = 2;
            this.numericUpDownBF.ValueChanged += new System.EventHandler(this.numericUpDownBF_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 33);
            this.label6.TabIndex = 3;
            this.label6.Text = "Номер базисной функции отображаемой на графике";
            // 
            // buttonOpenFormData
            // 
            this.buttonOpenFormData.Location = new System.Drawing.Point(7, 73);
            this.buttonOpenFormData.Name = "buttonOpenFormData";
            this.buttonOpenFormData.Size = new System.Drawing.Size(206, 30);
            this.buttonOpenFormData.TabIndex = 11;
            this.buttonOpenFormData.Text = "Настройка параметров сигнала";
            this.buttonOpenFormData.UseVisualStyleBackColor = true;
            this.buttonOpenFormData.Click += new System.EventHandler(this.buttonOpenFormData_Click);
            // 
            // buttonGenFunctions
            // 
            this.buttonGenFunctions.Location = new System.Drawing.Point(6, 140);
            this.buttonGenFunctions.Name = "buttonGenFunctions";
            this.buttonGenFunctions.Size = new System.Drawing.Size(206, 30);
            this.buttonGenFunctions.TabIndex = 10;
            this.buttonGenFunctions.Text = "Построить базисные функции";
            this.buttonGenFunctions.UseVisualStyleBackColor = true;
            this.buttonGenFunctions.Click += new System.EventHandler(this.buttonGenFunctions_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Порядок АКМ:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxSignalForm);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 50);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Форма сигнала:";
            // 
            // comboBoxSignalForm
            // 
            this.comboBoxSignalForm.FormattingEnabled = true;
            this.comboBoxSignalForm.Items.AddRange(new object[] {
            "Гауссов",
            "Полигармонический",
            "Затухающий полигармонический"});
            this.comboBoxSignalForm.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSignalForm.Name = "comboBoxSignalForm";
            this.comboBoxSignalForm.Size = new System.Drawing.Size(192, 21);
            this.comboBoxSignalForm.TabIndex = 2;
            this.comboBoxSignalForm.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignalForm_SelectedIndexChanged);
            // 
            // textBoxACMo
            // 
            this.textBoxACMo.Location = new System.Drawing.Point(134, 114);
            this.textBoxACMo.Name = "textBoxACMo";
            this.textBoxACMo.Size = new System.Drawing.Size(70, 20);
            this.textBoxACMo.TabIndex = 6;
            this.textBoxACMo.Text = "350";
            // 
            // chartSignal
            // 
            chartArea10.Name = "ChartArea1";
            this.chartSignal.ChartAreas.Add(chartArea10);
            this.chartSignal.Location = new System.Drawing.Point(6, 19);
            this.chartSignal.Name = "chartSignal";
            this.chartSignal.Size = new System.Drawing.Size(1028, 195);
            this.chartSignal.TabIndex = 2;
            this.chartSignal.Text = "chartSignal";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chartSignal);
            this.groupBox5.Location = new System.Drawing.Point(229, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1040, 230);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "График сигнала";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chartBasisFunc);
            this.groupBox6.Location = new System.Drawing.Point(229, 242);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(515, 306);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "График базисной функции";
            // 
            // chartBasisFunc
            // 
            chartArea11.Name = "ChartArea1";
            this.chartBasisFunc.ChartAreas.Add(chartArea11);
            this.chartBasisFunc.Location = new System.Drawing.Point(6, 19);
            this.chartBasisFunc.Name = "chartBasisFunc";
            this.chartBasisFunc.Size = new System.Drawing.Size(503, 281);
            this.chartBasisFunc.TabIndex = 2;
            this.chartBasisFunc.Text = "chartSignal";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chartEigenvalues);
            this.groupBox7.Location = new System.Drawing.Point(754, 242);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(515, 306);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "График собственных значений";
            // 
            // chartEigenvalues
            // 
            chartArea12.Name = "ChartArea1";
            this.chartEigenvalues.ChartAreas.Add(chartArea12);
            this.chartEigenvalues.Location = new System.Drawing.Point(6, 19);
            this.chartEigenvalues.Name = "chartEigenvalues";
            this.chartEigenvalues.Size = new System.Drawing.Size(503, 281);
            this.chartEigenvalues.TabIndex = 2;
            this.chartEigenvalues.Text = "chartSignal";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1289, 584);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1281, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вычисление псевдообратной матрицы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dataGridViewVectorB);
            this.groupBox10.Location = new System.Drawing.Point(1139, 7);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(134, 268);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Вектор b";
            // 
            // dataGridViewVectorB
            // 
            this.dataGridViewVectorB.AllowUserToAddRows = false;
            this.dataGridViewVectorB.AllowUserToDeleteRows = false;
            this.dataGridViewVectorB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVectorB.ColumnHeadersVisible = false;
            this.dataGridViewVectorB.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewVectorB.Name = "dataGridViewVectorB";
            this.dataGridViewVectorB.RowHeadersVisible = false;
            this.dataGridViewVectorB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewVectorB.Size = new System.Drawing.Size(120, 243);
            this.dataGridViewVectorB.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(1037, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 108);
            this.label7.TabIndex = 4;
            this.label7.Text = "=";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dataGridViewVectorX);
            this.groupBox9.Location = new System.Drawing.Point(897, 7);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(134, 268);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Вектор x";
            // 
            // dataGridViewVectorX
            // 
            this.dataGridViewVectorX.AllowUserToAddRows = false;
            this.dataGridViewVectorX.AllowUserToDeleteRows = false;
            this.dataGridViewVectorX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVectorX.ColumnHeadersVisible = false;
            this.dataGridViewVectorX.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewVectorX.Name = "dataGridViewVectorX";
            this.dataGridViewVectorX.RowHeadersVisible = false;
            this.dataGridViewVectorX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewVectorX.Size = new System.Drawing.Size(120, 243);
            this.dataGridViewVectorX.TabIndex = 2;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridViewMatrix);
            this.groupBox8.Location = new System.Drawing.Point(236, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(655, 269);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Матрица А";
            // 
            // dataGridViewMatrix
            // 
            this.dataGridViewMatrix.AllowUserToAddRows = false;
            this.dataGridViewMatrix.AllowUserToDeleteRows = false;
            this.dataGridViewMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatrix.ColumnHeadersVisible = false;
            this.dataGridViewMatrix.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewMatrix.Name = "dataGridViewMatrix";
            this.dataGridViewMatrix.RowHeadersVisible = false;
            this.dataGridViewMatrix.Size = new System.Drawing.Size(643, 244);
            this.dataGridViewMatrix.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1281, 558);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Разложение по базису Карунена-Лоэва";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Определитель матрицы А:";
            // 
            // textBoxDetA
            // 
            this.textBoxDetA.Location = new System.Drawing.Point(15, 227);
            this.textBoxDetA.Name = "textBoxDetA";
            this.textBoxDetA.Size = new System.Drawing.Size(184, 20);
            this.textBoxDetA.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 584);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Text = "Построить базисные функции";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBF)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBasisFunc)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartEigenvalues)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVectorB)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVectorX)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNorma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMatrixGen;
        private System.Windows.Forms.TextBox textBoxDiscrepancy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMatrixN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMatrixM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownBF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOpenFormData;
        private System.Windows.Forms.Button buttonGenFunctions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxSignalForm;
        private System.Windows.Forms.TextBox textBoxACMo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSignal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBasisFunc;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEigenvalues;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dataGridViewVectorB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dataGridViewVectorX;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dataGridViewMatrix;
        private System.Windows.Forms.NumericUpDown numericUpDownEV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDetA;
    }
}

