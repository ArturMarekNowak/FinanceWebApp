using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class PriceService : IPriceService
    {
        public FinanceWebAppDatabaseContext _context;

        public PriceService(FinanceWebAppDatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IQueryable<Price> GetAllPrices()
        {
            return new List<Price>().AsQueryable();
        }
    }
}