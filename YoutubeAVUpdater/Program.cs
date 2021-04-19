using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace YoutubeAVUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("https://github.com/Sathh/YouTubeAV/releases/download/1.21/YoutubeAV.exe");
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadFileCompleted);
            webClient.DownloadFileAsync(uri, @"TEMPYoutubeAV.exe");
            Console.ReadKey();
        }

        private static void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("Stahovanie bolo zrusene.");
            }

            if (e.Error != null)
            {
                Console.WriteLine(e.Error.ToString());
                Console.WriteLine("Chyba stahovania");
            }
            else
            {
                File.Replace("TEMPYoutubeAV.exe", "YoutubeAV.exe", "YoutubeAV_backup.exe");
                Process.Start(@"YoutubeAV.exe");
                if (Process.GetProcessesByName("YoutubeAV") != null)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Chyba spustenia aplikacie");
                    Console.ReadKey();
                }
            }
        }
    }
}
