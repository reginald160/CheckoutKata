using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Test.Mock
{
    public interface IMockPriceRuleRepository
    {
        Dictionary<string, PricingRule> GetSamplePricingRules();
    }
}
