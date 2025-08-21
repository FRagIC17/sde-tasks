using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dependency_injection
{
    internal interface ILogger
    {
        void Info(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine($"Info: {message}");
        }
    }

    public class FileLogger : ILogger
    {
        public string directory = AppDomain.CurrentDomain.BaseDirectory;
        private string fileName = "log.txt";
        public void Info(string message)
        {
            string filePath = Path.Combine(directory, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Write the log message to the file, creating it if it doesn't exist
            File.AppendAllText(filePath, $"Info: {message}{Environment.NewLine}");
        }
    }
}
