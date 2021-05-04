using MainPage.Entities;

namespace MainPage.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
