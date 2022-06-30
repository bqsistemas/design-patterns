using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Invoice
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(OrderReceived order)
        {
            var bodyFile = GenerateTextInvoice(order);
            // create file and send
        }
    }
}
