using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;
using WebApp.Exceptions;
using WebApp.Models;

namespace WebApp.Services
{
    public class CompanyService : ICompanyService
    {
        public AppDatabaseContext _context;
        
        public CompanyService(AppDatabaseContext context)
        {
            _context = context;
        }
        
        /// <inheritdoc/>
        public Task<List<Company>> GetAllCompanies()
        {
            return Task.FromResult(_context.Companies.ToList());
        }

        /// <inheritdoc/>
        public async Task<Company> GetCompany(int companyId)
        {
            var user = _context.Companies.FirstOrDefault(u => u.CompanyId == companyId);

            if (user is null)
                throw new BadRequestException($"User with Id {companyId} does not exist");
                
            return await Task.FromResult(user);
        }
    }
}