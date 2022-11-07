namespace PhaseProblemFienup
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSetData = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxSignal = new System.Windows.Forms.GroupBox();
            this.groupBoxAmpSpectre = new System.Windows.Forms.GroupBox();
            this.chartAmpSpectr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxPhaseSpectre = new System.Windows.Forms.GroupBox();
            this.chartPhaseSpectr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReverse = new System.Windows.Forms.Button();
            this.buttonAutoShift = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDev = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).BeginInit();
            this.groupBoxSignal.SuspendLayout();
            this.groupBoxAmpSpectre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmpSpectr)).BeginInit();
            this.groupBoxPhaseSpectre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseSpectr)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartSignal
            // 
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chartSignal.ChartAreas.Add(chartArea1);
            this.chartSignal.Location = new System.Drawing.Point(10, 19);
            this.chartSignal.Name = "chartSignal";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.Name = "Series1";
            this.chartSignal.Series.Add(series1);
            this.chartSignal.Size = new System.Drawing.Size(1235, 238);
            this.chartSignal.TabIndex = 0;
            this.chartSignal.Text = "chart1";
            // 
            // buttonSetData
            // 
            this.buttonSetData.Location = new System.Drawing.Point(12, 825);
            this.buttonSetData.Name = "buttonSetData";
            this.buttonSetData.Size = new System.Drawing.Size(172, 39);
            this.buttonSetData.TabIndex = 1;
            this.buttonSetData.Text = "Ввести начальные данные";
            this.buttonSetData.UseVisualStyleBackColor = true;
            this.buttonSetData.Click += new System.EventHandler(this.buttonSetData_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(190, 825);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(172, 39);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Старт / Стоп";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxSignal
            // 
            this.groupBoxSignal.Controls.Add(this.chartSignal);
            this.groupBoxSignal.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSignal.Name = "groupBoxSignal";
            this.groupBoxSignal.Size = new System.Drawing.Size(1254, 265);
            this.groupBoxSignal.TabIndex = 3;
            this.groupBoxSignal.TabStop = false;
            this.groupBoxSignal.Text = "Сигнал";
            // 
            // groupBoxAmpSpectre
            // 
            this.groupBoxAmpSpectre.Controls.Add(this.chartAmpSpectr);
            this.groupBoxAmpSpectre.Location = new System.Drawing.Point(12, 283);
            this.groupBoxAmpSpectre.Name = "groupBoxAmpSpectre";
            this.groupBoxAmpSpectre.Size = new System.Drawing.Size(1254, 265);
            this.groupBoxAmpSpectre.TabIndex = 4;
            this.groupBoxAmpSpectre.TabStop = false;
            this.groupBoxAmpSpectre.Text = "Амплитудный спектр";
            // 
            // chartAmpSpectr
            // 
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.chartAmpSpectr.ChartAreas.Add(chartArea2);
            this.chartAmpSpectr.Location = new System.Drawing.Point(10, 19);
            this.chartAmpSpectr.Name = "chartAmpSpectr";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series2.Name = "Series1";
            this.chartAmpSpectr.Series.Add(series2);
            this.chartAmpSpectr.Size = new System.Drawing.Size(1235, 238);
            this.chartAmpSpectr.TabIndex = 0;
            this.chartAmpSpectr.Text = "chart1";
            // 
            // groupBoxPhaseSpectre
            // 
            this.groupBoxPhaseSpectre.Controls.Add(this.chartPhaseSpectr);
            this.groupBoxPhaseSpectre.Location = new System.Drawing.Point(12, 554);
            this.groupBoxPhaseSpectre.Name = "groupBoxPhaseSpectre";
            this.groupBoxPhaseSpectre.Size = new System.Drawing.Size(1254, 265);
            this.groupBoxPhaseSpectre.TabIndex = 5;
            this.groupBoxPhaseSpectre.TabStop = false;
            this.groupBoxPhaseSpectre.Text = "Фазовый спектр";
            // 
            // chartPhaseSpectr
            // 
            chartArea3.AxisX.LineWidth = 2;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.LineWidth = 2;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.Name = "ChartArea1";
            this.chartPhaseSpectr.ChartAreas.Add(chartArea3);
            this.chartPhaseSpectr.Location = new System.Drawing.Point(10, 19);
            this.chartPhaseSpectr.Name = "chartPhaseSpectr";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series3.Name = "Series1";
            this.chartPhaseSpectr.Series.Add(series3);
            this.chartPhaseSpectr.Size = new System.Drawing.Size(1235, 238);
            this.chartPhaseSpectr.TabIndex = 0;
            this.chartPhaseSpectr.Text = "chart1";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(6, 13);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxCount.TabIndex = 6;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCount);
            this.groupBox1.Location = new System.Drawing.Point(772, 825);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 39);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Число итераций:";
            // 
            // buttonReverse
            // 
            this.buttonReverse.Enabled = false;
            this.buttonReverse.Location = new System.Drawing.Point(1075, 836);
            this.buttonReverse.Name = "buttonReverse";
            this.buttonReverse.Size = new System.Drawing.Size(75, 23);
            this.buttonReverse.TabIndex = 8;
            this.buttonReverse.Text = "Реверс";
            this.buttonReverse.UseVisualStyleBackColor = true;
            this.buttonReverse.Click += new System.EventHandler(this.buttonReverse_Click);
            // 
            // buttonAutoShift
            // 
            this.buttonAutoShift.Enabled = false;
            this.buttonAutoShift.Location = new System.Drawing.Point(994, 836);
            this.buttonAutoShift.Name = "buttonAutoShift";
            this.buttonAutoShift.Size = new System.Drawing.Size(75, 23);
            this.buttonAutoShift.TabIndex = 9;
            this.buttonAutoShift.Text = "Автосдвиг";
            this.buttonAutoShift.UseVisualStyleBackColor = true;
            this.buttonAutoShift.Click += new System.EventHandler(this.buttonAutoShift_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDev);
            this.groupBox2.Location = new System.Drawing.Point(1156, 825);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 39);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отклонение:";
            // 
            // textBoxDev
            // 
            this.textBoxDev.Location = new System.Drawing.Point(6, 13);
            this.textBoxDev.Name = "textBoxDev";
            this.textBoxDev.ReadOnly = true;
            this.textBoxDev.Size = new System.Drawing.Size(100, 20);
            this.textBoxDev.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 872);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonAutoShift);
            this.Controls.Add(this.buttonReverse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxPhaseSpectre);
            this.Controls.Add(this.groupBoxAmpSpectre);
            this.Controls.Add(this.groupBoxSignal);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonSetData);
            this.Name = "FormMain";
            this.Text = "Фазовая проблема и её решение алгоритмом Фиенупа";
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).EndInit();
            this.groupBoxSignal.ResumeLayout(false);
            this.groupBoxAmpSpectre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAmpSpectr)).EndInit();
            this.groupBoxPhaseSpectre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseSpectr)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSignal;
        private System.Windows.Forms.Button buttonSetData;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxSignal;
        private System.Windows.Forms.GroupBox groupBoxAmpSpectre;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmpSpectr;
        private System.Windows.Forms.GroupBox groupBoxPhaseSpectre;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhaseSpectr;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReverse;
        private System.Windows.Forms.Button buttonAutoShift;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDev;
    }
}

