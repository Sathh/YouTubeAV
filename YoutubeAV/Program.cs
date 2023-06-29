using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeAV
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            if (File.Exists(@"ffmpeg.exe") == false)
            {
                DownloadFFMpeg();
            }
        }
        private static void DownloadFFMpeg()
        {
            Task.Factory.StartNew(() =>
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://github.com/Sathh/YouTubeAV/raw/master/YoutubeAV2/ffmpeg.exe", @"ffmpeg.exe");
            });
        }
    }
}
