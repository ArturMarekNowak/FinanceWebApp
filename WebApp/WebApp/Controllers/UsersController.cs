using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("All")]
        public async Task<ActionResult<List<AppUser>>> GetAllUsers()
        {
             return await _userController.GetAllUsers();
        }
        
        [HttpGet]
        public async Task<ActionResult<AppUser>> GetUser(int userId)
        {
            var user = _userController.GetUser(userId);

            return await user;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AppUserDto appUserDto)
        {
           var userId = await _userController.AddUser(appUserDto);

            return Ok(userId);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userController.DeleteUser(userId);
            
            return Ok($"User {userId} deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = await _userController.UpdateUser(userId, appUserDto);

            return Ok(user);
        }
        
    }
}