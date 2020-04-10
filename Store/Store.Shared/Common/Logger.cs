using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Store.Shared.Common
{
    public class Logger : ILogger
    {
        private string _path;
        private static object _lock = new object();

        public Logger(string path)
        {
            _path = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (exception is null)
            {
                return;
            }

            lock (_lock)
            {
                File.AppendAllText(_path, $"{DateTime.Now}:>{formatter(state, exception)}\nSource:{exception?.Source}\n{exception?.GetType().FullName}->{exception?.Message}\n{exception?.StackTrace ?? string.Empty}\n\n");
            }
        }
    }
}
