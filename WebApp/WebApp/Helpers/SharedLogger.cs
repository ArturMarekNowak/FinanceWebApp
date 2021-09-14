using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace WebApp.Helpers
{
    public static class SharedLogger
    {
        public static ILogger Logger1 { get; internal set; }
    }
}