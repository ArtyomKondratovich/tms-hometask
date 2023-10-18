using StringsHandling.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling
{
    internal class FormedTask
    {
        private readonly IInputProvider _inputProvider;
        private readonly IOutputProvider _outputProvider;
        private readonly string _command;
       
        public FormedTask(IInputProvider inputProvider, string command, IOutputProvider outputProvider) 
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _command = command;
        }

        public void SolveTask()
        {
            var analyzer = new StringAnalyzer(_inputProvider.Read());

            var resultCommand = GetResultCommand(_command, analyzer);

            resultCommand.Execute();
        }

        public override string ToString()
        {
            return @$"A task has been formed:
* inputProvider = { _inputProvider },
* command = { _command },
* outputProvider = { _outputProvider }";
        }

        private ResultBase GetResultCommand(string command, StringAnalyzer analyzer) => command switch
        {
            "Longest word" => new LongestWord(analyzer, _outputProvider),
            "Display question and exclamation sentences" => new QESentence(analyzer, _outputProvider),
            "Replace digits" => new ReplaceDigits(analyzer, _outputProvider),
            "Sentences without comma" => new SentencesWithouComma(analyzer, _outputProvider),
            "Words with numbers" => new WordsWithNumbers(analyzer, _outputProvider),
            "Words with same first last" => new WordsWithSameFirstLast(analyzer, _outputProvider),
            _ => throw new InvalidOperationException()
        };
    }
}
