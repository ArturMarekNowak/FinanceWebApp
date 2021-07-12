using System;
using System.Linq;
using WebApp.Database;

namespace WebApp.Models
{
    public class AppUser
    {
        public AppUser()
        {
            
        }


        public AppUser(string email, string firstName, string lastName, string passwordPlainText)
        {
            Random random = new();

            using (var db = new AppDatabaseContext())
            {
                try
                {
                    UserId = db.Users.OrderByDescending(u => u.UserId).First().UserId + 1;
                }
                catch
                {
                    UserId = 1;
                }
            }

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

