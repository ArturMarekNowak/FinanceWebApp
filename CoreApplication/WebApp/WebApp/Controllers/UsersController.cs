using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.OData;
using WebApp.Dto;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [ActionsFilter]
    [Route("api/Users")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public sealed class UsersController : ODataController
    {
        private readonly IUserService _userController;
        public UsersController(IUserService userController)
        {
            _userController = userController;
        }
        
        /// <summary>
        /// This method retrieves all clients registered on application
        /// </summary>
        /// <returns>List of User objects</returns>
        /// <response code="200">Clients list returned successfully</response>
        [HttpGet]
        [EnableQuery(PageSize = 100)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
             var users = _userController.GetAllUsers();

             return Ok(users);
        }
        
        /// <summary>
        /// This method retrieves single client
        /// </summary>
        /// <param name="userId">User identification number</param>
        /// <returns>Single User objects</returns>
        /// <response code="200">Client returned successfully</response>
        /// <response code="404">Client not found</response>
        [HttpGet("{userId:long}")]
        [ODataIgnored]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = _userController.GetUser(userId);

            return await user;
        }
        
        
        /// <summary>
        /// This method adds single client
        /// </summary>
        /// <param name="appUserDto">UserDto object</param>
        /// <returns>Newly added user identification number</returns>
        /// <response code="201">Client created successfully</response>
        [HttpPost]
        [ODataIgnored]
        [ProducesResponseType(201), ProducesResponseType(404)]
        public async Task<ActionResult<long>> AddUser(NewUser appUserDto)
        {
           var userId = await _userController.AddUser(appUserDto);

            return CreatedAtAction(nameof(AddUser), new { id = userId});
        }
        
        /// <summary>
        /// This method deletes a single client
        /// </summary>
        /// <param name="userId">User identification number</param>
        /// <returns>Deleted user identification number</returns>
        /// <response code="200">Client deleted successfully</response>
        /// <response code="404">Client not found</response>
        [HttpDelete("{userId:long}")]
        [ODataIgnored]
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
        /// <param name="appUserDto">UserDto object</param>
        /// <returns>Updated user UserDto object</returns>
        /// <response code="200">Client updated successfully</response>
        /// <response code="404">Client not found</response>
        [HttpPut("{userId:long}")]
        [ODataIgnored]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser(int userId, NewUser appUserDto)
        {
            var user = await _userController.UpdateUser(userId, appUserDto);

            return Ok(user);
        }
    }
}