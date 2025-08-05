namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExtractStringFromHashtags("fe##abcwdda##efwfewf"));

            Console.WriteLine(FullSequenceOfLetters('a', 'h'));
        }

        static string ExtractStringFromHashtags(string s)
        {
            int firstHash = s.IndexOf('#');
            if (firstHash == -1) return string.Empty;

            int secondHash = s.IndexOf('#', firstHash + 1);
            if (secondHash == -1) return string.Empty;

            int thirdHash = s.IndexOf('#', secondHash + 1);
            if (thirdHash == -1) return string.Empty;

            return s.Substring(secondHash + 1, thirdHash - secondHash - 1);
        }

        static string FullSequenceOfLetters(char firstLetter, char secondLetter)
        {
            string result = string.Empty;
            if (firstLetter > secondLetter)
            {
                Console.WriteLine(firstLetter + " is greater than " + secondLetter);
            }
            for (char c = firstLetter; c <= secondLetter; c++)
            {
                result += c;
            }
            return result;
        }



    }
}
