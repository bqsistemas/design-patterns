using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class AddToCartCommand : ICommand
    {
        // insert dependencies for example repository interfaces
        // private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly Item _item;
        // And create constructor for example
         
        public AddToCartCommand(/*IShoppingCartRepository shoppingCartRepository*/ Item item)
        {
            _item = item;
        }
        

        public bool CanExecute()
        {
            if (_item == null) return false;

            return true; // replace with condition of success
        }

        public void Execute()
        {
            if (_item == null) return;

            // invoke actions
            // 1° invoke repository to decrease stock by item
            // example: itemRepository.DecreaseStockBy(_item)
            // 2° invoke repository to add item to shoppingCart
            // 3° invoke send notification
        }

        public void Undo()
        {
            if (_item == null) return;
            // invoke actions
            // 1° invoke repository to increase stock by item
            // example: itemRepository.IncreaseStockBy(_item)
            // 2° invoke repository to remove item to shoppingCart
            // 3° invoke send notification
        }
    }
}
