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
        public ActionResult<AppUser> GetAllUsers()
        {
            using var db = new AppDatabaseContext();
            return db.Users.First(u => u.UserId == 2);
        }
    }
}