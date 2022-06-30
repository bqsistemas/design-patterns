using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandManager : ICommandManager
    {
        private Stack<ICommand> commands = new Stack<ICommand>();
        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                commands.Push(command);
                command.Execute();
            }
        }
        public void Undo()
        {
            while(commands.Count > 0)
            {
                var command = commands.Pop();
                command.Undo();
            }
        }
    }
}
