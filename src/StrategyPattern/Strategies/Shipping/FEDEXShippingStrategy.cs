using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Shipping
{
    public class FEDEXShippingStrategy : IShippingStrategy
    {
        public void Ship(OrderReceived order)
        {
            using (var client = new HttpClient())
            {
                // TODO: Implement FEDEX Shipping Integration
                // send to API FEDEX
            }
        }
    }
}
