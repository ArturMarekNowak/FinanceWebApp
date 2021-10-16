using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Company
    {
        [Key]
        public long CompanyId { get; set; }
        
        public string Acronym { get; set; }
        
        public string FullName { get; set; }
    }
}