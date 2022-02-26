using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Services.Interfaces
{
    internal interface IParsingService
    {
        Task RequestPrices(CancellationToken stoppingToken);
    }
}