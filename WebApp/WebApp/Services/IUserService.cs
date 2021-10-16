using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApp.Models;
using WebApp.Dto;

namespace WebApp.Services
{
    public interface IUserService
    {
        IQueryable<AppUser> GetAllUsers();
        
        Task<AppUser> GetUser(int userId);
            
        Task<long> AddUser(AppUserDto appUserDto);
        
        Task DeleteUser(int userId);

        Task<AppUser> UpdateUser(int userId, AppUserDto appUserDto);
    }
}