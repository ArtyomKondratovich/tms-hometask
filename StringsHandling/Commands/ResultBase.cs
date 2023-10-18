using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal abstract class ResultBase : ICommand
    {

        private readonly IOutputProvider OutputProvider;

        protected ResultBase(IOutputProvider outputProvider)
        {
            OutputProvider = outputProvider;
        }

        public abstract string Description { get; }

        public abstract string GetResult();

        public void Execute()
        {
            OutputProvider.Write(GetResult());
        }
    }
}
