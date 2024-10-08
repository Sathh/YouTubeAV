﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeAV
{
    public partial class DownloadForm : Form
    {
        private string Videolink { get; set; }
        private bool Converting { get; set; }
        //private bool DeleteAfterConverting { get; set; }
        public DownloadForm(string videolink, bool converting, bool deleteAfterConverting)
        {
            InitializeComponent();
            this.Videolink = videolink;
            this.Converting = converting;
            //this.DeleteAfterConverting = deleteAfterConverting;
            DownloadSD();
        }
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken Token = new CancellationToken();
        public async void DownloadSD()
        {
            try
            {
                this.Show();
                this.statusStatusLabel.Text = "Inicializácia";
                var client = new YoutubeClient();
                var video = await client.Videos.GetAsync(this.Videolink); //https://www.youtube.com/watch?v=bnsUkE8i0tU
                var title = video.Title; // "Infected Mushroom - Spitfire [Monstercat Release]"
                this.nameNameLabel.Text = title;
                var invalids = System.IO.Path.GetInvalidFileNameChars(); 
                var newtitle = String.Join("_", title.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
                this.statusStatusLabel.Text = "Prekladanie názvu";
                var streamManifest = await client.Videos.Streams.GetManifestAsync(Videolink);
                var savePath = MainForm.MainPath + "/";
                try
                {
                    this.statusStatusLabel.Text = "Sťahovanie";
                    //var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                    var streamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();
                    this.resolutionLabel.Text = streamInfo.Bitrate.ToString();
                    this.durationLabel.Text = video.Duration.ToString();
                    this.fileSizeLabel.Text = streamInfo.Size.ToString();
                    var ext = streamInfo.Container.Name;
                    if (File.Exists(savePath + newtitle + $".{ext}") == true)
                    {
                        if (MessageBox.Show(newtitle + " už existuje !   Chceš ho stiahnuť aj tak ?", "Súbor už existuje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            this.Close();
                            return;
                        }
                    }
                    if (File.Exists(savePath + newtitle + $".mp3") == true)
                    {
                        if (MessageBox.Show(newtitle + " už existuje !   Chceš ho stiahnuť aj tak ?", "Súbor už existuje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            this.Close();
                            return;
                        }
                    }
                    
                    if (streamInfo != null)
                    {
                        var stream = await client.Videos.Streams.GetAsync(streamInfo);
                        this.statusStatusLabel.Text = "Sťahovanie";
                        var progress = new Progress<double>(p =>
                        {
                            progressBar1.Value = Convert.ToInt32(p * 100);
                            var prog = p * 100;
                            var rounded = Math.Round(prog, 2);
                            this.Text = "Sťahovanie " + Convert.ToString(rounded) + "%";

                        });
                        await client.Videos.Streams.DownloadAsync(streamInfo, savePath + newtitle + $".{ext}", progress, cancelTokenSource.Token);
                        string source = (savePath + newtitle + $".{ext}");
                        if (Converting == true)
                        {
                            this.Text = "Konvertujem " + title;
                            this.statusStatusLabel.Text = "Konvertujem";
                            //var ex = await Task.Run(() => new Extractor(savePath + newtitle + $".{ext}", DeleteAfterConverting));
                            var ex = await Task.Run(() => new Extractor(savePath + newtitle + $".{ext}", true));
                            if (ex.ConversionDone == true)
                            {
                                this.Close();
                            }
                        }
                        if (Converting == false)
                        {
                            this.statusStatusLabel.Text = "Dokončené";
                            this.Close();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    File.AppendAllText(MainForm.LogFilePath, Convert.ToString(DateTime.Now) + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);
                    MessageBox.Show("Chyba sťahovania: " + ex.Message.ToString(), newtitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                File.AppendAllText(MainForm.LogFilePath, Convert.ToString(DateTime.Now) + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);
                this.Close();
            }
        }
        private void DownloadForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                cancelTokenSource.Cancel();
                Token.ThrowIfCancellationRequested();
            }
        }
    }
}