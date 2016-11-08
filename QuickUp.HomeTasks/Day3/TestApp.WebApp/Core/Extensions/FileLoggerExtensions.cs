using System;
using Microsoft.Extensions.Logging;
using TestApp.WebApp.Core.Logging;

namespace TestApp.WebApp.Core.Extensions
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(
            this ILoggerFactory loggerFactory, 
            string filePath,
            IFileService fileService,
            Func<string, LogLevel, bool> filter = null)
        {
            loggerFactory.AddProvider(new FileLoggerProvider(filter, filePath, fileService));
            return loggerFactory;
        }

        public static ILoggerFactory AddFile(
                this ILoggerFactory loggerFactory,
                string filePath,
                IFileService fileService,
                LogLevel minLevel) =>
            AddFile(loggerFactory, filePath, fileService, (_, logLevel) => logLevel <= minLevel);

    }
}
