using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public sealed class Price
    {
        /// <summary>
        /// Price identification number
        /// </summary>
        [JsonIgnore]
        public int PriceId { get; set; }
        
        /// <summary>
        /// Closing price
        /// </summary>
        public decimal ClosingPrice { get; set; }
        
        /// <summary>
        /// Opening price
        /// </summary>
        public decimal OpeningPrice { get; set; }
        
        /// <summary>
        /// Highest price
        /// </summary>
        public decimal HighestPrice { get; set; }
        
        /// <summary>
        /// Lowest price
        /// </summary>
        public decimal LowestPrice { get; set; }
        
        /// <summary>
        /// Price timestamp
        /// </summary>
        public long TimeStamp { get; set; }
        
        /// <summary>
        /// Volume at timestamp
        /// </summary>
        public double Volume { get; set; }
       
        /// <summary>
        /// Foreign key property
        /// </summary>
        [JsonIgnore]
        public int CurrencyId { get; set; }
        
        /// <summary>
        /// Reference navigation property
        /// </summary>
        [JsonIgnore]
        public Currency Currency { get; set; }
    }
}
