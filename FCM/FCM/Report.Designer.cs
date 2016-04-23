namespace FCM
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 652);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Построить граф";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gray;
            this.tabPage3.Controls.Add(this.chart);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1040, 604);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chart график";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Gray;
            this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.chart.BackSecondaryColor = System.Drawing.Color.Silver;
            this.chart.BorderlineColor = System.Drawing.Color.Black;
            this.chart.BorderlineWidth = 4;
            this.chart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            this.chart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Crossing = 0D;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.Crossing = 0D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Nodes values";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.BackSecondaryColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Gray;
            legend1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            legend1.BackSecondaryColor = System.Drawing.Color.DarkGray;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleBackColor = System.Drawing.Color.Transparent;
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(-4, 3);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Maroon,
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive,
        System.Drawing.Color.Green,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Navy,
        System.Drawing.Color.Purple,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.MarkerBorderWidth = 4;
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1044, 598);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Analysis Chart";
            this.chart.Titles.Add(title1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1040, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Таблица";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportTable
            // 
            this.reportTable.AllowUserToAddRows = false;
            this.reportTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportTable.BackgroundColor = System.Drawing.Color.White;
            this.reportTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.reportTable.Location = new System.Drawing.Point(6, 6);
            this.reportTable.Name = "reportTable";
            this.reportTable.RowHeadersVisible = false;
            this.reportTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.reportTable.Size = new System.Drawing.Size(1028, 592);
            this.reportTable.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1048, 633);
            this.tabControl1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(884, 652);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(177, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить график";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1073, 677);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Report";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.Report_Load);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView reportTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonSave;
    }
}