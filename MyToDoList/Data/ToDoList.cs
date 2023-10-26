using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Data
{
    internal class ToDoList : IToDoList
    {
        private readonly List<MyTask> _goals;
        private readonly List<MyTask> _completed;

        public ToDoList(List<MyTask> goals, List<MyTask> completed) 
        {
            _goals = goals;
            _completed = completed;
        }

        public ToDoList() 
        {
            _goals = new List<MyTask>();
            _completed = new List<MyTask>();
        }

        public void Add(MyTask task)
        {
            _goals.Add(task);
        }

        public List<MyTask> Completed()
        {
            return _completed.ToList();
        }

        public void Delete(int id)
        {
            _goals.RemoveAt(id);
        }

        public List<MyTask> Goals()
        {
            return _goals.ToList();
        }

        public void MarkAsCompleted(int id)
        {
            var task = _goals[id];
            _goals.RemoveAt(id);
            _completed.Add(task);
        }
    }
}
