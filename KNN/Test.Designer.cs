namespace KNN
{
    partial class Test
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
            this.btnOpenTestImage = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lblChosenFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenTestImage
            // 
            this.btnOpenTestImage.Location = new System.Drawing.Point(214, 51);
            this.btnOpenTestImage.Name = "btnOpenTestImage";
            this.btnOpenTestImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTestImage.TabIndex = 0;
            this.btnOpenTestImage.Text = "btnOpenTestImage";
            this.btnOpenTestImage.UseVisualStyleBackColor = true;
            this.btnOpenTestImage.Click += new System.EventHandler(this.btnOpenTestImage_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(96, 120);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(100, 20);
            this.txtInfo.TabIndex = 1;
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.FileName = "openFileDialog1";
            // 
            // lblChosenFile
            // 
            this.lblChosenFile.AutoSize = true;
            this.lblChosenFile.Location = new System.Drawing.Point(73, 51);
            this.lblChosenFile.Name = "lblChosenFile";
            this.lblChosenFile.Size = new System.Drawing.Size(35, 13);
            this.lblChosenFile.TabIndex = 2;
            this.lblChosenFile.Text = "label1";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblChosenFile);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnOpenTestImage);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenTestImage;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.Label lblChosenFile;
    }
}