using MyToDoList.Commands;
using MyToDoList.Data;
using System;
namespace MyToDoList
{
    internal class Menu
    {
        private readonly List<ICommand> _commands;

        public Menu(DataHandler _handler)
        {
            var toDoList = _handler.Read();

            _commands = new List<ICommand> { 
                new AddCommand(toDoList),
                new DeleteCommand(toDoList),
                new CompletedCommand(toDoList),
                new GoalsCommand(toDoList),
                new SaveCommand(_handler, toDoList),
                new MarkAsCompleteCommand(toDoList),
                new Exit()};
        }

        public void Start()
        {
            do
            {
                try
                {
                    Console.Write("Enter command: ");
                    var command = Console.ReadLine();
                    SetCommand(command).Execute();
                }
                catch 
                {
                    return;
                }

            } while (true);
        }

        private ICommand SetCommand(string? command) => command switch
        {
            "add" => _commands[0],
            "delete" => _commands[1],
            "completed" => _commands[2],
            "goals" => _commands[3],
            "save" => _commands[4],
            "mark" => _commands[5],
            "exit" => _commands[6],
            _ => throw new ArgumentException("Unknown command", nameof(command))
        };
    }
}
