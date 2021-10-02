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
    [Route("api/[controller]")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService _userController;
        public UsersController(IUserService userController)
        {
            _userController = userController;
        }

        [HttpGet]
        public ActionResult<List<AppUser>> GetAllUsers()
        {
             return _userController.GetAllUsers();
        }
        
        [HttpGet("{userId:int}")]
        public ActionResult<AppUser> GetUser(int userId)
        {
            var user = _userController.GetUser(userId);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AppUserDto appUserDto)
        {
           var userId = _userController.AddUser(appUserDto);

            return CreatedAtAction(nameof(AddUser), new { id = userId});
        }

        [HttpDelete("{userId:int}")]
        public IActionResult DeleteUser(int userId)
        {
            _userController.DeleteUser(userId);
            
            return Ok();
        }

        [HttpPut("{userId:int}")]
        public IActionResult UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = _userController.UpdateUser(userId, appUserDto);

            return Ok(user);
        }
        
    }
}