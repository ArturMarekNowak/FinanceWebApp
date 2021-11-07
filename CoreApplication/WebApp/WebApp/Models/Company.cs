using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Company
    {
        public long CompanyId { get; set; }
        
        public string Acronym { get; set; }
        
        public string FullName { get; set; }
        
    }
}
