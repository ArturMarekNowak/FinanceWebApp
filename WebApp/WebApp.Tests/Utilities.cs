using System;
using WebApp.Data;
using WebApp.Models;

namespace BaseTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(AppDatabaseContext appDatabaseContext)
        {
            // User for testing GetUser
            appDatabaseContext.Users.Add(new User
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
            appDatabaseContext.Users.Add(new User
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

            // User for testing UpdateUser
            appDatabaseContext.Users.Add(new User
            {
                Email = "klm@mail.com",
                Salt = "789",
                CreatedAccount = DateTime.Now,
                FirstName = "opr",
                LastActive = DateTime.Now,
                LastName = "mln",
                PasswordHash = "zaq123",
                UserId = 3
            });

            appDatabaseContext.SaveChanges();
        }
    }
}