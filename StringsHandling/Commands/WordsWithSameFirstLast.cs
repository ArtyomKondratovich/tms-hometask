using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal class WordsWithSameFirstLast : ResultBase
    {
        private readonly StringAnalyzer _analizer;

        public WordsWithSameFirstLast(StringAnalyzer analizer, IOutputProvider outputProvider) : base(outputProvider)
        {
            _analizer = analizer;
        }

        public override string Description => "Words with same first last";

        public override string GetResult()
        {
            var result = new StringBuilder();

            var words = _analizer.WordsWithSameFirstLast();

            foreach ( var word in words ) 
            {
                result.Append(word);
                result.Append('\n');
            }

            return result.ToString();
        }
    }
}
