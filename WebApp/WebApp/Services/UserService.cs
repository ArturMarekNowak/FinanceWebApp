using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using WebApp.Models;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        public List<AppUser> GetAllUsers()
        {
            using var db = new AppDatabaseContext();
            {
                return db.Users.ToList();
            }
        }

        public AppUser? GetUser(int userId)
        {
            using var db = new AppDatabaseContext();
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                return user;
            }
        }
    }
}