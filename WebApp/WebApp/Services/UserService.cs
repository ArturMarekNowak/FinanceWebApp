using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private List<User> Users { get; }

        public UserService()
        {
            Users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Email = "michealscott@dundermifflin.com",
                    FirstName = "Micheal",
                    LastName = "Scott",
                    PasswordHash =
                        "ff84e26fa8ec994de3d803c6d23ee694a88ab5f2331c44fb665cdb4ec0a80dca77b2b94d8103b406ab3cebadd89e3bac9713f6e4caee5fad5322808e2ba26245",
                    Salt = "abcdefgh",
                    LastActive = new DateTime(2021, 7, 1, 10, 10, 10),
                    CreatedAccount = new DateTime(2021, 6, 1, 10, 10, 10)
                }
            };
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }
    }
}