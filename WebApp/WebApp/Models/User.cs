using System;
using System.Linq;
using System.Text.Json;

#nullable disable

namespace WebApp.Models
{
    public sealed class User
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
            
            PasswordHash = Helpers.Hashing.GetSha512Hash(Salt + passwordPlainText);
            
            CreatedAccount = DateTime.Now;
            LastActive = DateTime.Now;
        }
        
        public long UserId { get; set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string Salt { get; set; }
        
        public DateTime CreatedAccount { get; set; }
        
        public DateTime LastActive { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
