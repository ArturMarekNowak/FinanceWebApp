using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Dto
{
    public sealed class AppUserDto
    {
        /// <summary>
        /// User's email address
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User's first name
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User's last name
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>
        /// User's password in plaintext
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string PasswordPlainText { get; set; } = string.Empty;
    }
}