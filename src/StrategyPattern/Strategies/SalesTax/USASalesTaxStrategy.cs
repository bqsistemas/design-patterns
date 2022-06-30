using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.SalesTax
{
    public class USASalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationState.ToLowerInvariant();
            switch (destination)
            {
                case "la": return order.TotalPrice * 0.095m;
                case "ny": return order.TotalPrice * 0.004m;
                case "nyc": return order.TotalPrice * 0.045m;
                default: return 0m;
            }
        }
    }
}
