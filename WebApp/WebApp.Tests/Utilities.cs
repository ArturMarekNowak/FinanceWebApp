using System;
using WebApp.Database;
using WebApp.Models;

namespace BaseTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(AppDatabaseContext appDatabaseContext)
        {
            // User for testing GetUser
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
            
            // User for testing DeleteUser
            appDatabaseContext.Users.Add(new AppUser
            {
                Email = "def@mail.com",
                Salt = "123",
                CreatedAccount = DateTime.Now,
                FirstName = "abc",
                LastActive = DateTime.Now,
                LastName = "ghi",
                PasswordHash = "ytrewq",
                UserId = 2
            });

            appDatabaseContext.SaveChanges();
        }
    }
}