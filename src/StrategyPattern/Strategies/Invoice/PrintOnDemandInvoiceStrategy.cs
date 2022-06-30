using Newtonsoft.Json;
using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(OrderReceived order)
        {
            var content = JsonConvert.SerializeObject(order);
            // send other API
        }
    }
}
