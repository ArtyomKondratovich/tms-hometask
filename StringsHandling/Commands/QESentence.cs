using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.Commands
{
    internal class QESentence : ResultBase
    {
        private readonly StringAnalyzer _analyzer;

        public QESentence(StringAnalyzer analyzer, IOutputProvider outputProvider) : base(outputProvider)
        {
            _analyzer = analyzer;
        }

        public override string Description => "Display question and exclamation sentences";

        public override string GetResult()
        {
            var questionSentences = _analyzer.SentencesCertainType(SentenceType.mQuestion);
            var exclamationSentences = _analyzer.SentencesCertainType(SentenceType.mExclamatory);

            var result = new StringBuilder();

            foreach (var question in questionSentences)
            {
                result.Append(question);
                result.Append('\n');
            }

            result.Append('\n');

            foreach (var exclamation in exclamationSentences)
            {
                result.Append(exclamation);
                result.Append('\n');
            }

            return result.ToString();
        }
    }
}
