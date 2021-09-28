using System;
using WebApp.Database;
using WebApp.Models;

namespace BaseTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(AppDatabaseContext appDatabaseContext)
        {
            appDatabaseContext.Users.Add(new AppUser
            {
                Email = "abc@mail.com",
                Salt = "123",
                CreatedAccount = DateTime.Now,
                FirstName = "abc",
                LastActive = DateTime.Now,
                LastName = "def",
                PasswordHash = "qwerty",
                UserId = 1
            });
        }
    }
}