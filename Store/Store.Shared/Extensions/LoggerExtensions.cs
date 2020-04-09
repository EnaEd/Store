using Microsoft.Extensions.Logging;
using Store.Shared.Common;

namespace Store.Shared.Extensions
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new LoggerProvider(path));
            return factory;
        }
    }
}
