using System.IO;

namespace CscCars
{
    public class LogWriter
    {
        // By removing the set;
        // we make the Properties read-only
        public string LogPath { get; }
        public string LogFile { get; }

        public LogWriter(string logPath, string logFile)
        {
            this.LogPath = logPath;
            this.LogFile = logFile;
        }


        /// <summary>
        /// This is a Documentation comment
        /// TODO: Research about Documentation comments
        /// </summary>
        /// <see cref="https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/language-specification/documentation-comments"/>
        /// <param name="message"></param>
        public void WriteToFile(string message)
        {
            // Writing to the file
            // NOTE: AppendAllText() creates a file, if it does not exist yet!
            File.AppendAllText(LogFile, message);
        }
    }
}
