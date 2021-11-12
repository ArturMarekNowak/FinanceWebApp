using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto;

namespace WebApp.Services
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