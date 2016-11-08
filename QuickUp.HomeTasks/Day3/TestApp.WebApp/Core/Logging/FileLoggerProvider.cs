using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TestApp.WebApp.Core.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly string _fileName;
        private readonly IFileService _fileService;

        public FileLoggerProvider(Func<string, LogLevel, bool> filter, string fileName, IFileService fileService)
        {
            _filter = filter;
            _fileName = fileName;
            _fileService = fileService;
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName) => new FileLogger(categoryName, _fileName, _filter, _fileService);
    }
}
