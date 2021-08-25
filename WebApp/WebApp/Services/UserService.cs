﻿using System;
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
        public AppDatabaseContext _context;
        
        public UserService(AppDatabaseContext context)
        {
            _context = context;
        }
        
        public List<AppUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public AppUser? GetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user is null)
                throw new BadRequestException($"User with Id {userId} does not exist");
                
            return user;
        }

        public void AddUser(AppUserDto appUserDto)
        {
            _context.Add(new AppUser(appUserDto.Email, appUserDto.FirstName, appUserDto.LastName, appUserDto.PasswordPlainText));
            _context.SaveChanges();
        }
        
        public void DeleteUser(int userId)
        {
            var user = GetUser(userId);
            if (user is null) throw new BadRequestException($"User with Id {userId} does not exist");
            _context.Remove(user);
            _context.SaveChanges();
        }

        public AppUser UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = GetUser(userId);

            if (user is null)
                throw new BadRequestException($"User with Id {userId} does not exist");
            
            _context.Users.First(u => u.UserId == userId).Email = appUserDto.Email;
            _context.Users.First(u => u.UserId == userId).FirstName = appUserDto.FirstName;
            _context.Users.First(u => u.UserId == userId).LastName = appUserDto.LastName;
            _context.Users.First(u => u.UserId == userId).PasswordHash = Helpers.Hashing.GetSha512Hash(_context.Users.First(u => u.UserId == userId).Salt + appUserDto.PasswordPlainText);
            _context.SaveChanges();
            
            return user;
        }
    }
}