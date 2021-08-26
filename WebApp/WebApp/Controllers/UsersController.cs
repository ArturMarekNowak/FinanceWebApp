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

        /// <summary>
        /// This method retrieves all clients registered on application
        /// </summary>
        /// <returns>List of AppUser objects</returns>
        /// <response code="200">Clients list returned successfully</response>
        [HttpGet("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<AppUser>>> GetAllUsers()
        {
             return await _userController.GetAllUsers();
        }
        
        /// <summary>
        /// This method retrieves single client
        /// </summary>
        /// <param name="userId">User identification number</param>
        /// <returns>Single AppUser objects</returns>
        /// <response code="200">Client returned successfully</response>
        /// <response code="404">Client not found</response>
        [HttpGet("{userId:long}")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public async Task<ActionResult<AppUser>> GetUser(int userId)
        {
            var user = _userController.GetUser(userId);

            return await user;
        }
        
        /// <summary>
        /// This method adds single client
        /// </summary>
        /// <param name="appUserDto">AppUserDto object</param>
        /// <returns>Newly added user identification number</returns>
        /// <response code="201">Client created successfully</response>
        [HttpPost]
        [ProducesResponseType(201), ProducesResponseType(404)]
        public async Task<ActionResult<long>> AddUser(AppUserDto appUserDto)
        {
           var userId = await _userController.AddUser(appUserDto);

            return CreatedAtAction(nameof(AddUser), new {Id = userId});
        }

        /// <summary>
        /// This method deletes a single client
        /// </summary>
        /// <param name="userId">User identification number</param>
        /// <returns>Deleted user identification number</returns>
        /// <response code="200">Client deleted successfully</response>
        /// <response code="404">Client not found</response>
        [HttpDelete("{userId:long}")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userController.DeleteUser(userId);
            
            return Ok($"User {userId} deleted");
        }

        /// <summary>
        /// This method updates a single client
        /// </summary>
        /// <param name="userId">User identification number</param>
        /// <param name="appUserDto">AppUserDto object</param>
        /// <returns>Updated user AppUserDto object</returns>
        /// <response code="200">Client updated successfully</response>
        /// <response code="404">Client not found</response>
        [HttpPut("{userId:long}")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser(int userId, AppUserDto appUserDto)
        {
            var user = await _userController.UpdateUser(userId, appUserDto);

            return Ok(user);
        }
        
    }
}