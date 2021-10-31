using System.Linq;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class PriceService : IPriceService
    {
        public AppDatabaseContext _context;

        public PriceService(AppDatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IQueryable<Price> GetAllPrices()
        {
            return _context.Prices.AsQueryable();
        }
    }
}