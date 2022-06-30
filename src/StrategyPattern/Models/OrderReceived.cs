using Business.Models;
using StrategyPattern.Strategies.Invoice;
using StrategyPattern.Strategies.SalesTax;
using StrategyPattern.Strategies.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    public class OrderReceived
    {
        public OrderReceived(Order order)
        {
            this.Order = order;
        }
        public Order Order { get; set; }
        public ISalesTaxStrategy SalesTaxStrategy { get; private set; }
        public IInvoiceStrategy InvoiceStrategy { get; private set; }
        public IShippingStrategy ShippingStrategy { get; private set; }

        public void SetSalesTaxStrategy(ISalesTaxStrategy strategy)
        {
            this.SalesTaxStrategy = strategy;
        }
        public void SetInvoiceStrategy(IInvoiceStrategy invoiceStrategy)
        {
            this.InvoiceStrategy = invoiceStrategy;
        }
        public decimal GetTax(ISalesTaxStrategy salesTaxStrategy = default)
        {
            var strategy = salesTaxStrategy ?? SalesTaxStrategy;
            if (strategy == null)
                return 0m;
            return strategy.GetTaxFor(Order);
        }
        public void FinalizeOrder()
        {
            var tax = GetTax();
            if (tax == 0)
                throw new Exception("Unable to finalize order");
            else
                InvoiceStrategy.Generate(this);

            ShipOrder();
        }
        public void ShipOrder()
        {
            switch (Order.ShipProvider)
            {
                case Business.Enums.ShipProvider.SERPOST:
                    ShippingStrategy = new SERPOSTShippingStrategy();
                    break;
                case Business.Enums.ShipProvider.UPS:
                    ShippingStrategy = new UPSShippingStrategy();
                    break;
                case Business.Enums.ShipProvider.DHL:
                    ShippingStrategy = new DHLShippingStrategy();
                    break;
                case Business.Enums.ShipProvider.FEDEX:
                    ShippingStrategy = new FEDEXShippingStrategy();
                    break;
                default : throw new Exception("Ship provider not found");
            }
            ShippingStrategy.Ship(this);
        }
    }
}
