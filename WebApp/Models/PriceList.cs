using System.Collections.Generic;
using System.Numerics;

namespace WebApp.Models
{
    public class PriceList
    {
        public List<decimal> c { get; set; }
        public List<decimal> h { get; set; }
        public List<decimal> l { get; set; }
        public List<decimal> o { get; set; }
        public string s { get; set; }
        public List<long> t { get; set; }
        public List<double> v { get; set; }
    }
}