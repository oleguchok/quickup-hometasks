using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
