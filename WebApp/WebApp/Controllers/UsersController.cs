using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApp.Dto;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userController;
        public UsersController(IUserService userController)
        {
            _userController = userController;
        }

        [HttpGet("All")]
        public ActionResult<List<AppUser>> GetAllUsers()
        {
             return _userController.GetAllUsers();
        }
        
        [HttpGet]
        public ActionResult<AppUser?> GetUser(int userId)
        {
            var user = _userController.GetUser(userId);

            return user;
        }

        [HttpPost]
        public IActionResult AddUser(AppUserDto appUserDto)
        {
           _userController.AddUser(appUserDto);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            _userController.DeleteUser(userId);
            
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = _userController.UpdateUser(userId, appUserDto);

            return Ok(user);
        }
        
    }
}