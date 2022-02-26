using System.Linq;
using System.Threading.Tasks;
using WebApp.Exceptions;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class CurrenciesService : ICurrenciesService
    {
        private readonly FinanceWebAppDatabaseContext _context;

        public CurrenciesService(FinanceWebAppDatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IQueryable<Currency> GetAllCurrencies()
        {
            return _context.Currencies.AsQueryable();
        }

        /// <inheritdoc />
        public async Task<Currency> GetCurrency(int currencyId)
        {
            var currency = _context.Currencies.FirstOrDefault(u => u.CurrencyId == currencyId);

            if (currency is null)
                throw new NotFoundException($"User with Id {currencyId} does not exist");

            return await Task.FromResult(currency);
        }
    }
}