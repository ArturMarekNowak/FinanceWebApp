using System;
using System.Linq;
using WebApp.Database;

namespace WebApp.Models
{
    public sealed class AppUser
    {
        public AppUser(string email, string firstName, string lastName, string passwordPlainText)
        {
            Random random = new();

            Email = email;
            FirstName = firstName;
            LastName = lastName;
            
            Salt = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", 8)
                .Select(s => s[random.Next(s.Length)]).ToArray()); 
            
            PasswordHash = Helpers.Hashing.GetSha512Hash(Salt + passwordPlainText);
            
            CreatedAccount = DateTime.Now;
            LastActive = DateTime.Now;
        }

        public int UserId { get; set; }

        public string Email { get; set; } 

        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string PasswordHash { get; set; } 

        public string Salt { get; set; }
        
        public DateTime CreatedAccount { get; set; } = DateTime.Now;

        public DateTime LastActive { get; set; } = DateTime.Now;
    }
}

