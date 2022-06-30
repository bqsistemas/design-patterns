using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Item
    {
        public Item(string name, decimal price, ItemType type)
        {
            Name = name;
            Price = price;  
            Type = type;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ItemType Type { get; set; }
    }
}
