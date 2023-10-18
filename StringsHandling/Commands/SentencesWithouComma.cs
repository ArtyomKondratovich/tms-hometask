using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal class SentencesWithouComma : ResultBase
    {
        private readonly StringAnalyzer _analyzer;

        public SentencesWithouComma(StringAnalyzer analyzer, IOutputProvider outputProvider) : base(outputProvider)
        {
            _analyzer = analyzer;
        }

        public override string Description => "Sentences without comma";

        public override string GetResult()
        {
            var result = new StringBuilder();

            var sentences = _analyzer.SentencesWithoutComma();

            foreach (var sentence in sentences)
            {
                result.Append(sentence);
                result.Append('\n');
            }

            return result.ToString();
        }
    }
}
