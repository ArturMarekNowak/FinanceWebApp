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
        IQueryable<User> GetAllUsers();
        
        Task<User> GetUser(int userId);
            
        Task<long> AddUser(NewUser appUserDto);
        
        Task DeleteUser(int userId);

        Task<User> UpdateUser(int userId, NewUser appUserDto);
    }
}