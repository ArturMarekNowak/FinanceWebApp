using System.Collections.Generic;

namespace WebApp.Models
{
    public class Currency
    {
        /// <summary>
        /// Currency identification number 
        /// </summary>
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
        public List<Price> Prices { get; set; }
    }
}
