using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class ReversePolishNotation
    {
        private List<double> _values { get; set; }

        private List<char> _operations { get; set; }

        public ReversePolishNotation()
        {
            _values = new List<double>();
            _operations = new List<char>();
        }

        public double Calculate(string line)
        {
            _values.Clear();
            _operations.Clear();

            var answer = 0d;
            //TODO: algorithm convert inputExpression -> reversePolishNotation and calculate

            return answer;
        }
    }
}
