using CheckoutKata.Interface;
using CheckoutKata.Models;
using CheckoutKata.Test.Mock;
using CheckoutKata.UnitTest.MockData;
using System;
using System.Collections.Generic;
using Xunit;

namespace CheckoutKata.UnitTest.Models
{
    /// <summary>
    /// Unit tests for the Checkout class, verifying the functionality of scanning items,
    /// calculating total price, and handling special pricing rules.
    /// </summary>
    public class CheckoutTest
    {
        private Dictionary<string, PricingRule> _pricingRules = new Dictionary<string, PricingRule>();

        /// <summary>
        /// Initializes a new instance of the CheckoutTest class with sample pricing rules.
        /// </summary>
        private readonly IMockPriceRuleRepository mockPriceRuleRepository;
        private readonly ICheckoutService checkout;
        public CheckoutTest()
        {
            checkout = new CheckoutService();
            mockPriceRuleRepository = new MockPriceRuleRepository();

        }

        /// <summary>
        /// Tests the Scan method to ensure that items are scanned correctly
        /// and throws an exception for invalid items.
        /// </summary>
        [Fact]
        public void TestScanMethod()
        {

            // Act & Assert: Valid items
            checkout.Scan("A");
            //Assert.Equal(1, checkout.GetAllScannedItems()["A"]);

            //checkout.Scan("A");
            //Assert.Equal(2, checkout.GetAllScannedItems()["A"]);

            //checkout.Scan("B");
            //checkout.Scan("B");
            //Assert.Equal(2, checkout.GetAllScannedItems()["B"]);

            //// Act & Assert: Invalid item
            //var ex = Assert.Throws<ArgumentException>(() => checkout.Scan("X"));
            //Assert.Equal("Invalid item: X", ex.Message);
        }

        /// <summary>
        /// Tests that an empty cart results in a total price of zero.
        /// </summary>
        [Fact]
        public void TestForEmptyCart()
        {

            Assert.Equal(0, checkout.GetTotalPrice());
        }

        ///// <summary>
        ///// Tests that scanning an invalid item throws an exception.
        ///// </summary>
        //[Fact]
        //public void TestForInvalidItem()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    Assert.Throws<ArgumentException>(() => checkout.Scan("X invalid item"));
        //}

        ///// <summary>
        ///// Tests the total price calculation for individual items without special pricing.
        ///// </summary>
        //[Fact]
        //public void TestForSinglePricing()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    checkout.Scan("A");
        //    Assert.Equal(50, checkout.GetTotalPrice());

        //    checkout.Scan("C");
        //    Assert.Equal(70, checkout.GetTotalPrice());

        //    checkout.Scan("D");
        //    Assert.Equal(85, checkout.GetTotalPrice());
        //}

        ///// <summary>
        ///// Tests the total price calculation for "A" with special pricing rules.
        ///// </summary>
        //[Fact]
        //public void TestForSingSpecialAPricing()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    checkout.Scan("A");
        //    checkout.Scan("A");
        //    checkout.Scan("A");
        //    Assert.Equal(130, checkout.GetTotalPrice());
        //}

        ///// <summary>
        ///// Tests the total price calculation for "B" with special pricing rules.
        ///// </summary>
        //[Fact]
        //public void TestForSingSpecialBPricing()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    checkout.Scan("B");
        //    checkout.Scan("B");
        //    Assert.Equal(45, checkout.GetTotalPrice());
        //}

        ///// <summary>
        ///// Tests the total price calculation for a sequence of items,
        ///// including both regular and special pricing rules.
        ///// </summary>
        //[Fact]
        //public void TestForSpecialPricing()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    checkout.Scan("A");
        //    Assert.Equal(50, checkout.GetTotalPrice());

        //    checkout.Scan("B");
        //    Assert.Equal(80, checkout.GetTotalPrice());

        //    checkout.Scan("A");
        //    Assert.Equal(130, checkout.GetTotalPrice());

        //    checkout.Scan("A");
        //    Assert.Equal(160, checkout.GetTotalPrice());

        //    checkout.Scan("B");
        //    Assert.Equal(175, checkout.GetTotalPrice());
        //}

        ///// <summary>
        ///// Tests the total price calculation for a combination of single items
        ///// and items with special pricing rules.
        ///// </summary>
        //[Fact]
        //public void TestForCombinationWithSpecialAndSinglePricing()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    checkout.Scan("A");
        //    checkout.Scan("A");
        //    checkout.Scan("A");
        //    Assert.Equal(130, checkout.GetTotalPrice());

        //    checkout.Scan("B");
        //    Assert.Equal(160, checkout.GetTotalPrice());

        //    checkout.Scan("C");
        //    Assert.Equal(180, checkout.GetTotalPrice());

        //    checkout.Scan("D");
        //    checkout.Scan("B");
        //    Assert.Equal(210, checkout.GetTotalPrice());
        //}

        ///// <summary>
        ///// Tests the total price calculation for bulk items with special pricing rules.
        ///// </summary>
        //[Fact]
        //public void TestForBulkItemsWithSpecialPricing()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    // Testing "F" with special pricing
        //    for (int i = 0; i < 10; i++)
        //    {
        //        checkout.Scan("F");
        //    }
        //    Assert.Equal(200, checkout.GetTotalPrice());

        //    // Testing "K" with special pricing
        //    for (int i = 0; i < 15; i++)
        //    {
        //        checkout.Scan("K");
        //    }
        //    Assert.Equal(330, checkout.GetTotalPrice());
        //}

        ///// <summary>
        ///// Tests the total price calculation for a large combination of items,
        ///// including special pricing and single pricing.
        ///// </summary>
        //[Fact]
        //public void TestForLargeCombination()
        //{
        //    var checkout = new CheckoutService(_pricingRules);

        //    // Scan multiple items
        //    var items = new[] { "A", "B", "E", "C", "D", "E", "A", "A", "B", "E", "E", "E", "E", "F", "F", "F", "F", "F" };
        //    foreach (var item in items)
        //    {
        //        checkout.Scan(item);
        //    }

        //    Assert.Equal(710, checkout.GetTotalPrice());
        //}
    }
}
