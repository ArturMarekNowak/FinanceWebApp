using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApp.Models;
using WebApp.Dto;

namespace WebApp.Services
{
    public interface IUserService
    {
        Task<List<AppUser>> GetAllUsers(ODataQueryOptions<AppUser> options);
        
        Task<AppUser> GetUser(int userId);
            
        Task<long> AddUser(AppUserDto appUserDto);
        
        Task DeleteUser(int userId);

        Task<AppUser> UpdateUser(int userId, AppUserDto appUserDto);
    }
}