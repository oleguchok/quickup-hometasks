using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.WebApp.Core.Logging
{
    public interface IFileService
    {
        void WriteMessage(string filePath, string message);
    }
}
