using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Data
{
    internal interface IToDoList
    {
        void Add(MyTask task);
        
        void Delete(int id);
        
        void MarkAsCompleted(int id);
        
        List<MyTask> Goals();

        List<MyTask> Completed();
    }
}
