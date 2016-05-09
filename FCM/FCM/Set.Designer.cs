namespace FCM
{
    partial class Set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Set));
            this.label1 = new System.Windows.Forms.Label();
            this.funcBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.feedback = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.k2Num = new System.Windows.Forms.NumericUpDown();
            this.k1Num = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.chbSaveToXls = new System.Windows.Forms.CheckBox();
            this.chbAdnReport = new System.Windows.Forms.CheckBox();
            this.bntApply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k1Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x)=";
            // 
            // funcBox
            // 
            this.funcBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcBox.FormattingEnabled = true;
            this.funcBox.Items.AddRange(new object[] {
            "sigmoid(x) Сигмоидальная функция",
            "gaussmf(x) Гауссова функция"});
            this.funcBox.Location = new System.Drawing.Point(64, 16);
            this.funcBox.Margin = new System.Windows.Forms.Padding(4);
            this.funcBox.Name = "funcBox";
            this.funcBox.Size = new System.Drawing.Size(491, 24);
            this.funcBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.feedback);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.k2Num);
            this.groupBox1.Controls.Add(this.k1Num);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(17, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(539, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид аргумента функции:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Feedback = ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // feedback
            // 
            this.feedback.DecimalPlaces = 2;
            this.feedback.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.feedback.Location = new System.Drawing.Point(451, 166);
            this.feedback.Margin = new System.Windows.Forms.Padding(4);
            this.feedback.Name = "feedback";
            this.feedback.Size = new System.Drawing.Size(76, 22);
            this.feedback.TabIndex = 8;
            this.feedback.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "k2 = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "k1 = ";
            // 
            // k2Num
            // 
            this.k2Num.DecimalPlaces = 2;
            this.k2Num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.k2Num.Location = new System.Drawing.Point(451, 78);
            this.k2Num.Margin = new System.Windows.Forms.Padding(4);
            this.k2Num.MinimumSize = new System.Drawing.Size(76, 0);
            this.k2Num.Name = "k2Num";
            this.k2Num.Size = new System.Drawing.Size(76, 22);
            this.k2Num.TabIndex = 5;
            // 
            // k1Num
            // 
            this.k1Num.DecimalPlaces = 2;
            this.k1Num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.k1Num.Location = new System.Drawing.Point(451, 33);
            this.k1Num.Margin = new System.Windows.Forms.Padding(4);
            this.k1Num.Name = "k1Num";
            this.k1Num.Size = new System.Drawing.Size(76, 22);
            this.k1Num.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FCM.Properties.Resources._4;
            this.pictureBox2.InitialImage = global::FCM.Properties.Resources._4;
            this.pictureBox2.Location = new System.Drawing.Point(36, 129);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(356, 98);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FCM.Properties.Resources._3;
            this.pictureBox1.InitialImage = global::FCM.Properties.Resources._3;
            this.pictureBox1.Location = new System.Drawing.Point(36, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 98);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 132);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 25);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // chbSaveToXls
            // 
            this.chbSaveToXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbSaveToXls.AutoSize = true;
            this.chbSaveToXls.Location = new System.Drawing.Point(17, 294);
            this.chbSaveToXls.Margin = new System.Windows.Forms.Padding(4);
            this.chbSaveToXls.Name = "chbSaveToXls";
            this.chbSaveToXls.Size = new System.Drawing.Size(129, 20);
            this.chbSaveToXls.TabIndex = 3;
            this.chbSaveToXls.Text = "Сохранить в .xls";
            this.chbSaveToXls.UseVisualStyleBackColor = true;
            // 
            // chbAdnReport
            // 
            this.chbAdnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbAdnReport.AutoSize = true;
            this.chbAdnReport.Location = new System.Drawing.Point(17, 323);
            this.chbAdnReport.Margin = new System.Windows.Forms.Padding(4);
            this.chbAdnReport.Name = "chbAdnReport";
            this.chbAdnReport.Size = new System.Drawing.Size(158, 20);
            this.chbAdnReport.TabIndex = 4;
            this.chbAdnReport.Text = "Расширенный отчет";
            this.chbAdnReport.UseVisualStyleBackColor = true;
            // 
            // bntApply
            // 
            this.bntApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntApply.Location = new System.Drawing.Point(365, 309);
            this.bntApply.Margin = new System.Windows.Forms.Padding(4);
            this.bntApply.Name = "bntApply";
            this.bntApply.Size = new System.Drawing.Size(191, 28);
            this.bntApply.TabIndex = 5;
            this.bntApply.Text = "Применить";
            this.bntApply.UseVisualStyleBackColor = true;
            this.bntApply.Click += new System.EventHandler(this.bntApply_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Справка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(572, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bntApply);
            this.Controls.Add(this.chbAdnReport);
            this.Controls.Add(this.chbSaveToXls);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.funcBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(588, 391);
            this.MinimumSize = new System.Drawing.Size(588, 391);
            this.Name = "Set";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Set_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k1Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox funcBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chbSaveToXls;
        private System.Windows.Forms.CheckBox chbAdnReport;
        private System.Windows.Forms.Button bntApply;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown k2Num;
        private System.Windows.Forms.NumericUpDown k1Num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown feedback;
        private System.Windows.Forms.Button button1;
    }
}