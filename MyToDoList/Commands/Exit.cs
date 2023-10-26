using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Commands
{
    internal class Exit : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
