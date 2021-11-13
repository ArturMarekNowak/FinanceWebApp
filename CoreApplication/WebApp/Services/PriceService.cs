﻿using System.Linq;

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
            return _context.Prices.AsQueryable();
        }
    }
}