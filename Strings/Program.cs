namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SeperateString("ABCD", "-"));

            Console.WriteLine(palidrome("eye"));

            Console.WriteLine(StringLength("hello"));

            Console.WriteLine(ReverseString("hello"));

            Console.WriteLine(NumberOfWords("Hello World! This is a test."));

            Console.WriteLine(ReverseWordsOrder("Hello World! This is a test."));

            Console.WriteLine(HowManyOccurrences("Hello World! Hello Universe!", "Hello"));

            Console.WriteLine(SortCharactersDescending("hello"));

            Console.WriteLine(CompressString("aaabbbcccddeee"));
        }

        static string SeperateString(string word, string seperator)
        {
            string result = string.Empty;
            foreach (char c in word)
            {
                result += c + seperator;
            }
            return result;
        }

        static string palidrome(string word)
        {
            string reversed = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversed += word[i];
            }
            return reversed == word ? "Palindrome" : "Not a palindrome";
        }

        static string StringLength(string word)
        {
            word = word.Trim();
            int length = 0;
            foreach (char c in word)
            {
                length++;
            }
            return length.ToString();
        }

        static string ReverseString(string word)
        {
            string reversed = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversed += word[i];
            }
            return reversed;
        }

        static String NumberOfWords(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                return "0";
            }

            var words = a.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length.ToString();
        }

        static String ReverseWordsOrder(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                return string.Empty;
            }
            var words = a.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        static String HowManyOccurrences(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
            {
                return "0";
            }

            int count = 0;
            int index = 0;
            while ((index = a.IndexOf(b, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += b.Length;
            }
            return count.ToString();
        }

        static String SortCharactersDescending(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                return string.Empty;
            }
            var chars = a.ToCharArray();
            Array.Sort(chars);
            Array.Reverse(chars);
            return new string(chars);
        }

        static String CompressString(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                return string.Empty;
            }
            var compressed = new List<char>();
            char currentChar = a[0];
            int count = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    compressed.Add(currentChar);
                    compressed.Add((char)('0' + count));
                    currentChar = a[i];
                    count = 1;
                }
            }

            compressed.Add(currentChar);
            compressed.Add((char)('0' + count));
            return new string(compressed.ToArray());
        }
    }
}
