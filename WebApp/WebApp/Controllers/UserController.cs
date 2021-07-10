using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userController;
        public UserController(IUserService userController)
        {
            _userController = userController;
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
             return _userController.GetAllUsers();
        }
        
        // GET by Id action

        // POST action

        // PUT action

        // DELETE action
    }
}