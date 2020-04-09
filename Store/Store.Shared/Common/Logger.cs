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
            if (formatter is null)
            {
                return;
            }

            lock (_lock)
            {
                //TODO add more frendly error message
                File.AppendAllText(_path, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}
