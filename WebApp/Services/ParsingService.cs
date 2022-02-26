using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    internal class ParsingService : IParsingService
    {
        public FinanceWebAppDatabaseContext Context;

        public ParsingService(FinanceWebAppDatabaseContext context)
        {
            Context = context;
        }

        public async Task RequestPrices(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                SharedLogger.Logger.LogInformation(
                    $"Scoped Processing Service is working. {DateTime.Now}");
                
                await Context.SaveChangesAsync(stoppingToken);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}