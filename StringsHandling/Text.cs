using System.Text;
using System.Text.RegularExpressions;


namespace StringsHandling
{

    internal class Text
    {
        public StringBuilder _text { get; set; }

        public Text(string text) 
        {
            _text = new StringBuilder(text);
        }

        public Text()
        {
            _text = new StringBuilder();
        }

        public string[] FindWords(string option)
        {
            var separators = new string[]{ " ",".", ",", "!", "?", ";", ":", "-", "'", "\"", "(", ")", "[", "]", "{", "}" };
            var words = _text.ToString().Replace(Environment.NewLine, "").Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return option switch
            { 
                "-d" => WithLargestAmountOfDigits(words),
                "-s" => WithSameStartEnd(words),
                "-l" => Longest(words),
                _ => Array.Empty<string>()
            };
        }

        public string[] FindSentences(string command)
        {
            var sentences = Regex.Split(_text.ToString(), @"(?<=[.!?])\s+(?=[A-Z,А-Я])");

            return command switch
            {
                "-w" => FindSentencesWithoutComma(sentences),
                "-t" => FindSentencesTypes(sentences),
                _ => Array.Empty<string>()
            };
        }

        public void ReplaceNumbersWithText()
        {
            for (int i = 0; i < _text.Length; i++)
            {
                if (char.IsDigit(_text[i]))
                {
                    _text.Replace(_text[i].ToString(), NumberToString(_text[i]), i, 1);
                }
            }
        }

        public void PrintText()
        {
            Console.WriteLine(_text.ToString());
        }

        private string[] Longest(string[] words)
        {
            var length = words.Max(x => x.Length);

            var longest = words.Where(x => x.Length == length).ToArray();

            for (var i = 0; i < longest.Length; i++)
            {
                longest[i] += $" {words.Count(x => x == longest[i])}";
            }

            return longest;
        }

        private string[] WithSameStartEnd(string[] words)
        {
            return words.Where(x => x.First() == x.Last()).ToArray();
        }

        private string[] WithLargestAmountOfDigits(string[] words)
        {
            var max = 0;

            for (int i = 0; i < words.Length; i++)
            {
                max = Math.Max(max, NumbersInWord(words[i]));
            }

            if (max == 0)
            {
                return Array.Empty<string>();
            }

            var largest = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (NumbersInWord(words[i]) == max)
                {
                    largest.Add(words[i]);
                }
            }

            return largest.ToArray();
        }

        private string[] FindSentencesWithoutComma(string[] sentences)
        {
            
            var sentencesWithoutComma = new List<string>();

            foreach (var sentence in sentences) 
            {
                if (!sentence.Contains(','))
                {
                    sentencesWithoutComma.Add(sentence);
                }
            }

            return sentencesWithoutComma.ToArray();
        }

        private string[] FindSentencesTypes(string[] sentences)
        {
            var typeSentences = new List<string>();

            typeSentences.Add("");

            var delimiter = 0;

            foreach (var sentence in sentences)
            {
                if (sentence.Last() == '?')
                {
                    typeSentences.Insert(delimiter, sentence);
                    delimiter++;
                }
                else if (sentence.Last() == '!')
                {
                    typeSentences.Add(sentence);
                }
            }

            return typeSentences.ToArray(); 
        }

        private string NumberToString(char number) =>
            number switch
            {
                '0' => "ноль",
                '1' => "один",
                '2' => "два",
                '3' => "три",
                '4' => "четыре",
                '5' => "пять",
                '6' => "шесть",
                '7' => "семь",
                '8' => "восемь",
                '9' => "девять",
                _ => ""
            };

        private int NumbersInWord(string word)
        {
            var count = 0;

            for (var i = 0; i < word.Length; i++)
            {
                count += char.IsDigit(word[i]) ? 1 : 0;
            }

            return count;
        }  
    }
}
