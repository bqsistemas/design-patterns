﻿using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Shipping
{
    public class DHLShippingStrategy : IShippingStrategy
    {
        public void Ship(OrderReceived order)
        {
            using (var client = new HttpClient())
            {
                // TODO: Implement DHL Shipping Integration
                // send to API DHL
            }
        }
    }
}
