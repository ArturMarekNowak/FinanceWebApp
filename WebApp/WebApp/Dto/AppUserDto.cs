using System;

namespace WebApp.Dto
{
    public sealed class AppUserDto
    {
        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string PasswordPlainText { get; set; } = string.Empty;
    }
}