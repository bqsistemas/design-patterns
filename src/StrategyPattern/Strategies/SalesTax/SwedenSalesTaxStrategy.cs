using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.SalesTax
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            if (destination == origin)
            {
                return order.TotalPrice * 0.25m;
            }
            return 0;
        }
    }
}
