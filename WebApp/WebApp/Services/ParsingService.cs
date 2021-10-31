using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApp.Helpers;

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

                //Context.Prices.Add(new Price {CompanyId = 1, Value = 123.45, TimeStamp = DateTime.Now});

                Context.Users.Add(new User("123", "123", "123", "123"));
                Context.SaveChanges();

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}