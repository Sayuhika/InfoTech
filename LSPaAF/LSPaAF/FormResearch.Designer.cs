namespace LSPaAF
{
    partial class FormResearch
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chartResearchGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxResearchTestsCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxResearchMaxIterates = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxResearchAccuracy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxResearchMaxDotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxResearchSNRMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxResearchSNRMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonResearchStartStop = new System.Windows.Forms.Button();
            this.buttonSignalSetup = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarResearch = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.chartResearchGraph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartResearchGraph
            // 
            chartArea1.AxisX.Title = "ОСШ";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.Title = "Среднее значение отклонения";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this.chartResearchGraph.ChartAreas.Add(chartArea1);
            this.chartResearchGraph.Location = new System.Drawing.Point(12, 12);
            this.chartResearchGraph.Name = "chartResearchGraph";
            this.chartResearchGraph.Size = new System.Drawing.Size(1006, 557);
            this.chartResearchGraph.TabIndex = 0;
            this.chartResearchGraph.Text = "chart";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxResearchTestsCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(1024, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 248);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // textBoxResearchTestsCount
            // 
            this.textBoxResearchTestsCount.Location = new System.Drawing.Point(175, 216);
            this.textBoxResearchTestsCount.Name = "textBoxResearchTestsCount";
            this.textBoxResearchTestsCount.Size = new System.Drawing.Size(50, 20);
            this.textBoxResearchTestsCount.TabIndex = 5;
            this.textBoxResearchTestsCount.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Число экспериментов на точку:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxResearchMaxIterates);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxResearchAccuracy);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 79);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ограничения";
            // 
            // textBoxResearchMaxIterates
            // 
            this.textBoxResearchMaxIterates.Location = new System.Drawing.Point(108, 45);
            this.textBoxResearchMaxIterates.Name = "textBoxResearchMaxIterates";
            this.textBoxResearchMaxIterates.Size = new System.Drawing.Size(100, 20);
            this.textBoxResearchMaxIterates.TabIndex = 3;
            this.textBoxResearchMaxIterates.Text = "120000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Число итераций:";
            // 
            // textBoxResearchAccuracy
            // 
            this.textBoxResearchAccuracy.Location = new System.Drawing.Point(108, 19);
            this.textBoxResearchAccuracy.Name = "textBoxResearchAccuracy";
            this.textBoxResearchAccuracy.Size = new System.Drawing.Size(100, 20);
            this.textBoxResearchAccuracy.TabIndex = 1;
            this.textBoxResearchAccuracy.Text = "1e-10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Точность:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxResearchMaxDotes);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxResearchSNRMax);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxResearchSNRMin);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 103);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ОСШ";
            // 
            // textBoxResearchMaxDotes
            // 
            this.textBoxResearchMaxDotes.Location = new System.Drawing.Point(108, 71);
            this.textBoxResearchMaxDotes.Name = "textBoxResearchMaxDotes";
            this.textBoxResearchMaxDotes.Size = new System.Drawing.Size(100, 20);
            this.textBoxResearchMaxDotes.TabIndex = 5;
            this.textBoxResearchMaxDotes.Text = "11";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Число точек:";
            // 
            // textBoxResearchSNRMax
            // 
            this.textBoxResearchSNRMax.Location = new System.Drawing.Point(108, 45);
            this.textBoxResearchSNRMax.Name = "textBoxResearchSNRMax";
            this.textBoxResearchSNRMax.Size = new System.Drawing.Size(100, 20);
            this.textBoxResearchSNRMax.TabIndex = 3;
            this.textBoxResearchSNRMax.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Максимум:";
            // 
            // textBoxResearchSNRMin
            // 
            this.textBoxResearchSNRMin.Location = new System.Drawing.Point(108, 19);
            this.textBoxResearchSNRMin.Name = "textBoxResearchSNRMin";
            this.textBoxResearchSNRMin.Size = new System.Drawing.Size(100, 20);
            this.textBoxResearchSNRMin.TabIndex = 1;
            this.textBoxResearchSNRMin.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Минимум:";
            // 
            // buttonResearchStartStop
            // 
            this.buttonResearchStartStop.Location = new System.Drawing.Point(1024, 333);
            this.buttonResearchStartStop.Name = "buttonResearchStartStop";
            this.buttonResearchStartStop.Size = new System.Drawing.Size(231, 56);
            this.buttonResearchStartStop.TabIndex = 2;
            this.buttonResearchStartStop.Text = "Начать";
            this.buttonResearchStartStop.UseVisualStyleBackColor = true;
            this.buttonResearchStartStop.Click += new System.EventHandler(this.buttonResearchStartStop_Click);
            // 
            // buttonSignalSetup
            // 
            this.buttonSignalSetup.Location = new System.Drawing.Point(1024, 271);
            this.buttonSignalSetup.Name = "buttonSignalSetup";
            this.buttonSignalSetup.Size = new System.Drawing.Size(231, 56);
            this.buttonSignalSetup.TabIndex = 3;
            this.buttonSignalSetup.Text = "Настройка сигнала";
            this.buttonSignalSetup.UseVisualStyleBackColor = true;
            this.buttonSignalSetup.Click += new System.EventHandler(this.buttonSignalSetup_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBarResearch
            // 
            this.progressBarResearch.Location = new System.Drawing.Point(12, 575);
            this.progressBarResearch.Name = "progressBarResearch";
            this.progressBarResearch.Size = new System.Drawing.Size(1243, 23);
            this.progressBarResearch.TabIndex = 4;
            // 
            // FormResearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 610);
            this.Controls.Add(this.progressBarResearch);
            this.Controls.Add(this.buttonSignalSetup);
            this.Controls.Add(this.buttonResearchStartStop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartResearchGraph);
            this.Name = "FormResearch";
            this.Text = "Исследование точности оценки параметров линейной системы от уровня шума";
            ((System.ComponentModel.ISupportInitialize)(this.chartResearchGraph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResearchGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxResearchMaxIterates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxResearchAccuracy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxResearchMaxDotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxResearchSNRMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxResearchSNRMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonResearchStartStop;
        private System.Windows.Forms.TextBox textBoxResearchTestsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSignalSetup;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBarResearch;
    }
}