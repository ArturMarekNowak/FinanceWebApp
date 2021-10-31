using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Services
{
    internal class ParsingService : IParsingService
    {
        public AppDatabaseContext Context;

        public ParsingService(AppDatabaseContext context)
        {
            Context = context;
        }

        public async Task RequestPrices(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                SharedLogger.Logger.LogInformation(
                    $"Scoped Processing Service is working. {DateTime.Now}");

                Context.Prices.Add(new Price {CompanyId = 1, Value = 123.45, TimeStamp = DateTime.Now});
                Context.SaveChanges();

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}