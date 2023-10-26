using MyToDoList.Data;


namespace MyToDoList.Commands
{
    internal class AddCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public AddCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            do
            {
                Console.Write("Enter your new goal description: ");
                var goalText = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(goalText))
                {
                    _toDoList.Add(new MyTask(goalText));
                    return;
                }

            } while (true);
        }
    }
}
