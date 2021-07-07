using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}