using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApp.Helpers;

namespace WebApp.Services
{
    internal class ParsingService : IParsingService
    {
        private readonly ILogger _logger;
        private int executionCount;

        public ParsingService(ILogger<ParsingService> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                SharedLogger.Logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}