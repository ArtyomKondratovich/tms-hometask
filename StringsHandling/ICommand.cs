using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling
{
    internal interface ICommand
    {
        string Description { get; }

        void Execute();
    }
}
