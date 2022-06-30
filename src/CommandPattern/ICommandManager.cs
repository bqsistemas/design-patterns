using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public interface ICommandManager
    {
        void Invoke(ICommand command);
        void Undo();
    }
}
