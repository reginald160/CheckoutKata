﻿using CheckoutKata.Interface;
using CheckoutKata.Models;
using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    /// <summary>
    /// Represents a checkout system that processes scanned items and calculates the total price based on pricing rules.
    /// </summary>
    public class Checkout : ICheckout
    {
        /// <summary>
        /// Stores the pricing rules for the items.
        /// </summary>
        private readonly Dictionary<string, PricingRule> _pricingRules;

        /// <summary>
        /// Stores the scanned items and their quantities.
        /// </summary>
        private readonly Dictionary<string, int> _scannedItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="pricingRules">A dictionary of pricing rules for items, where the key is the SKU.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="pricingRules"/> is null.</exception>
        public Checkout(Dictionary<string, PricingRule> pricingRules)
        {
            _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
            _scannedItems = new Dictionary<string, int>();
        }

        /// <summary>
        /// Scans an item and updates its quantity in the checkout system.
        /// </summary>
        /// <param name="item">The SKU of the item to scan.</param>
        /// <exception cref="ArgumentException">Thrown when the item is not found in the pricing rules.</exception>
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

        /// <summary>
        /// Gets all scanned items and their respective quantities.
        /// </summary>
        /// <returns>A dictionary where the key is the SKU and the value is the quantity of scanned items.</returns>
        [Obsolete("This method is deprecated and is only intended for debugging purposes.")]
        public Dictionary<string, int> GetAllScannedItems()
        {
            return _scannedItems;
        }

        /// <summary>
        /// Calculates the total price for all scanned items based on the pricing rules.
        /// </summary>
        /// <returns>The total price as a decimal value.</returns>
        public decimal GetTotalPrice()
        {
            decimal total = 0;

            foreach (var item in _scannedItems)
            {
                PricingRule rule = _pricingRules[item.Key];
                int quantity = item.Value;

                if (rule.SpecialQuantity.HasValue && rule.SpecialPrice.HasValue)
                {
                    // Calculate the price for special bundles and remaining items.
                    int specialBundles = quantity / rule.SpecialQuantity.Value;
                    int remainingItems = quantity % rule.SpecialQuantity.Value;
                    total += (specialBundles * rule.SpecialPrice.Value) + (remainingItems * rule.UnitPrice);
                }
                else
                {
                    // Calculate the price for items without special pricing.
                    total += quantity * rule.UnitPrice;
                }
            }

            return total;
        }
    }
}
