using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Dto;

namespace WebApp.Services
{
    public interface IUserService
    {
        List<AppUser> GetAllUsers();
        
        AppUser GetUser(int userId);

        long AddUser(AppUserDto appUserDto);
        
        void DeleteUser(int userId);

        AppUser UpdateUser(int userId, AppUserDto appUserDto);

    }
}