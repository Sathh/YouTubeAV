
namespace YoutubeAV
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.versionLabel = new System.Windows.Forms.Label();
            this.historyChkBox = new System.Windows.Forms.CheckBox();
            this.manualConvButton = new System.Windows.Forms.Button();
            this.openPathButton = new System.Windows.Forms.Button();
            this.checkBoxOnlyVideo = new System.Windows.Forms.CheckBox();
            this.checkBoxKeepVideo = new System.Windows.Forms.CheckBox();
            this.radioButtonHighest = new System.Windows.Forms.RadioButton();
            this.radioButton720p = new System.Windows.Forms.RadioButton();
            this.changeLocationButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.radioButton1080p = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(321, 350);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(67, 13);
            this.versionLabel.TabIndex = 51;
            this.versionLabel.Text = "versionLabel";
            // 
            // historyChkBox
            // 
            this.historyChkBox.AutoSize = true;
            this.historyChkBox.Checked = true;
            this.historyChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.historyChkBox.Location = new System.Drawing.Point(13, 337);
            this.historyChkBox.Name = "historyChkBox";
            this.historyChkBox.Size = new System.Drawing.Size(149, 17);
            this.historyChkBox.TabIndex = 50;
            this.historyChkBox.Text = "Zapisovať linky do histórie";
            this.historyChkBox.UseVisualStyleBackColor = true;
            // 
            // manualConvButton
            // 
            this.manualConvButton.Location = new System.Drawing.Point(310, 304);
            this.manualConvButton.Name = "manualConvButton";
            this.manualConvButton.Size = new System.Drawing.Size(113, 23);
            this.manualConvButton.TabIndex = 49;
            this.manualConvButton.Text = "Manuálna konverzia";
            this.manualConvButton.UseVisualStyleBackColor = true;
            this.manualConvButton.Click += new System.EventHandler(this.ManualConvButton_Click);
            // 
            // openPathButton
            // 
            this.openPathButton.Location = new System.Drawing.Point(108, 304);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(98, 23);
            this.openPathButton.TabIndex = 48;
            this.openPathButton.Text = "Otvoriť priečinok";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.OpenPathButton_Click);
            // 
            // checkBoxOnlyVideo
            // 
            this.checkBoxOnlyVideo.AutoSize = true;
            this.checkBoxOnlyVideo.Location = new System.Drawing.Point(225, 238);
            this.checkBoxOnlyVideo.Name = "checkBoxOnlyVideo";
            this.checkBoxOnlyVideo.Size = new System.Drawing.Size(112, 17);
            this.checkBoxOnlyVideo.TabIndex = 40;
            this.checkBoxOnlyVideo.Text = "Stiahnuť len video";
            this.checkBoxOnlyVideo.UseVisualStyleBackColor = true;
            this.checkBoxOnlyVideo.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // checkBoxKeepVideo
            // 
            this.checkBoxKeepVideo.AutoSize = true;
            this.checkBoxKeepVideo.Location = new System.Drawing.Point(225, 214);
            this.checkBoxKeepVideo.Name = "checkBoxKeepVideo";
            this.checkBoxKeepVideo.Size = new System.Drawing.Size(106, 17);
            this.checkBoxKeepVideo.TabIndex = 39;
            this.checkBoxKeepVideo.Text = "Stiahnuť aj video";
            this.checkBoxKeepVideo.UseVisualStyleBackColor = true;
            this.checkBoxKeepVideo.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // radioButtonHighest
            // 
            this.radioButtonHighest.AutoSize = true;
            this.radioButtonHighest.Location = new System.Drawing.Point(12, 259);
            this.radioButtonHighest.Name = "radioButtonHighest";
            this.radioButtonHighest.Size = new System.Drawing.Size(154, 17);
            this.radioButtonHighest.TabIndex = 38;
            this.radioButtonHighest.Text = "Stiahnuť v najvyššej kvalite";
            this.radioButtonHighest.UseVisualStyleBackColor = true;
            // 
            // radioButton720p
            // 
            this.radioButton720p.AutoSize = true;
            this.radioButton720p.Checked = true;
            this.radioButton720p.Location = new System.Drawing.Point(12, 213);
            this.radioButton720p.Name = "radioButton720p";
            this.radioButton720p.Size = new System.Drawing.Size(211, 17);
            this.radioButton720p.TabIndex = 37;
            this.radioButton720p.TabStop = true;
            this.radioButton720p.Text = "Stiahnuť v obyčajnej kvalite (max 720p)";
            this.radioButton720p.UseVisualStyleBackColor = true;
            // 
            // changeLocationButton
            // 
            this.changeLocationButton.Location = new System.Drawing.Point(12, 304);
            this.changeLocationButton.Name = "changeLocationButton";
            this.changeLocationButton.Size = new System.Drawing.Size(90, 24);
            this.changeLocationButton.TabIndex = 36;
            this.changeLocationButton.Text = "ZMENIŤ";
            this.changeLocationButton.UseVisualStyleBackColor = true;
            this.changeLocationButton.Click += new System.EventHandler(this.ChangeSavePath);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(67, 288);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(0, 13);
            this.pathLabel.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Uložiť do:";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(12, 155);
            this.startButton.Name = "startButton";
            this.startButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startButton.Size = new System.Drawing.Size(411, 52);
            this.startButton.TabIndex = 33;
            this.startButton.Text = "Štart";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 129);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(411, 20);
            this.textBox5.TabIndex = 32;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 102);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(411, 20);
            this.textBox4.TabIndex = 31;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(411, 20);
            this.textBox3.TabIndex = 30;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(411, 20);
            this.textBox2.TabIndex = 29;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(411, 20);
            this.textBox1.TabIndex = 28;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // radioButton1080p
            // 
            this.radioButton1080p.AutoSize = true;
            this.radioButton1080p.Location = new System.Drawing.Point(12, 236);
            this.radioButton1080p.Name = "radioButton1080p";
            this.radioButton1080p.Size = new System.Drawing.Size(141, 17);
            this.radioButton1080p.TabIndex = 52;
            this.radioButton1080p.TabStop = true;
            this.radioButton1080p.Text = "Stiahnuť v 1080p kvalite";
            this.radioButton1080p.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 374);
            this.Controls.Add(this.radioButton1080p);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.historyChkBox);
            this.Controls.Add(this.manualConvButton);
            this.Controls.Add(this.openPathButton);
            this.Controls.Add(this.checkBoxOnlyVideo);
            this.Controls.Add(this.checkBoxKeepVideo);
            this.Controls.Add(this.radioButtonHighest);
            this.Controls.Add(this.radioButton720p);
            this.Controls.Add(this.changeLocationButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "YoutubeAV";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.CheckBox historyChkBox;
        private System.Windows.Forms.Button manualConvButton;
        private System.Windows.Forms.Button openPathButton;
        private System.Windows.Forms.CheckBox checkBoxOnlyVideo;
        private System.Windows.Forms.CheckBox checkBoxKeepVideo;
        private System.Windows.Forms.RadioButton radioButtonHighest;
        private System.Windows.Forms.RadioButton radioButton720p;
        private System.Windows.Forms.Button changeLocationButton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton radioButton1080p;
    }
}

