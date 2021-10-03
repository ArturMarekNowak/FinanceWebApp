using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Price
    {
        [Key] public long CompanyId { get; set; }

        public long PriceId { get; set; }

        public DateTime TimeStamp { get; set; }

        public float Value { get; set; }
    }
}