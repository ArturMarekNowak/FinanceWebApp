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
        public ActionResult<AppUser> GetAllUsers()
        {
             return _userController.GetAllUsers();
        }
        
        // GET by Id action

        // POST action

        // PUT action

        // DELETE action
    }
}