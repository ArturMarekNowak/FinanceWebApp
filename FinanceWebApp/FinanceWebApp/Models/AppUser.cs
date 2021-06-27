using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceWebApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }
        
        public string SaltHash { get; set; }

        /*
        public DateTime LastActive { get; set; } = DateTime.Now;

        public DateTime CreatedAccount { get; set; } = DateTime.Now;
        */

    }
}
