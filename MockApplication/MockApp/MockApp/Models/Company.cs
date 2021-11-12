using System;
using System.Collections.Generic;

#nullable disable

namespace MockApp.Models
{
    public partial class Company
    {
        public long CompanyId { get; set; }
        public string Acronym { get; set; }
        public string FullName { get; set; }
    }

    public partial class CompanyShare
    {
        public long CompanyId { get; set; }
        public string Acronym { get; set; }
        public string FullName { get; set; }
        public double Price { get; set; }

        public CompanyShare(Company company)
        {
            var rng = new Random();
            var timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()/3600;

            CompanyId = company.CompanyId;
            Acronym = company.Acronym;
            FullName = company.FullName;
            Price = (CompanyId / 10) * Math.Sin(2 * Math.PI * (1 / 48) * timestamp) * 1.5 * Math.Sin(0.5 * timestamp) + 100 + 10*rng.NextDouble() - 5;
        }
    }
}
