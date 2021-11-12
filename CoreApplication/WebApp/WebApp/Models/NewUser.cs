using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Dto
{
    public sealed class NewUser
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = string.Empty;
        
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;
        
        [Required(AllowEmptyStrings = false)]
        public string PasswordPlainText { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}