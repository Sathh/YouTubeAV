using System;
using System.IO;
using System.Linq;
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
        private bool Only1080p { get; set; }
        public DownloadFormHD(string videolink, bool converting, bool deleteAfterConverting, bool only1080p)
        {
            InitializeComponent();
            this.Videolink = videolink;
            this.Converting = converting;
            this.DeleteAfterConverting = deleteAfterConverting;
            this.Only1080p = only1080p;
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
                var video = await client.Videos.GetAsync(Videolink); //https://www.youtube.com/watch?v=bnsUkE8i0tU
                var title = video.Title; // "Infected Mushroom - Spitfire [Monstercat Release]"
                this.nameNameLabel.Text = title;
                var invalids = System.IO.Path.GetInvalidFileNameChars();
                var newtitle = String.Join("_", title.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
                this.statusStatusLabel.Text = "Prekladanie názvu";
                var streamManifest = await client.Videos.Streams.GetManifestAsync(Videolink);
                var savePath = MainForm.Path + "/";
                try
                {
                    this.statusStatusLabel.Text = "Sťahovanie";
                    var streamInfo = streamManifest.GetVideoOnlyStreams().Where(s => s.Container.Name.ToString() == "mp4").GetWithHighestVideoQuality();

                    if (Only1080p == true)
                    {
                        //streamInfo = streamManifest.GetVideoOnlyStreams().Where(s => s.Container.Name.ToString() == "mp4" && s.VideoResolution.Height.ToString().Contains("1080")).GetWithHighestVideoQuality();
                        streamInfo = streamManifest.GetVideoOnlyStreams().Where(s => s.Container.Name.ToString() == "mp4" && s.VideoResolution.Width.Equals(1920)).GetWithHighestVideoQuality();
                    }

                    this.resolutionLabel.Text = streamInfo.VideoResolution.ToString();
                    this.durationLabel.Text = video.Duration.ToString();
                    this.fileSizeLabel.Text = streamInfo.Size.ToString();
                    var extension = streamInfo.Container.Name;

                    if (File.Exists(savePath + newtitle + $".{extension}") == true)
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
                    this.statusStatusLabel.Text = "Sťahovanie";
                    var progress = new Progress<double>(p =>
                    {
                        progressBar1.Value = Convert.ToInt32(p * 100);
                        var prog = p * 100;
                        var rounded = Math.Round(prog, 2);
                        this.Text = "Sťahovanie " + Convert.ToString(rounded) + "%";
                    });
                    await client.Videos.DownloadAsync(Videolink, savePath + newtitle + $".{extension}", progress, cancelTokenSource.Token); // output format inferred from file extension
                    if (Converting == true)
                    {
                        this.Text = "Konvertujem " + title;
                        this.statusStatusLabel.Text = "Konvertujem";
                        var ex = await Task.Run(() => new Extractor(savePath + newtitle + $".{extension}", DeleteAfterConverting));
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
                    MessageBox.Show("Chyba sťahovania HD: " + ex.Message.ToString(), newtitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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