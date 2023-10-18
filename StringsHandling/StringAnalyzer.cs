using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;


namespace StringsHandling
{
    enum SentenceType
    {
        mQuestion,
        mExclamatory,
        mDeclarative
    }

    internal class StringAnalyzer
    {
        public string Text { get; set; }

        private readonly string[] _separators = { " ", ".", "?", "!", "," }; 

        public StringAnalyzer(string text) 
        {
            text = text.Replace("\n", " ").Replace("\r", " ");
            Text = text;
        }

        public StringAnalyzer()
        {
            Text = string.Empty;
        }

        public List<(string, int)> WordsWithNumbers()
        {
            var result = new List<(string, int)> ();

            var words = Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            var maxAmount = 0;

            foreach ( var word in words ) 
            {
                if (maxAmount < CountDigitsInWord(word))
                {
                    maxAmount = CountDigitsInWord(word);
                }
            }

            foreach (var word in words)
            {
                if (CountDigitsInWord(word) == maxAmount)
                {
                    result.Add((word, maxAmount));
                }
            }

            return result;
        }

        public (string, int) LongestWord()
        {
            var words = Text.Split(_separators , StringSplitOptions.RemoveEmptyEntries);

            var longestWord = "";

            foreach (var word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            return (longestWord, CountTheNumberOfOccurrences(words, longestWord));
        }

        public string ReplaceDigits()
        {
            var text = new StringBuilder(Text);

            for (var i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    text.Remove(i, 1);
                    text.Insert(i, TextualInterpretationOfDigit(text[i]));
                }
            }

            return text.ToString();
        }

        public List<string> SentencesWithoutComma()
        {
            var withoutComma = new List<string>();

            var sentences = Sentences();

            foreach (var sentence in sentences)
            {
                if (!sentence.Contains(','))
                {
                    withoutComma.Add(sentence);
                }
            }

            return withoutComma;
        }

        public List<string> SentencesCertainType(SentenceType type)
        {
            var typeMark = type switch
            {
                SentenceType.mQuestion => '?',
                SentenceType.mExclamatory => '!',
                SentenceType.mDeclarative => '.',
                _ => '\n'
            };

            if (typeMark.Equals('\n'))
            {
                return Array.Empty<string>().ToList();
            }

            var typeSentences = new List<string>();

            var sentences = Sentences();

            foreach (var sentence in sentences)
            {
                if (sentence.Last().Equals(typeMark))
                {
                    typeSentences.Add(sentence);
                }
            }

            return typeSentences;
        }

        public List<string> WordsWithSameFirstLast()
        {
            var result = new List<string>();

            var words = Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (word.First() == word.Last())
                {
                    result.Add(word);
                }
            }

            return result;
        }

        private List<string> Sentences()
        {
            var sentences = new List<string>();

            var start = 0;

            for (var i = 0; i < Text.Length; i++)
            {
                if (IsSentenceSeparator(Text[i]))
                {
                    var sentence = Text.Substring(start, i - start + 1);
                    start = i + 1;
                    sentences.Add(sentence);
                }
            }

            return sentences;
        }

        private static int CountDigitsInWord(string word)
        {
            var count = 0;

            foreach (var item in word)
            {
                count += char.IsDigit(item) ? 1 : 0;
            }

            return count;
        }

        private static int CountTheNumberOfOccurrences(string[] words, string word)
        {
            var count = 0;

            foreach (var item in words)
            {
                count += word.Equals(item) ? 1 : 0;
            }

            return count;
        }

        private static string TextualInterpretationOfDigit(char digit) => digit switch
        {
            '0' => "НОЛЬ",
            '1' => "ОДИН",
            '2' => "ДВА",
            '3' => "ТРИ",
            '4' => "ЧЕТЫРЕ",
            '5' => "ПЯТЬ",
            '6' => "ШЕСТЬ",
            '7' => "СЕМЬ",
            '8' => "ВОСЕМЬ",
            '9' => "ДЕВЯТЬ",
            _ => string.Empty
        };

        private static bool IsSentenceSeparator(char separator) => separator switch
        {
            '!' => true,
            '.' => true,
            '?' => true,
            _ => false
        };

     }
}
