using MyToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Commands
{
    internal class DeleteCommand : ICommand
    {

        private readonly IToDoList _toDoList;

        public DeleteCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            var goals = _toDoList.Goals();

            if (goals.Count == 0)
            {
                Console.WriteLine("Goals list is empty, add new goal");
                return;
            }

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i} - {goals[i]}");
            }

            do 
            {
                var idText = Console.ReadLine();

                if (int.TryParse(idText, out var id) && id >= 0 && id < goals.Count)
                {
                    _toDoList.Delete(id);
                }

            } while (true);
        }
    }
}
