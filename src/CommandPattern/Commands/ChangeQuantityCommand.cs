using Business.Enums;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class ChangeQuantityCommand : ICommand
    {
        // insert dependencies for example repository interfaces
        private readonly Item _item;
        private readonly ChangeQuantityType _changeQuantityType;
        // And create constructor for example
        public ChangeQuantityCommand(Item item, ChangeQuantityType changeQuantityType)
        {
            _item = item;
            _changeQuantityType = changeQuantityType;
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
            // 1° invoke repository to according ChangeQuantityType quantity by item
            // switch (_changeQuantityType)
        }

        public void Undo()
        {
            if (_item == null) return;
            // invoke actions
            // 1° invoke repository to according ChangeQuantityType quantity by item
            // switch (_changeQuantityType)
        }
    }
}
