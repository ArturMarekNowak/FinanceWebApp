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
            if (user is null)
                return BadRequest();

            return user;
        }

        [HttpPost]
        public IActionResult AddUser(AppUserDto appUserDto)
        {
            var rc = _userController.AddUser(appUserDto);

            if (rc is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            var rc = _userController.DeleteUser(userId);

            if (rc is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser(int userId, AppUserDto appUserDto)
        {
            var rc = _userController.UpdateUser(userId, appUserDto);

            if (rc is null)
            {
                return BadRequest();
            }

            return NoContent();
        }
        
    }
}