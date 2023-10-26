using MyToDoList.Commands;
using MyToDoList.Data;

namespace MyToDoList.Commands
{
    internal class MarkAsCompleteCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public MarkAsCompleteCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            var goals = _toDoList.Goals();

            if (goals.Count == 0)
            {
                return;
            }

            for (var i = 0; i < goals.Count; i++) 
            {
                Console.WriteLine($"{i} {goals[i]}");
            }

            do
            {
                var text = Console.ReadLine();

                if (int.TryParse(text, out var id) && id >= 0 && id < goals.Count)
                {
                    _toDoList.MarkAsCompleted(id);
                    return;
                }
            } while (true);
        }
    }
}
