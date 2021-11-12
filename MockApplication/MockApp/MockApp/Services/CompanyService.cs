using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockApp.Models;

namespace MockApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly FinanceWebAppMockDatabaseContext _context;

        public CompanyService(FinanceWebAppMockDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<CompanyShare> Get()
        {
            var companiesShares = new List<CompanyShare>();
            var companies = _context.Companies.AsEnumerable();

            foreach(var c in companies)
            {
                companiesShares.Add(new CompanyShare(c));
            }

            return companiesShares;
        }
    }
}
