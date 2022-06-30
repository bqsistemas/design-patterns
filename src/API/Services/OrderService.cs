using API.Services.Interfaces;
using Business.Models;
using StrategyPattern.Models;
using StrategyPattern.Strategies.Comparer;
using StrategyPattern.Strategies.Invoice;
using StrategyPattern.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        public decimal RegisterOrder(Order order)
        {
            var orderReceived = new OrderReceived(order);
            string destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            if (destination == "sweden")
                orderReceived.SetSalesTaxStrategy(new SwedenSalesTaxStrategy());
            else if (destination == "us")
                orderReceived.SetSalesTaxStrategy(new USASalesTaxStrategy());


            orderReceived.SetInvoiceStrategy(new FileInvoiceStrategy());
            orderReceived.FinalizeOrder();

            return orderReceived.GetTax();
        }
        public List<Order> OrderList(List<Order> list)
        {
            var array = list.ToArray();
            Array.Sort(array, new OrderOriginCountryComparerStrategy());
            return array.ToList();
        }
    }
}
