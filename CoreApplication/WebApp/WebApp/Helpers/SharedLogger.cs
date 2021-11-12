using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SQLitePCL;

namespace WebApp.Helpers
{
    public static class SharedLogger
    {
        private static ILogger _logger = NullLogger.Instance;

        public static ILogger Logger
        {
            get => _logger;
            internal set => _logger = value;
        }
    }
}