﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class PricingRule : Product
    {
        public int? SpecialQuantity { get; set; }
        public int? SpecialPrice { get; set; }
    }
}
