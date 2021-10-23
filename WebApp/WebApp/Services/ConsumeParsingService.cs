using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApp.Helpers;

namespace WebApp.Services
{
    public class ConsumeParsingService : BackgroundService
    {
        public ConsumeParsingService(IServiceProvider services)
        {
            Services = services;
        }

        private IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SharedLogger.Logger.LogInformation("Consume Scoped Service Hosted Service running");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IParsingService>();

                await scopedProcessingService.RequestPrices(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            SharedLogger.Logger.LogInformation("Consume Scoped Service Hosted Service is stopping");

            await base.StopAsync(stoppingToken);
        }
    }
}