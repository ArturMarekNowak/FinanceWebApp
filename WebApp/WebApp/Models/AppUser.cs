using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AppUser
    {
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

