using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface ICurrenciesService
    {
        IQueryable<Currency> GetAllCurrencies();

        Task<Currency> GetCurrency(int currencyId);
    }
}