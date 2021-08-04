using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Database;
using WebApp.Models;
using WebApp.Dto;
using WebApp.Exceptions;

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

                if (user is null)
                    throw new BadRequestException($"User with Id {userId} does not exist");
                
                return user;
            }
        }

        public void AddUser(AppUserDto appUserDto)
        {
            using var db = new AppDatabaseContext();
            {
                db.Add(new AppUser(appUserDto.Email, appUserDto.FirstName, appUserDto.LastName, appUserDto.PasswordPlainText));
                db.SaveChanges();
            }
            
        }
        
        public void DeleteUser(int userId)
        {
            using var db = new AppDatabaseContext();
            {
                var user = GetUser(userId);
                if (user is null) throw new BadRequestException($"User with Id {userId} does not exist");
                db.Remove(user);
                db.SaveChanges();
            }
        }

        public AppUser UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = GetUser(userId);

            if (user is null)
                throw new BadRequestException($"User with Id {userId} does not exist");
            
            using var db = new AppDatabaseContext();
            {
                db.Users.First(u => u.UserId == userId).Email = appUserDto.Email;
                db.Users.First(u => u.UserId == userId).FirstName = appUserDto.FirstName;
                db.Users.First(u => u.UserId == userId).LastName = appUserDto.LastName;
                db.Users.First(u => u.UserId == userId).PasswordHash = Helpers.Hashing.GetSha512Hash(db.Users.First(u => u.UserId == userId).Salt + appUserDto.PasswordPlainText);
                db.SaveChanges();
            }

            return user;
        }
    }
}