using System.IO;

namespace TestApp.WebApp.Core.Logging
{
    public class FileService : IFileService
    {
        public void WriteMessage(string filePath, string message)
        {
            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(message);
                }
            }
        }
    }
}
