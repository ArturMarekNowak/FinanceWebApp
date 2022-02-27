using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class Currency
    {
        /// <summary>
        /// Currency identification number 
        /// </summary>
        [JsonIgnore]
        public int CurrencyId { get; set; }
        
        /// <summary>
        /// Currency symbol for display
        /// </summary>
        public string DisplaySymbol { get; set; }
        
        /// <summary>
        /// Currency symbol
        /// </summary>
        public string Symbol { get; set; }
        
        /// <summary>
        /// Currency description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collection of currency prices
        /// </summary>
        [JsonIgnore]
        public List<Price> Prices { get; set; } = new();
    }
}
