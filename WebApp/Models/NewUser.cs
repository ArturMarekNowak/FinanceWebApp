using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebApp.Models
{
    /// <summary>
    /// TO BE REFACTORED
    /// </summary>
    public sealed class NewUser
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string PasswordPlainText { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}