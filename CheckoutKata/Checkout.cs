using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    // Placeholder class to satisfy the compiler; these will be implemented later as part of TDD
    public class Checkout
    {
        private readonly Dictionary<string, PricingRule> _pricingRules;
        private readonly Dictionary<string, int> _scannedItems;

        public Checkout(Dictionary<string, PricingRule> pricingRules)
        {
            _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
            _scannedItems = new Dictionary<string, int>();
        }
        public void Scan(string item)
        {
            if (!_pricingRules.ContainsKey(item))
            {
                throw new ArgumentException($"Invalid item: {item}");
            }

            if (_scannedItems.ContainsKey(item))
            {
                _scannedItems[item]++;
            }
            else
            {
                _scannedItems[item] = 1;
            }
        }
        [Obsolete]
        public Dictionary<string, int> GetAllScannedItems()
        {
            return _scannedItems;
        }
        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
