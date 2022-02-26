using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        Task<User> GetUser(int userId);

        Task<long> AddUser(NewUser appUserDto);

        Task DeleteUser(int userId);

        Task<User> UpdateUser(int userId, NewUser appUserDto);
    }
}