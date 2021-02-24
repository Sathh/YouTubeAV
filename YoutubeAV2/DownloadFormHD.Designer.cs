
namespace YoutubeAV
{
    partial class DownloadFormHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadFormHD));
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStatusLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.nameNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Location = new System.Drawing.Point(97, 53);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(0, 13);
            this.fileSizeLabel.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Veľkosť súboru:";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(59, 40);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(0, 13);
            this.durationLabel.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dĺžka:";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(56, 27);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(0, 13);
            this.resolutionLabel.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Rozmery:";
            // 
            // statusStatusLabel
            // 
            this.statusStatusLabel.AutoSize = true;
            this.statusStatusLabel.Location = new System.Drawing.Point(60, 74);
            this.statusStatusLabel.Name = "statusStatusLabel";
            this.statusStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusStatusLabel.TabIndex = 15;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(8, 74);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Status:";
            // 
            // nameNameLabel
            // 
            this.nameNameLabel.AutoSize = true;
            this.nameNameLabel.Location = new System.Drawing.Point(59, 14);
            this.nameNameLabel.Name = "nameNameLabel";
            this.nameNameLabel.Size = new System.Drawing.Size(0, 13);
            this.nameNameLabel.TabIndex = 13;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(8, 14);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Názov:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(477, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // DownloadFormHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 125);
            this.Controls.Add(this.fileSizeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resolutionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStatusLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.nameNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DownloadFormHD";
            this.Text = "Sťahovanie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadFormHD_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label nameLabel;
        internal System.Windows.Forms.Label statusStatusLabel;
        internal System.Windows.Forms.Label statusLabel;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.Label fileSizeLabel;
        internal System.Windows.Forms.Label durationLabel;
        internal System.Windows.Forms.Label resolutionLabel;
        internal System.Windows.Forms.Label nameNameLabel;
    }
}