using System;
using Microsoft.Extensions.Logging;

namespace TestApp.WebApp.Core.Logging
{
    public class FileLogger : ILogger
    {
        private string _filePath;
        private string _categoryName;
        private Func<string, LogLevel, bool> _filter;
        private IFileService _fileService;

        public FileLogger(string categoryName, string filePath, Func<string, LogLevel, bool> filter, IFileService fileService)
        {
            _categoryName = categoryName;
            _filePath = filePath;
            _filter = filter;
            _fileService = fileService;
        }

        public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{ logLevel }: {message}" + Environment.NewLine;

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception + Environment.NewLine;
            }

            _fileService.WriteMessage(_filePath, message);
        }

        public bool IsEnabled(LogLevel logLevel) =>
            (_filter == null || _filter(_categoryName, logLevel));

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
