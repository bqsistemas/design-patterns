using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        public void Ship(OrderReceived order);
    }
}
