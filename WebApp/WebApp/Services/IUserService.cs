using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        ActionResult<AppUser> GetAllUsers();
    }
}