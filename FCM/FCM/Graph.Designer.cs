namespace FCM
{
    partial class Graph
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.saveGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox.BackgroundImage = global::FCM.Properties.Resources.BackGround;
            this.pictureBox.Image = global::FCM.Properties.Resources.BackGround;
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.MaximumSize = new System.Drawing.Size(1057, 633);
            this.pictureBox.MinimumSize = new System.Drawing.Size(1057, 633);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1057, 633);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(995, 652);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // saveGraph
            // 
            this.saveGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveGraph.Location = new System.Drawing.Point(12, 652);
            this.saveGraph.Name = "saveGraph";
            this.saveGraph.Size = new System.Drawing.Size(98, 23);
            this.saveGraph.TabIndex = 2;
            this.saveGraph.Text = "Сохранить граф";
            this.saveGraph.UseVisualStyleBackColor = true;
            this.saveGraph.Click += new System.EventHandler(this.saveGraph_Click);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1077, 687);
            this.Controls.Add(this.saveGraph);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.pictureBox);
            this.MaximumSize = new System.Drawing.Size(1093, 726);
            this.MinimumSize = new System.Drawing.Size(1093, 726);
            this.Name = "Graph";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button saveGraph;
    }
}