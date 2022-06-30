using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Comparer
{
    public class OrderOriginCountryComparerStrategy : IComparer<Order>
    {
        public int Compare(Order? x, Order? y)
        {
            var xOrigin = x.ShippingDetails.OriginCountry.ToLowerInvariant();
            var yOrigin = y.ShippingDetails.OriginCountry.ToLowerInvariant();
            if (xOrigin == yOrigin)
                return 0;
            else return 1;
        }
    }
}
