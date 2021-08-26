using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompanies();
        
        Task<Company> GetCompany(int companyId);
    }
}