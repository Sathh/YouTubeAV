﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace YoutubeAV
{
    public partial class DownloadFormHD : Form
    {
        private string Videolink { get; set; }
        private bool Converting { get; set; }
        private bool DeleteAfterConverting { get; set; }
        public DownloadFormHD(string videolink, bool converting, bool deleteAfterConverting)
        {
            InitializeComponent();
            this.Videolink = videolink;
            this.Converting = converting;
            this.DeleteAfterConverting = deleteAfterConverting;
            DownloadHD();
        }

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken Token = new CancellationToken();
        public async void DownloadHD()
        {
            try
            {
                this.Show();
                this.statusStatusLabel.Text = "Inicializácia";
                var client = new YoutubeClient();
                var video = await client.Videos.GetAsync(Videolink);
                var title = video.Title; // "Infected Mushroom - Spitfire [Monstercat Release]"
                this.nameNameLabel.Text = title;
                var invalids = System.IO.Path.GetInvalidFileNameChars();
                var newtitle = String.Join("_", title.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
                this.statusStatusLabel.Text = "Prekladanie názvu";
                var streamManifest = await client.Videos.Streams.GetManifestAsync(Videolink);
                var ulozitkam = MainForm.Path + "/";
                try
                {
                    this.statusStatusLabel.Text = "Sťahovanie";
                    var streamInfo = streamManifest.GetVideo().WithHighestVideoQuality();
                    this.resolutionLabel.Text = streamInfo.Resolution.ToString();
                    this.durationLabel.Text = video.Duration.ToString();
                    this.fileSizeLabel.Text = streamInfo.Size.ToString();
                    var ext = streamInfo.Container.Name;
                    if (File.Exists(ulozitkam + newtitle + $".{ext}") == true)
                    {
                        if (MessageBox.Show(newtitle + " už existuje !   Chceš ho stiahnuť aj tak ?", "Súbor už existuje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            this.Close();
                            return;
                        }
                    }
                    if (File.Exists(ulozitkam + newtitle + $".mp3") == true)
                    {
                        if (MessageBox.Show(newtitle + " už existuje !   Chceš ho stiahnuť aj tak ?", "Súbor už existuje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            this.Close();
                            return;
                        }
                    }
                    this.statusStatusLabel.Text = "Sťahovanie";

                    var progress = new Progress<double>(p =>
                    {
                        progressBar1.Value = Convert.ToInt32(p * 100);
                        var prog = p * 100;
                        var rounded = Math.Round(prog, 2);
                        this.Text = "Sťahovanie " + Convert.ToString(rounded) + "%";
                    });
                    await client.Videos.DownloadAsync(Videolink, ulozitkam + newtitle + $".{ext}", progress, cancelTokenSource.Token); // output format inferred from file extension
                  
                    // STAHOVANIE TITULKOV
                    /*
                    var trackManifest = await client.Videos.ClosedCaptions.GetManifestAsync(Videolink);
                    var trackInfo = trackManifest.TryGetByLanguage("en"); 
                    if (trackInfo != null)
                    {
                        await client.Videos.ClosedCaptions.DownloadAsync(trackInfo, ulozitkam + newtitle + ".srt");
                    }
                    */

                    if (Converting == true)
                    {
                        this.Text = "Konvertujem " + title;
                        this.statusStatusLabel.Text = "Konvertujem";
                        var ex = await Task.Run(() => new Extractor(ulozitkam + newtitle + $".{ext}", DeleteAfterConverting));
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
                catch (Exception ex)
                {
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\YoutubeAVlog.txt", DateTime.Now.ToString() + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);
                    MessageBox.Show(newtitle, "Chyba sťahovania HD: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\YoutubeAVlog.txt", DateTime.Now.ToString() + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);
                this.Close();
            }
        }
        private void DownloadFormHD_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                cancelTokenSource.Cancel();
                Token.ThrowIfCancellationRequested();
            }
        }
    }
}
