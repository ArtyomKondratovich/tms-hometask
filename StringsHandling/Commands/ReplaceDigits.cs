using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal class ReplaceDigits : ResultBase
    {
        private readonly StringAnalyzer _analyzer;

        public ReplaceDigits(StringAnalyzer analyzer, IOutputProvider outputProvider) : base(outputProvider)
        {
            _analyzer = analyzer;
        }

        public override string Description => "Replace digits";

        public override string GetResult()
        {
            return _analyzer.ReplaceDigits();
        }
    }
}
