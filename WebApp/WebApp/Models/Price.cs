using System;

#nullable disable

namespace WebApp.Models
{
    public sealed class Price
    {
        public long CompanyId { get; set; }

        public long PriceId { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Value { get; set; }
    }
}