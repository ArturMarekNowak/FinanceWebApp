using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using WebApp.Models;
using WebApp.Dto;
using WebApp.Exceptions;

namespace WebApp.Services
{
    public sealed class UserService : IUserService
    {
        public AppDatabaseContext _context;
        
        public UserService(AppDatabaseContext context)
        {
            _context = context;
        }
        
        public Task<List<AppUser>> GetAllUsers()
        {
            return Task.FromResult(_context.Users.ToList());
        }

        public async Task<AppUser> GetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user is null)
                throw new BadRequestException($"User with Id {userId} does not exist");
                
            return await Task.FromResult(user);
        }

        public async Task<long> AddUser(AppUserDto appUserDto)
        {
            var newUser = new AppUser(appUserDto.Email, appUserDto.FirstName, appUserDto.LastName,
                appUserDto.PasswordPlainText);
            _context.Add(newUser);
            await _context.SaveChangesAsync();

            return await Task.FromResult(newUser.UserId);
        }
        
        public async Task DeleteUser(int userId)
        {
            var user = await GetUser(userId);
            if (user is null) throw new BadRequestException($"User with Id {userId} does not exist");
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = await GetUser(userId);

            if (user is null)
                throw new BadRequestException($"User with Id {userId} does not exist");
            
            _context.Users.First(u => u.UserId == userId).Email = appUserDto.Email;
            _context.Users.First(u => u.UserId == userId).FirstName = appUserDto.FirstName;
            _context.Users.First(u => u.UserId == userId).LastName = appUserDto.LastName;
            _context.Users.First(u => u.UserId == userId).PasswordHash = Helpers.Hashing.GetSha512Hash(_context.Users.First(u => u.UserId == userId).Salt + appUserDto.PasswordPlainText);
            await _context.SaveChangesAsync();
            
            return await Task.FromResult(user);
        }
    }
}