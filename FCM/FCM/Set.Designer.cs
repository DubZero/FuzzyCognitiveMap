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
            this.label1 = new System.Windows.Forms.Label();
            this.funcBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.chbSaveToXls = new System.Windows.Forms.CheckBox();
            this.chbAdnReport = new System.Windows.Forms.CheckBox();
            this.bntApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
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
            this.funcBox.Location = new System.Drawing.Point(48, 13);
            this.funcBox.Name = "funcBox";
            this.funcBox.Size = new System.Drawing.Size(265, 21);
            this.funcBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид аргумента функции:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 107);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // chbSaveToXls
            // 
            this.chbSaveToXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbSaveToXls.AutoSize = true;
            this.chbSaveToXls.Location = new System.Drawing.Point(13, 244);
            this.chbSaveToXls.Name = "chbSaveToXls";
            this.chbSaveToXls.Size = new System.Drawing.Size(106, 17);
            this.chbSaveToXls.TabIndex = 3;
            this.chbSaveToXls.Text = "Сохранить в .xls";
            this.chbSaveToXls.UseVisualStyleBackColor = true;
            // 
            // chbAdnReport
            // 
            this.chbAdnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbAdnReport.AutoSize = true;
            this.chbAdnReport.Location = new System.Drawing.Point(13, 268);
            this.chbAdnReport.Name = "chbAdnReport";
            this.chbAdnReport.Size = new System.Drawing.Size(127, 17);
            this.chbAdnReport.TabIndex = 4;
            this.chbAdnReport.Text = "Расширенный отчет";
            this.chbAdnReport.UseVisualStyleBackColor = true;
            // 
            // bntApply
            // 
            this.bntApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntApply.Location = new System.Drawing.Point(170, 257);
            this.bntApply.Name = "bntApply";
            this.bntApply.Size = new System.Drawing.Size(143, 23);
            this.bntApply.TabIndex = 5;
            this.bntApply.Text = "Применить";
            this.bntApply.UseVisualStyleBackColor = true;
            // 
            // Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 292);
            this.Controls.Add(this.bntApply);
            this.Controls.Add(this.chbAdnReport);
            this.Controls.Add(this.chbSaveToXls);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.funcBox);
            this.Controls.Add(this.label1);
            this.Name = "Set";
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}