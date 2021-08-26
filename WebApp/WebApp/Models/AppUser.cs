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
        
        /// <summary>
        /// User's identification number
        /// </summary>
        [Key]
        public long UserId { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        [Required]
        public string Email { get; set; } 

        /// <summary>
        /// User's first name
        /// </summary>
        [Required]
        public string FirstName { get; set; } 

        /// <summary>
        /// User's last name
        /// </summary>
        [Required]
        public string LastName { get; set; } 

        /// <summary>
        /// User's hashed password
        /// </summary>
        [Required]
        public string PasswordHash { get; set; } 

        /// <summary>
        /// User's salt
        /// </summary>
        [Required]
        public string Salt { get; set; }
        
        /// <summary>
        /// User's account creation date
        /// </summary>
        [Required]
        public DateTime CreatedAccount { get; set; } = DateTime.Now;

        /// <summary>
        /// User's last activity
        /// </summary>
        [Required]
        public DateTime LastActive { get; set; } = DateTime.Now;
    }
}

