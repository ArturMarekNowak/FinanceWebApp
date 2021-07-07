using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        public UserService(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
    }
}