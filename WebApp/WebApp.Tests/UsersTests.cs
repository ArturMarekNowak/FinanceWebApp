using System;
using System.Net;
using NUnit.Framework;
using WebApp.Controllers;
using WebApp.Services;

namespace BaseTests
{
    public class UsersTests : BaseTests
    {
        [Test]
        public void GetAllUsersOk()
        {
            var response = _client.GetAsync("api/Users");
            
            Console.WriteLine(response);
            
            Assert.AreEqual(HttpStatusCode.OK, response);
        }
        
        [Test]
        public void GetUserOk()
        {
            Assert.Pass();
        }
    }
}