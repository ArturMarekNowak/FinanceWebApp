using System.Collections.Generic;

#nullable disable

namespace WebApp
{
    public class Company
    {
        public Company()
        {
            Prices = new HashSet<Price>();
        }

        public int CompanyId { get; set; }
        public string Acronym { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
    }
}