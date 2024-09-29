using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeAV
{
    public partial class MainForm : Form
    {
        public static string MainPath = "";
        public static string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YoutubeAVlog.txt");
        private string HistoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Historia stahovania - YoutubeAV.txt");
        private static new string ProductVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private WebClient webClient = new WebClient();

        public MainForm()
        {
            InitializeComponent();
        }
        private void Initial()
        {
            if (File.Exists(@"ffmpeg.exe") == false)
            {
                DownloadFFMpeg();
            }
            versionLabel.Text = "Verzia: " + ProductVersion;
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)  
            {
                MessageBox.Show("Nebol vybraný žiadny priečinok", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            MainPath = folderBrowserDialog.SelectedPath;
            pathLabel.Text = MainPath;
            BringToFront();
            Activate();
            if (File.Exists(@"YoutubeAVUpdater.exe") == false)
            {
                DownloadUpdater();
            }
            if (IsUpdateAvailable(ProductVersion) == true)
            {
                if (MessageBox.Show("Je dostupná aktualizácia.\nChceš ju stiahnuť ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start("YoutubeAVUpdater.exe");
                    Environment.Exit(0);
                }
            }
        }
        private void DownloadUpdater()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://github.com/Sathh/YouTubeAV/releases/download/1.21/YoutubeAVUpdater.exe", @"YoutubeAVUpdater.exe");
            }
            catch { }
        }
        private static void DownloadFFMpeg()
        {
            Task.Factory.StartNew(() =>
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://github.com/Sathh/YouTubeAV/raw/master/YoutubeAV2/ffmpeg.exe", @"ffmpeg.exe");
            });
        }
        private bool IsUpdateAvailable(string ProductVersion)
        {
            try
            {
                Stream webStream = webClient.OpenRead("https://raw.githubusercontent.com/Sathh/YouTubeAV/master/YoutubeAV2/Properties/AssemblyInfo.cs".ToString());
                string[] LatestVersionArray = new StreamReader(webStream).ReadToEnd().Split(new[] { "AssemblyFileVersion(\"" }, StringSplitOptions.None);
                string LatestVersionNumber = LatestVersionArray[1].Substring(0, LatestVersionArray[1].Length - 4);
                return (ProductVersion != LatestVersionNumber);
            }
            catch { }
            return false;
        }
        private void ChangeSavePath(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Nebol vybraný žiadny priečinok");
                return;
            }
            MainPath = folderBrowserDialog.SelectedPath;
            pathLabel.Text = MainPath;
        }
        private void OpenPathButton_Click(object sender, EventArgs e)
        {
            Process.Start(MainPath);
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (ConnectionChecker.Connection() == false)
            {
                MessageBox.Show("Nemáš pripojenie na internet!", "Nemáš pripojenie na internet!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (historyChkBox.Checked == true)
            {
                if (File.Exists(HistoryPath) == true)
                    {
                    try
                    {
                        if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox1.Text))
                            File.AppendAllText(HistoryPath, DateTime.Now.ToString() + "\t" + textBox1.Text + Environment.NewLine);
                        if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
                            File.AppendAllText(HistoryPath, DateTime.Now.ToString() + "\t" + textBox2.Text + Environment.NewLine);
                        if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox3.Text))
                            File.AppendAllText(HistoryPath, DateTime.Now.ToString() + "\t" + textBox3.Text + Environment.NewLine);
                        if (!String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox4.Text))
                            File.AppendAllText(HistoryPath, DateTime.Now.ToString() + "\t" + textBox4.Text + Environment.NewLine);
                        if (!String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
                            File.AppendAllText(HistoryPath, DateTime.Now.ToString() + "\t" + textBox5.Text + Environment.NewLine);
                    }
                    catch { }
                }
            }

            string[] items = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            TextBoxClear();

            if (radioButton720p.Checked == true && checkBoxKeepVideo.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadForm df = new DownloadForm(s, true, false);
                    }
                }
                return;
            }

            if (radioButton720p.Checked == true && checkBoxOnlyVideo.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadForm df = new DownloadForm(s, false, false);
                    }
                }
                return;
            }

            if (radioButton720p.Checked == true && checkBoxKeepVideo.Checked == false && checkBoxOnlyVideo.Checked == false)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadForm df = new DownloadForm(s, true, true);
                    }
                }
                return;
            }

            if (radioButtonHighest.Checked == true && checkBoxKeepVideo.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, true, false, false);
                    }
                }
                return;
            }

            if (radioButtonHighest.Checked == true && checkBoxOnlyVideo.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, false, false, false);
                    }
                }
                return;
            }

            if (radioButtonHighest.Checked == true && checkBoxKeepVideo.Checked == false && checkBoxOnlyVideo.Checked == false)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, true, true, false);
                    }
                }
                return;
            }

            if (radioButton1080p.Checked == true && checkBoxKeepVideo.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, true, false, true);
                    }
                }
                return;
            }

            if (radioButton1080p.Checked == true && checkBoxOnlyVideo.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, false, false, true);
                    }
                }
                return;
            }

            if (radioButton1080p.Checked == true && checkBoxKeepVideo.Checked == false && checkBoxOnlyVideo.Checked == false)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, true, true, true);
                    }
                }
                return;
            }
        }
        private void TextBoxClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initial();
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOnlyVideo.Checked == true)
                checkBoxOnlyVideo.Checked = false;
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKeepVideo.Checked == true)
                checkBoxKeepVideo.Checked = false;
        }
        private void ManualConvButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog
            {
                DefaultExt = "mp4",
                Filter = "Video (*.mp4)|*.mp4|Všetky súbory (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ofdPath = openFileDialog.FileName;
                    Extractor.ManualExtractAudio(ofdPath);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Nemáš oprávnenie.\n\nChybové hlásenie: {ex.Message}\n\n" + $"Detaily:\n\n{ex.StackTrace}");
                    File.AppendAllText(MainForm.LogFilePath, Convert.ToString(DateTime.Now) + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    File.AppendAllText(MainForm.LogFilePath, Convert.ToString(DateTime.Now) + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            else
            {
                return;
            }
        }
    }
}