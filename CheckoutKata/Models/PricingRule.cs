using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class PricingRule
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int? SpecialQuantity { get; set; }
        public decimal? SpecialPrice { get; set; }
    }
}
