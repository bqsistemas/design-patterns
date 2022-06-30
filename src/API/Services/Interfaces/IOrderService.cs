using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IOrderService
    {
        decimal RegisterOrder(Order order);
        List<Order> OrderList(List<Order> list);
    }
}
