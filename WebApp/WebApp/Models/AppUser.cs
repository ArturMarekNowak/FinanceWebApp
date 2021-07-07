using System;

namespace WebApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }
        
        public string Salt { get; set; }
        
        public DateTime LastActive { get; set; } = DateTime.Now;

        public DateTime CreatedAccount { get; set; } = DateTime.Now;

    }
}

