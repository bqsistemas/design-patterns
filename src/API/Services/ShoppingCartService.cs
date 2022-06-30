using API.Services.Interfaces;
using Business.Enums;
using Business.Models;
using CommandPattern;
using CommandPattern.Commands;
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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ICommandManager _commandManager;

        public ShoppingCartService(ICommandManager commandManager)
        {
            _commandManager = commandManager;
        }

        public void AddToCart(Item item)
        {
            try
            {
                var addToCartCommand = new AddToCartCommand(item);
                _commandManager.Invoke(addToCartCommand);
                // if necesary you can do add more commands to manager
            }
            catch
            {
                _commandManager.Undo();
            }
        }

        public void ChangeQuantity(Item item, ChangeQuantityType changeQuantityType)
        {
            try
            {
                var changeQuantityCommand = new ChangeQuantityCommand(item, changeQuantityType);
                _commandManager.Invoke(changeQuantityCommand);
                // if necesary you can do add more commands to manager
            }
            catch
            {
                _commandManager.Undo();
            }
        }
    }
}
