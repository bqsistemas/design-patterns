using Business.Enums;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IShoppingCartService
    {
        void AddToCart(Item item);
        void ChangeQuantity(Item item, ChangeQuantityType changeQuantityType);
    }
}
