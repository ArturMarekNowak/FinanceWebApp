using System;

#nullable disable

namespace WebApp
{
    public class Price
    {
        public int PriceId { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}