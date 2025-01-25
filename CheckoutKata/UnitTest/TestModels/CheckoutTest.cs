﻿using CheckoutKata.Models;
using CheckoutKata.UnitTest.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckoutKata.UnitTest.Models
{
    public class CheckoutTest
    {
        private Dictionary<string, PricingRule> _pricingRules = new Dictionary<string, PricingRule>();
        public CheckoutTest()
        {
            _pricingRules = PrincipleRuleContext.GetSamplePricingRules();
        }

        [Fact]
        public void TestScanMethod()
        {
            // Arrange
            var pricingRules = new Dictionary<string, PricingRule>
            {
                { "A", new PricingRule { SKU = "A", UnitPrice = 50 } },
                { "B", new PricingRule { SKU = "B", UnitPrice = 30 } },
                { "C", new PricingRule { SKU = "C", UnitPrice = 20 } }
            };

            var checkout = new Checkout(pricingRules);

            // Act & Assert: Valid items
            checkout.Scan("A"); // Scanning item A
            Assert.Single(checkout.GetAllScannedItems()); // Only 1 unique item scanned so far
            Assert.Equal(1, checkout.GetAllScannedItems()["A"]); // Count of A should be 1

            checkout.Scan("A"); // Scanning item A again
            Assert.Equal(2, checkout.GetAllScannedItems()["A"]); // Count of A should now be 2

            checkout.Scan("B"); // Scanning item B
            checkout.Scan("B"); // Scanning item B
            Assert.Equal(1, checkout.GetAllScannedItems()["B"]); // Count of B should be 1

            checkout.Scan("B"); // Scanning item B
            checkout.Scan("B"); // Scanning item B
            Assert.Equal(6, checkout.GetAllScannedItems().Count); // Count of B should be 1

            // Act & Assert: Invalid item
            var ex = Assert.Throws<ArgumentException>(() => checkout.Scan("X"));
            Assert.Equal("Invalid item: X", ex.Message); // Ensure the error message is correct
        }

        [Fact]
        public void TestForEmptyCart()
        {
            var checkout = new Checkout(_pricingRules);

            Assert.Equal(0, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestForInvalidItem()
        {
            var checkout = new Checkout(_pricingRules);

            Assert.Throws<ArgumentException>(() => checkout.Scan("X  invlaid item")); // Invalid SKU
        }

        [Fact]
        public void TestForSinglePricing()
        {
            var checkout = new Checkout(_pricingRules);

            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());

            checkout.Scan("C");
            Assert.Equal(70, checkout.GetTotalPrice());

            checkout.Scan("D");
            Assert.Equal(85, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestForSpecialPricing()
        {
            var checkout = new Checkout(_pricingRules);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.Equal(130, checkout.GetTotalPrice());

            checkout.Scan("B");
            checkout.Scan("B");
            Assert.Equal(175, checkout.GetTotalPrice());

            checkout.Scan("E");
            checkout.Scan("E");
            checkout.Scan("E");
            checkout.Scan("E");
            Assert.Equal(435, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestForCombinationWithSpecialAndSinglePricing()
        {
            var checkout = new Checkout(_pricingRules);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A"); // Special pricing for 3 A's
            Assert.Equal(130, checkout.GetTotalPrice());

            checkout.Scan("B");
            Assert.Equal(160, checkout.GetTotalPrice()); // Add 1 B

            checkout.Scan("C");
            Assert.Equal(180, checkout.GetTotalPrice()); // Add 1 C

            checkout.Scan("D");
            checkout.Scan("B"); // Special pricing for 2 B's
            Assert.Equal(205, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestForBulkItemsWithSpecialPricing()
        {
            var checkout = new Checkout(_pricingRules);

            // Testing "F" with special pricing
            for (int i = 0; i < 10; i++)
            {
                checkout.Scan("F");
            }
            Assert.Equal(200, checkout.GetTotalPrice()); 

            // Testing "K" with special pricing
            for (int i = 0; i < 15; i++)
            {
                checkout.Scan("K");
            }
            Assert.Equal(280, checkout.GetTotalPrice()); 
        }

        [Fact]
        public void TestForLargeCombination()
        {
    
            var checkout = new Checkout(_pricingRules);

            // Scan multiple items
            var items = new[] { "A", "B", "E", "C", "D", "E", "A", "A", "B", "E", "E", "E", "E",  "F", "F", "F", "F", "F" };
            foreach (var item in items)
            {
                checkout.Scan(item);
            }

            Assert.Equal(570, checkout.GetTotalPrice());
        }

    }
}

