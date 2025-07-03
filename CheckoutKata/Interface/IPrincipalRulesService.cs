using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interface
{
    public interface IPrincipalRulesService
    {
        Dictionary<string, PricingRule> GetPricingRules();
    }
}
