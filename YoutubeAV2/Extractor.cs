using System.IO;
using MediaToolkit.Model;
using MediaToolkit;

namespace YoutubeAV
{
    public class Extractor
    {
        private string Source { get; set; }
        private bool DeleteAfterConverting { get; set; }
        internal bool ConversionDone { get; set; }
        public Extractor(string source, bool deleteAfterConverting)
        {
            this.Source = source;
            this.DeleteAfterConverting = deleteAfterConverting;
            ConversionDone = ExtractAudio();
        }
        public bool ExtractAudio()
        {
            var inputFile = new MediaFile { Filename = Source };
            var outputFile = new MediaFile { Filename = $"{Source.Replace(".mp4", "")}.mp3" };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
                engine.ConversionCompleteEvent += Engine_ConversionCompleteEvent;
            }
            if (DeleteAfterConverting == true)
            {
                if (File.Exists(Source))
                {
                    File.Delete(Source);
                }
            }
            return true;
        }
        private void Engine_ConversionCompleteEvent(object sender, ConversionCompleteEventArgs e)
        {
            ConversionDone = true;
        }
        public static void ManualExtractAudio(string source) 
        {
            var inputFile = new MediaFile { Filename = source };
            var outputFile = new MediaFile { Filename = $"{source.Replace(".mp4", "")}.mp3" };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }
        }
    }
}
