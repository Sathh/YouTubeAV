using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security;
using System.Windows.Forms;

namespace YoutubeAV
{
    public partial class MainForm : Form
    {
        public static string Path = "";

        public MainForm()
        {
            InitializeComponent();
        }
        private void Initial()
        {
            versionLabel.Text = "Verzia: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)  
            {
                MessageBox.Show("Nebol vybraný žiadny priečinok", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Path = folderBrowserDialog.SelectedPath;
            pathLabel.Text = Path;
            BringToFront();
            Activate();
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
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "   " + textBox1.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "   " + textBox2.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox3.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "   " + textBox3.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox4.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "   " + textBox4.Text + Environment.NewLine);
                if (!String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\Historia stahovania - YoutubeAV.txt", DateTime.Now.ToString() + "   " + textBox5.Text + Environment.NewLine);
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
            openFileDialog1 = new OpenFileDialog
            {
                DefaultExt = "mp4",
                Filter = "Video (*.mp4)|*.mp4|Všetky súbory (*.*)|*.*"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sr = openFileDialog1.FileName;
                    Extractor.Manualextractaudio(sr);
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
            }
        }
    }
}