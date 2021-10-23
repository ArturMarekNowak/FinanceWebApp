using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Services
{
    internal interface IParsingService
    {
        Task RequestPrices(CancellationToken stoppingToken);
    }
}