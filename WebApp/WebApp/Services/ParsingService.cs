using System;
using System.Linq;
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

                //Context.Prices.Add(new Price {Company = Value = 123.45, TimeStamp = DateTime.Now});
                //Context.Companies.Add(new Company {Acronym = "AAA", FullName = "AAA Company"});

                var company = Context.Companies.FirstOrDefault(c => c.CompanyId == 2);

                company.Prices.Add(new Price {Value = 123.45, TimeStamp = DateTime.Now});

                Context.SaveChanges();

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}