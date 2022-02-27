using System.Linq;
using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface IPriceService
    {
        IQueryable<Price> GetAllPrices(string symbol);
    }
}