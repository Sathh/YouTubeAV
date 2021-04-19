using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Windows.Forms;

namespace YoutubeAV
{
    public partial class MainForm : Form
    {
        public static string Path = "";
        private static new string ProductVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private WebClient webClient = new WebClient();

        public MainForm()
        {
            InitializeComponent();
        }
        private void Initial()
        {
            versionLabel.Text = "Verzia: " + ProductVersion;
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)  
            {
                MessageBox.Show("Nebol vybraný žiadny priečinok", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Path = folderBrowserDialog.SelectedPath;
            pathLabel.Text = Path;
            BringToFront();
            Activate();
            if (File.Exists(@"YoutubeAVUpdater.exe") == false)
            {
                DownloadUpdater();
            }
            if (IsUpdateAvailable(ProductVersion) == true)
            {
                if (MessageBox.Show("Je dostupná aktualizácia.\nChceš ju sťiahnuť ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            Path = folderBrowserDialog.SelectedPath;
            pathLabel.Text = Path;
        }

        private void OpenPathButton_Click(object sender, EventArgs e)
        {
            Process.Start(Path);
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
                if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox1.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "\t" + textBox1.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "\t" + textBox2.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox3.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "\t" + textBox3.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox4.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "\t" + textBox4.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "\t" + textBox5.Text + Environment.NewLine);
            }


            string[] items = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            TextBoxClear();


            if (radioButton1.Checked == true && checkBox1.Checked == true)
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

            if (radioButton1.Checked == true && checkBox2.Checked == true)
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

            if (radioButton1.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
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


            if (radioButton2.Checked == true && checkBox1.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, true, false);
                    }
                }
                return;
            }

            if (radioButton2.Checked == true && checkBox2.Checked == true)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, false, false);
                    }
                }
                return;
            }

            if (radioButton2.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
            {
                foreach (string s in items)
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        DownloadFormHD dfHD = new DownloadFormHD(s, true, true);
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
            if (checkBox2.Checked == true)
                checkBox2.Checked = false;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                checkBox1.Checked = false;
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
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\YoutubeAVlog.txt", Convert.ToString(DateTime.Now) + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message.ToString());
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\YoutubeAVlog.txt", Convert.ToString(DateTime.Now) + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            else
            {
                return;
            }
        }
    }
}