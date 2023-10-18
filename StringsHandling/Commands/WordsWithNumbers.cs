using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal class WordsWithNumbers : ResultBase
    {
        private readonly StringAnalyzer _analyzer;

        public override string Description => "Words with numbers";

        public WordsWithNumbers(StringAnalyzer stringAnalyzer, IOutputProvider outputProvider) : base(outputProvider)
        {
            _analyzer = stringAnalyzer;
        }

        public override string GetResult()
        {
            var result = new StringBuilder();

            var words = _analyzer.WordsWithNumbers();

            foreach (var (word, numbers) in words)
            {
                result.Append($"{word} - {numbers}\n");
            }

            return result.ToString();
        }
    }
}
