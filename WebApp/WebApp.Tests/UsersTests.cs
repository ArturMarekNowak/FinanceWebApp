﻿using System.Net;
using System.Net.Http.Json;
using NUnit.Framework;
using WebApp.Dto;

namespace BaseTests
{
    public class UsersTests : BaseTests
    {
        [Test]
        public void GetAllUsers_Ok()
        {
            var response = _client.GetAsync("api/Users").Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public void AddUser_Created()
        {
            var response = _client.PostAsJsonAsync("api/Users", new AppUserDto
            {
                Email = "ghi@mail.com", 
                FirstName = "John", 
                LastName = "Malkovich", 
                PasswordPlainText = "strawberry"
            }).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        
        [Test]
        public void AddUser_BadRequest_EmailIsAlreadyInDatabase()
        {
            var response = _client.PostAsJsonAsync("api/Users", new AppUserDto
            {
                Email = "abc@mail.com", 
                FirstName = "John", 
                LastName = "Malkovich", 
                PasswordPlainText = "strawberry"
            }).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void GetUser_Ok()
        {
            var response = _client.GetAsync("api/Users/1").Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public void GetUser_BadRequest_WrongId()
        {
            var response = _client.GetAsync("api/Users/-1234").Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void DeleteUser_BadRequest_WrongId()
        {
            var response = _client.DeleteAsync("api/Users/-1234").Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void DeleteUser_Ok()
        {
            var response = _client.DeleteAsync("api/Users/2").Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public void UpdateUser_Ok()
        {
            var response = _client.PutAsJsonAsync("api/Users/3", new AppUserDto
            {
                Email = "xyz@mail.com", 
                FirstName = "John", 
                LastName = "Malkovich", 
                PasswordPlainText = "strawberry"
            } ).Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public void UpdateUser_BadRequest_WrongId()
        {
            var response = _client.PutAsJsonAsync("api/Users/12345678", new AppUserDto
            {
                Email = "abcdef@mail.com", 
                FirstName = "John", 
                LastName = "Malkovich", 
                PasswordPlainText = "strawberry"
            } ).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}