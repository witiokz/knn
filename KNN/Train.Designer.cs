namespace KNN
{
    partial class Train
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
            this.btnOpenTrainingImage = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblChosenFile = new System.Windows.Forms.Label();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnOpenTrainingImage
            // 
            this.btnOpenTrainingImage.Location = new System.Drawing.Point(188, 67);
            this.btnOpenTrainingImage.Name = "btnOpenTrainingImage";
            this.btnOpenTrainingImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTrainingImage.TabIndex = 5;
            this.btnOpenTrainingImage.Text = "button1";
            this.btnOpenTrainingImage.UseVisualStyleBackColor = true;
            this.btnOpenTrainingImage.Click += new System.EventHandler(this.btnOpenTrainingImage_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(147, 188);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(100, 20);
            this.txtInfo.TabIndex = 4;
            // 
            // lblChosenFile
            // 
            this.lblChosenFile.AutoSize = true;
            this.lblChosenFile.Location = new System.Drawing.Point(22, 52);
            this.lblChosenFile.Name = "lblChosenFile";
            this.lblChosenFile.Size = new System.Drawing.Size(35, 13);
            this.lblChosenFile.TabIndex = 3;
            this.lblChosenFile.Text = "label1";
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.FileName = "openFileDialog1";
            // 
            // Train
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOpenTrainingImage);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblChosenFile);
            this.Name = "Train";
            this.Text = "Train";
            this.Load += new System.EventHandler(this.Train_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenTrainingImage;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label lblChosenFile;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
    }
}