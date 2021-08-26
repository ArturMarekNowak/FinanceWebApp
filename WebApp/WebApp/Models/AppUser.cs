using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApp.Database;

namespace WebApp.Models
{
    public sealed class AppUser
    {
        public AppUser()
        {
            
        }
        
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
        
        [Key]
        public long UserId { get; set; }

        [Required]
        public string Email { get; set; } 

        [Required]
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; } 

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        public string Salt { get; set; }
        
        [Required]
        public DateTime CreatedAccount { get; set; } = DateTime.Now;

        [Required]
        public DateTime LastActive { get; set; } = DateTime.Now;
    }
}

