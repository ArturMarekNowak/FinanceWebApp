using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApp
{
    public class Price
    {
        [Key] public long CompanyId { get; set; }

        [Key] public DateTime TimeStamp { get; set; }

        public double Value { get; set; }

        public virtual Company Company { get; set; }
    }
}