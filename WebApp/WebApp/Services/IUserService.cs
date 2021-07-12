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
        
        AppUser? GetUser(int userId);

        int? AddUser(AppUserDto appUserDto);
        
        int? DeleteUser(int userId);

        int? UpdateUser(int userId, AppUserDto appUserDto);

    }
}