using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domains
{
    internal interface IOutputProvider
    {
        void Write(string content, string fileName);
    }
}
