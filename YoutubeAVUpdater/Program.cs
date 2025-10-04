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

            Console.WriteLine("Target download path: " + targetFile);
            Console.WriteLine();

            try
            {
                // Ensure any old temp file is removed before downloading
                if (File.Exists(tempFile))
                {
                    try { File.Delete(tempFile); }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning: Could not delete existing temp file. " + ex.Message);
                    }
                }

                // Download the new version
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += (sender, e) =>
                    {
                        Console.Write($"\rDownloading... {e.ProgressPercentage}%");
                    };

                    Console.WriteLine("Downloading update...");
                    await webClient.DownloadFileTaskAsync(new Uri(updateUrl), tempFile);
                    Console.WriteLine("\nDownload completed.");
                }

                // Verify download exists
                if (!File.Exists(tempFile))
                {
                    Console.WriteLine("Error: Downloaded file not found.");
                    return;
                }

                // Backup the current version if present
                if (File.Exists(targetFile))
                {
                    try
                    {
                        File.Copy(targetFile, backupFile, true);
                        Console.WriteLine("Backup created: " + backupFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning: Failed to create backup. " + ex.Message);
                    }

                    try
                    {
                        File.Replace(tempFile, targetFile, backupFile, true);
                        Console.WriteLine("File replaced successfully.");
                    }
                    catch
                    {
                        // Fallback if File.Replace fails (e.g., permission or lock issue)
                        File.Delete(targetFile);
                        File.Move(tempFile, targetFile);
                        Console.WriteLine("Existing file replaced manually.");
                    }
                }
                else
                {
                    // Target file missing — just move the downloaded one
                    File.Move(tempFile, targetFile);
                    Console.WriteLine("No existing file found. New file created.");
                }

                // Start the application
                try
                {
                    Process process = Process.Start(targetFile);
                    if (process != null)
                    {
                        Console.WriteLine("Application started successfully.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Error: Could not start the application.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error starting application: " + ex.Message);
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Download error: " + webEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                // Cleanup any leftover temp files
                if (File.Exists(tempFile))
                {
                    try
                    {
                        File.Delete(tempFile);
                        Console.WriteLine("Temporary file cleaned up.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning: Failed to delete temp file. " + ex.Message);
                    }
                }
            }
        }
    }
}