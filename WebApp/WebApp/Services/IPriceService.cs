using System.Linq;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IPriceService
    {
        IQueryable<CompanyPrice> GetAllPrices();
    }
}