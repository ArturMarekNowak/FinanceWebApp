using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Helpers;

namespace WebApp
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

            CreatedAccount = DateTime.Now;
            LastActive = DateTime.Now;
        }
        
        /// <summary>
        /// User identication number
        /// </summary>
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAccount { get; set; }
        public DateTime LastActive { get; set; }
    }
}
