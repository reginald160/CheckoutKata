using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Test.Mock
{
    public class MockPriceRuleRepository : IMockPriceRuleRepository
    {
        public  Dictionary<string, PricingRule> GetSamplePricingRules()
        {
            Dictionary<string, PricingRule> sampleData = new Dictionary<string, PricingRule>
            {
                { "A", new PricingRule { SKU = "A", UnitPrice = 50, SpecialQuantity = 3, SpecialPrice = 130 } },
                { "B", new PricingRule { SKU = "B", UnitPrice = 30, SpecialQuantity = 2, SpecialPrice = 45 } },
                { "C", new PricingRule { SKU = "C", UnitPrice = 20 } },
                { "D", new PricingRule { SKU = "D", UnitPrice = 15 } },
                { "E", new PricingRule { SKU = "E", UnitPrice = 70, SpecialQuantity = 4, SpecialPrice = 260 } },
                { "F", new PricingRule { SKU = "F", UnitPrice = 25, SpecialQuantity = 5, SpecialPrice = 100 } },
                { "G", new PricingRule { SKU = "G", UnitPrice = 40 } },
                { "H", new PricingRule { SKU = "H", UnitPrice = 60, SpecialQuantity = 6, SpecialPrice = 300 } },
                { "I", new PricingRule { SKU = "I", UnitPrice = 35, SpecialQuantity = 3, SpecialPrice = 90 } },
                { "J", new PricingRule { SKU = "J", UnitPrice = 45, SpecialQuantity = 4, SpecialPrice = 160 } },
                { "K", new PricingRule { SKU = "K", UnitPrice = 10, SpecialQuantity = 10, SpecialPrice = 80 } },
                { "L", new PricingRule { SKU = "L", UnitPrice = 100 } }

            };

            return sampleData;
        }
    }
}
