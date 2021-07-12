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

        // GET all action
        [HttpGet]
        public ActionResult<List<AppUser>> GetAllUsers()
        {
             return _userController.GetAllUsers();
        }
        
        // GET by Id action
        [HttpGet("{userId:int}")]
        public ActionResult<AppUser?> GetUser(int userId)
        {
            var user = _userController.GetUser(userId);
            if (user is null)
                return BadRequest();

            return user;
        }

        // POST action
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

        // DELETE action
        [HttpDelete("{userId:int}")]
        public IActionResult DeleteUser(int userId)
        {
            var rc = _userController.DeleteUser(userId);

            if (rc is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("{userId:int}")]
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