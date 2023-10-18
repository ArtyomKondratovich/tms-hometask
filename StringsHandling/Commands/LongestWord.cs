using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal class LongestWord : ResultBase
    {
        private readonly StringAnalyzer _analyzer;

        public LongestWord(StringAnalyzer stringAnalyzer, IOutputProvider outputProvider) : base(outputProvider) 
        {
            _analyzer = stringAnalyzer;
        }

        public override string Description => "Longest word";

        public override string GetResult()
        {
            var (word, entries) = _analyzer.LongestWord();

            return word + " " + entries;
        }
    }
}
