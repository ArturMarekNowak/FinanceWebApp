using System.Linq;

namespace WebApp.Services
{
    public interface IPriceService
    {
        IQueryable<Price> GetAllPrices();
    }
}