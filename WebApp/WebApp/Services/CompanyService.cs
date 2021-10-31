using System.Linq;
using System.Threading.Tasks;
using WebApp.Exceptions;

namespace WebApp.Services
{
    public class CompanyService : ICompanyService
    {
        public AppDatabaseContext _context;

        public CompanyService(AppDatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IQueryable<Company> GetAllCompanies()
        {
            return _context.Companies.AsQueryable();
        }

        /// <inheritdoc />
        public async Task<Company> GetCompany(int companyId)
        {
            var user = _context.Companies.FirstOrDefault(u => u.CompanyId == companyId);

            if (user is null)
                throw new NotFoundException($"User with Id {companyId} does not exist");

            return await Task.FromResult(user);
        }
    }
}