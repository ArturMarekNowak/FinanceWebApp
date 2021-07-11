using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        List<AppUser> GetAllUsers();
        
        AppUser? GetUser(int userId);
    }
}