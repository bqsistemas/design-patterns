using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(OrderReceived order);
    }
}
