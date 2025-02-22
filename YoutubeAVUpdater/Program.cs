using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace YoutubeAVUpdater
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string updateUrl = "https://github.com/Sathh/YouTubeAV/releases/download/1.21/YoutubeAV.exe";

            string currentDirectory = Directory.GetCurrentDirectory();
            string tempFile = Path.Combine(currentDirectory, "TEMPYoutubeAV.exe");
            string targetFile = Path.Combine(currentDirectory, "YoutubeAV.exe");
            string backupFile = Path.Combine(currentDirectory, "YoutubeAV_backup.exe");

            Console.WriteLine("File will be downloaded to: " + targetFile);
            Console.WriteLine();

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += (sender, e) =>
                    {
                        Console.Write($"\rDownloaded: {e.ProgressPercentage}%   ");
                    };

                    Console.WriteLine("Downloading update...");
                    await webClient.DownloadFileTaskAsync(new Uri(updateUrl), tempFile);
                    Console.WriteLine();
                }

                Console.WriteLine("Download completed.");

                if (File.Exists(targetFile))
                {
                    File.Replace(tempFile, targetFile, backupFile, true);
                }
                else
                {
                    File.Move(tempFile, targetFile);
                }

                Process process = Process.Start(targetFile);
                if (process != null)
                {
                    Console.WriteLine("Application started successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("Error starting the application.");
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Download error: " + webEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
