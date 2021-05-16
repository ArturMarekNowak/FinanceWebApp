using FinanceWebApp.Entities;

namespace FinanceWebApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
