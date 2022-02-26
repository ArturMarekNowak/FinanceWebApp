using System;
using System.Linq;
using WebApp.Helpers;

namespace WebApp.Models
{
    public partial class User
    {
        public User()
        {
        }

        public User(string email, string firstName, string lastName, string passwordPlainText)
        {
            Random random = new();

            Email = email;
            FirstName = firstName;
            LastName = lastName;

            Salt = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            PasswordHash = Hashing.GetSha512Hash(Salt + passwordPlainText);

            CreatedAccount = DateTime.Now.ToUniversalTime();
            LastActive = DateTime.Now.ToUniversalTime();
        }
        
        /// <summary>
        /// User's identification number
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// User's email address
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// User's hashed password
        /// </summary>
        public string PasswordHash { get; set; }
        
        /// <summary>
        /// User's password salt
        /// </summary>
        public string Salt { get; set; }
        
        /// <summary>
        /// User's account creation date
        /// </summary>
        public DateTimeOffset CreatedAccount { get; set; }
        
        /// <summary>
        /// User's last activity 
        /// </summary>
        public DateTimeOffset LastActive { get; set; }
    }
}
