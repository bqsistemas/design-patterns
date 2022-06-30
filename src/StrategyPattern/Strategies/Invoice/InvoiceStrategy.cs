using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies.Invoice
{
    public abstract class InvoiceStrategy : IInvoiceStrategy
    {
        public abstract void Generate(OrderReceived order);
        public string GenerateTextInvoice(OrderReceived order)
        {
            var invoice = $"INVOICE DATE: {DateTimeOffset.Now}{Environment.NewLine}";
            invoice += $"ID|NAME|PRICE|QUANTITY{Environment.NewLine}";

            foreach (var item in order.Order.LineItems)
            {
                invoice += $"{item.Name}|{item.Price}{Environment.NewLine}";
            }
            invoice += Environment.NewLine + Environment.NewLine;

            var tax = order.GetTax();
            var total = order.Order.TotalPrice + tax;

            invoice += $"TAX TOTAL: {tax}{Environment.NewLine}";
            invoice += $"TOTAL: {total}{Environment.NewLine}";

            return invoice;
        }
    }
}
