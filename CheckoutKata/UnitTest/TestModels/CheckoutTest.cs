using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.UnitTest.Models
{
    public class CheckoutTest
    {
        [Fact]
        public void TestTotals()
        {

            var checkout = new Checkout();

            Assert.Equal(0, checkout.GetTotalPrice());

            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());

            checkout.Scan("B");
            Assert.Equal(80, checkout.GetTotalPrice());

            checkout.Scan("A");
            Assert.Equal(130, checkout.GetTotalPrice());

            checkout.Scan("A");
            Assert.Equal(160, checkout.GetTotalPrice());

            checkout.Scan("B");
            Assert.Equal(175, checkout.GetTotalPrice());
        }


        [Fact]
        public void TestNoPricingRules()
        {

            var checkout = new Checkout();

            Assert.Throws<ArgumentException>(() => checkout.Scan("A"));
        }

        [Fact]
        public void TestInvalidItem()
        {

            var checkout = new Checkout();

            Assert.Throws<ArgumentException>(() => checkout.Scan("X"));
        }
    }
}

