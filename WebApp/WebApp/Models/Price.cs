using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public sealed class Price
    {
        public long CompanyId { get; set; }
        
        public long PriceId { get; set; }
        
        public string TimeStamp { get; set; }
        
        public byte[] Value { get; set; }
    }
}
