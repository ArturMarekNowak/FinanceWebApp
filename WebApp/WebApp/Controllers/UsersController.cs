using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound();

            return user;
        }

        // POST action

        // PUT action

        // DELETE action
    }
}