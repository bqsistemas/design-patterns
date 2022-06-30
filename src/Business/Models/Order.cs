using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Order
    {
        public decimal TotalPrice { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
        public List<Item> LineItems { get; set; } = new List<Item>();
        public ShipProvider ShipProvider { get; set; } = ShipProvider.SERPOST;
    }
}
