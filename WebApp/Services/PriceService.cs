using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Price> GetAllPrices(string symbol)
        {
            var c = _context.Currencies.Include(c => c.Prices).FirstOrDefault(c => c.Symbol == symbol);
            
            return c.Prices.AsQueryable();
        }
    }
}