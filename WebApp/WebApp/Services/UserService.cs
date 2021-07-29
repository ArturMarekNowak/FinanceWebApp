using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Database;
using WebApp.Models;
using WebApp.Dto;

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

        public int? AddUser(AppUserDto appUserDto)
        {
            using var db = new AppDatabaseContext();
            {
                db.Add(new AppUser(appUserDto.Email, appUserDto.FirstName, appUserDto.LastName, appUserDto.PasswordPlainText));
                db.SaveChanges();
            }
            return 0;
        }
        
        public int? DeleteUser(int userId)
        {
            using var db = new AppDatabaseContext();
            {
                var user = GetUser(userId);
                if (user is not null)
                {
                    db.Remove(user);
                    db.SaveChanges();
                    return 0;
                }
                else
                {
                    return null;
                }
            }
        }

        public int? UpdateUser(int userId, AppUserDto appUserDto)
        {
            var client = GetUser(userId);

            if (client is null)
                return null;
            
            using var db = new AppDatabaseContext();
            {
                db.Users.First(u => u.UserId == userId).Email = appUserDto.Email;
                db.Users.First(u => u.UserId == userId).FirstName = appUserDto.FirstName;
                db.Users.First(u => u.UserId == userId).LastName = appUserDto.LastName;
                db.Users.First(u => u.UserId == userId).PasswordHash = Helpers.Hashing.GetSha512Hash(db.Users.First(u => u.UserId == userId).Salt + appUserDto.PasswordPlainText);
                db.SaveChanges();
            }
            return 0;
        }
    }
}