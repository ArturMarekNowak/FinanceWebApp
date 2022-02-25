using System;
using System.Collections.Generic;

namespace WebApp
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Acronym { get; set; }
        public string FullName { get; set; }
        public List<Price> Prices { get; set; }
    }
}
