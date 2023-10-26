using MyToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Commands
{
    internal class SaveCommand : ICommand
    {
        private readonly DataHandler _handler;
        private readonly IToDoList _toDoList;

        public SaveCommand(DataHandler handler, IToDoList toDoList)
        {
            _handler = handler;
            _toDoList = toDoList;
        }

        public void Execute()
        {
            _handler.Write(_toDoList.Goals(), _toDoList.Completed());
        }
    }
}
