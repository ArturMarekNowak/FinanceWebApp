using System;

namespace WebApp.Models
{
    public sealed class Price
    {
        /// <summary>
        /// Price identification number
        /// </summary>
        public int PriceId { get; set; }
        
        /// <summary>
        /// Closing price
        /// </summary>
        public decimal? ClosingPrice { get; set; }
        
        /// <summary>
        /// Opening price
        /// </summary>
        public decimal? OpeningPrice { get; set; }
        
        /// <summary>
        /// Highest price
        /// </summary>
        public decimal? HighestPrice { get; set; }
        
        /// <summary>
        /// Lowest price
        /// </summary>
        public decimal? LowestPrice { get; set; }
        
        /// <summary>
        /// API response status
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Price timestamp
        /// </summary>
        public DateTimeOffset? TimeStamp { get; set; }
        
        /// <summary>
        /// Volume at timestamp
        /// </summary>
        public long? Volume { get; set; }
    }
}
