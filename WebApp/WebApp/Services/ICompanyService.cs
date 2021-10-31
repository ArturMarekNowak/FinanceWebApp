using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAllCompanies();

        Task<Company> GetCompany(int companyId);
    }
}