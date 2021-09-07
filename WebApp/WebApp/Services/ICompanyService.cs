using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.Query;
using WebApp.Models;

namespace WebApp.Services
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAllCompanies();
        
        Task<Company> GetCompany(int companyId);
    }
}