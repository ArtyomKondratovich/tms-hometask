using MyToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Commands
{
    internal class CompletedCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public CompletedCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            var completed = _toDoList.Completed();

            Console.WriteLine("Completed tasks:");

            foreach (var item in completed) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
