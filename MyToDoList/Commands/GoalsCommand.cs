using MyToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Commands
{
    internal class GoalsCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public GoalsCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            var goals = _toDoList.Goals();

            Console.WriteLine("Goals:");

            foreach (var goal in goals) 
            {
                Console.WriteLine(goal);
            }
        }
    }
}
