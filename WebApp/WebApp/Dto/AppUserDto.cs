using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Dto
{
    public sealed class AppUserDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;
        
        [Required(AllowEmptyStrings = false)]
        public string PasswordPlainText { get; set; } = string.Empty;
    }
}