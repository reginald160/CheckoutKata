using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interface
{
    public interface ICheckout
    {
        Dictionary<string, int> GetAllScannedItems();
        decimal GetTotalPrice();
        void Scan(string item);
    }
}
