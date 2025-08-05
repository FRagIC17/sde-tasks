namespace conditional_statements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AbsoluteValue(-342));

            Console.WriteLine(DivisibleMethod(7, 12));

            Console.WriteLine(Uppercase("Hej"));

            Console.WriteLine(GreaterThanThirdNumber(5, 2, 20));

            Console.WriteLine(IsEven(2897237));

            Console.WriteLine(IsSortedAscending(1, 3, 2));

            Console.WriteLine(PositiveOrNegative(-5));

            Console.WriteLine(IfYearIsLeapYear(2024));
        }

        static int AbsoluteValue(int number)
        {
            if (number < 0)
            {
                return -number;
            }
            else
            {
                return number;
            }
        }

        static int DivisibleMethod(int a, int b)
        {
            if ((a % 2 == 0 || a % 3 == 0) && (b % 2 == 0 || b % 3 == 0))
            {
                return a * b;
            }
            else
            {
                return a + b;
            }
        }

        static String Uppercase(String input)
        {
            bool isUppercase = true;

            if (string.IsNullOrEmpty(input) && input.All(c => char.IsUpper(c) && char.IsLetter(c)))
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }

        static bool GreaterThanThirdNumber(int a, int b, int c)
        {
            List<int> numbers = new List<int>();

            numbers.Add(a);
            numbers.Add(b);
            numbers.Add(c);

            if (a + b > c || a * b > c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsEven(int number) { if (number % 2 == 0) { return true; } else { return false; } }

        static bool IsSortedAscending(int a, int b, int c)
        {
            List<int> numbers = new List<int>();
            numbers.Add(a);    
            numbers.Add(b);
            numbers.Add(c);

            if (numbers[0] <= numbers[1] && numbers[1] <= numbers[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static String PositiveOrNegative(int number)
        {
            if (number > 0)
            {
                return "positive";
            }
            else if (number < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }

        static bool IfYearIsLeapYear(int year)
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
