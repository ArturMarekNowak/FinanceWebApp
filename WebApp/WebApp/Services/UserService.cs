using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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
        
        /// <inheritdoc/>
        public IQueryable<AppUser> GetAllUsers()
        {
            return _context.Users.AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<AppUser> GetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user is null)
                throw new NotFoundException($"User with Id {userId} does not exist");
                
            return await Task.FromResult(user);
        }

        /// <inheritdoc/>
        public async Task<long> AddUser(AppUserDto appUserDto)
        {
            var newUser = new AppUser(appUserDto.Email, appUserDto.FirstName, appUserDto.LastName,
                appUserDto.PasswordPlainText);
            _context.Add(newUser);
            await _context.SaveChangesAsync();

            return await Task.FromResult(newUser.UserId);
        }
        
        /// <inheritdoc/>
        public async Task DeleteUser(int userId)
        {
            var user = await GetUser(userId);
            if (user is null) throw new NotFoundException($"User with Id {userId} does not exist");
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<AppUser> UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = await GetUser(userId);

            if (user is null)
                throw new NotFoundException($"User with Id {userId} does not exist");
            
            _context.Users.First(u => u.UserId == userId).Email = appUserDto.Email;
            _context.Users.First(u => u.UserId == userId).FirstName = appUserDto.FirstName;
            _context.Users.First(u => u.UserId == userId).LastName = appUserDto.LastName;
            _context.Users.First(u => u.UserId == userId).PasswordHash = Helpers.Hashing.GetSha512Hash(_context.Users.First(u => u.UserId == userId).Salt + appUserDto.PasswordPlainText);
            await _context.SaveChangesAsync();
            
            return await Task.FromResult(user);
        }
    }
}