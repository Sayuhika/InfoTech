namespace LSPaAF
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.groupBoxSignal = new System.Windows.Forms.GroupBox();
            this.chartSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxImpSig = new System.Windows.Forms.GroupBox();
            this.chartImpSig = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxConvolution = new System.Windows.Forms.GroupBox();
            this.chartConvolution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonOpenFormData = new System.Windows.Forms.Button();
            this.buttonReseach = new System.Windows.Forms.Button();
            this.buttonFindImpSig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxImpSigDev = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxFunctional = new System.Windows.Forms.TextBox();
            this.groupBoxSignal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).BeginInit();
            this.groupBoxImpSig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartImpSig)).BeginInit();
            this.groupBoxConvolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartConvolution)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSignal
            // 
            this.groupBoxSignal.Controls.Add(this.chartSignal);
            this.groupBoxSignal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSignal.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSignal.Name = "groupBoxSignal";
            this.groupBoxSignal.Size = new System.Drawing.Size(1199, 273);
            this.groupBoxSignal.TabIndex = 0;
            this.groupBoxSignal.TabStop = false;
            this.groupBoxSignal.Text = "Сигнал";
            // 
            // chartSignal
            // 
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.Title = "Отсчеты";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Title = "Значение";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this.chartSignal.ChartAreas.Add(chartArea1);
            this.chartSignal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSignal.Location = new System.Drawing.Point(3, 16);
            this.chartSignal.Name = "chartSignal";
            this.chartSignal.Size = new System.Drawing.Size(1193, 254);
            this.chartSignal.TabIndex = 2;
            this.chartSignal.Text = "chart1";
            // 
            // groupBoxImpSig
            // 
            this.groupBoxImpSig.Controls.Add(this.chartImpSig);
            this.groupBoxImpSig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxImpSig.Location = new System.Drawing.Point(3, 282);
            this.groupBoxImpSig.Name = "groupBoxImpSig";
            this.groupBoxImpSig.Size = new System.Drawing.Size(1199, 273);
            this.groupBoxImpSig.TabIndex = 1;
            this.groupBoxImpSig.TabStop = false;
            this.groupBoxImpSig.Text = "Импульсная характеристика";
            // 
            // chartImpSig
            // 
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.Title = "Отсчеты";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.Title = "Значение";
            chartArea2.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.Name = "ChartArea1";
            this.chartImpSig.ChartAreas.Add(chartArea2);
            this.chartImpSig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartImpSig.Location = new System.Drawing.Point(3, 16);
            this.chartImpSig.Name = "chartImpSig";
            this.chartImpSig.Size = new System.Drawing.Size(1193, 254);
            this.chartImpSig.TabIndex = 1;
            this.chartImpSig.Text = "chart1";
            // 
            // groupBoxConvolution
            // 
            this.groupBoxConvolution.Controls.Add(this.chartConvolution);
            this.groupBoxConvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConvolution.Location = new System.Drawing.Point(3, 561);
            this.groupBoxConvolution.Name = "groupBoxConvolution";
            this.groupBoxConvolution.Size = new System.Drawing.Size(1199, 273);
            this.groupBoxConvolution.TabIndex = 2;
            this.groupBoxConvolution.TabStop = false;
            this.groupBoxConvolution.Text = "Свертка";
            // 
            // chartConvolution
            // 
            chartArea3.AxisX.LineWidth = 2;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.Title = "Отсчеты";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.AxisY.LineWidth = 2;
            chartArea3.AxisY.MinorGrid.Interval = double.NaN;
            chartArea3.AxisY.MinorGrid.IntervalOffset = double.NaN;
            chartArea3.AxisY.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY.Title = "Значение";
            chartArea3.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.Name = "ChartArea1";
            this.chartConvolution.ChartAreas.Add(chartArea3);
            this.chartConvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartConvolution.Location = new System.Drawing.Point(3, 16);
            this.chartConvolution.Name = "chartConvolution";
            this.chartConvolution.Size = new System.Drawing.Size(1193, 254);
            this.chartConvolution.TabIndex = 2;
            this.chartConvolution.Text = "chart1";
            // 
            // buttonOpenFormData
            // 
            this.buttonOpenFormData.Location = new System.Drawing.Point(3, 3);
            this.buttonOpenFormData.Name = "buttonOpenFormData";
            this.buttonOpenFormData.Size = new System.Drawing.Size(247, 39);
            this.buttonOpenFormData.TabIndex = 3;
            this.buttonOpenFormData.Text = "Открыть настройку начальных данных";
            this.buttonOpenFormData.UseVisualStyleBackColor = true;
            this.buttonOpenFormData.Click += new System.EventHandler(this.buttonOpenFormData_Click);
            // 
            // buttonReseach
            // 
            this.buttonReseach.Location = new System.Drawing.Point(948, 3);
            this.buttonReseach.Name = "buttonReseach";
            this.buttonReseach.Size = new System.Drawing.Size(247, 39);
            this.buttonReseach.TabIndex = 4;
            this.buttonReseach.Text = "Провести исследование";
            this.buttonReseach.UseVisualStyleBackColor = true;
            this.buttonReseach.Click += new System.EventHandler(this.buttonReseach_Click);
            // 
            // buttonFindImpSig
            // 
            this.buttonFindImpSig.Location = new System.Drawing.Point(256, 3);
            this.buttonFindImpSig.Name = "buttonFindImpSig";
            this.buttonFindImpSig.Size = new System.Drawing.Size(338, 39);
            this.buttonFindImpSig.TabIndex = 5;
            this.buttonFindImpSig.Text = "Восстановить импульсную характеристику (Старт)";
            this.buttonFindImpSig.UseVisualStyleBackColor = true;
            this.buttonFindImpSig.Click += new System.EventHandler(this.buttonFindImpSig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCount);
            this.groupBox1.Location = new System.Drawing.Point(600, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 39);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Число итераций:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(6, 13);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxCount.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxImpSig, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxSignal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxConvolution, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1205, 888);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonOpenFormData);
            this.flowLayoutPanel1.Controls.Add(this.buttonFindImpSig);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.buttonReseach);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 840);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1199, 45);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxImpSigDev);
            this.groupBox2.Location = new System.Drawing.Point(716, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 39);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отклонение:";
            // 
            // textBoxImpSigDev
            // 
            this.textBoxImpSigDev.Location = new System.Drawing.Point(6, 13);
            this.textBoxImpSigDev.Name = "textBoxImpSigDev";
            this.textBoxImpSigDev.ReadOnly = true;
            this.textBoxImpSigDev.Size = new System.Drawing.Size(100, 20);
            this.textBoxImpSigDev.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxFunctional);
            this.groupBox3.Location = new System.Drawing.Point(832, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 39);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Функционал:";
            // 
            // textBoxFunctional
            // 
            this.textBoxFunctional.Location = new System.Drawing.Point(6, 13);
            this.textBoxFunctional.Name = "textBoxFunctional";
            this.textBoxFunctional.ReadOnly = true;
            this.textBoxFunctional.Size = new System.Drawing.Size(100, 20);
            this.textBoxFunctional.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 888);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Идентификация параметров линейной системы на основе адаптивного фильтра";
            this.groupBoxSignal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).EndInit();
            this.groupBoxImpSig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartImpSig)).EndInit();
            this.groupBoxConvolution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartConvolution)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSignal;
        private System.Windows.Forms.GroupBox groupBoxImpSig;
        private System.Windows.Forms.GroupBox groupBoxConvolution;
        private System.Windows.Forms.Button buttonOpenFormData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartImpSig;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConvolution;
        private System.Windows.Forms.Button buttonReseach;
        private System.Windows.Forms.Button buttonFindImpSig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSignal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxImpSigDev;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxFunctional;
    }
}

