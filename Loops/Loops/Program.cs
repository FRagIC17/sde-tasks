namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiplication Table (1 to 10):\n");
            MultiplicationTable();


            int[] numbers = { 5, 12, 3, 21, 7, 9 };
            Console.WriteLine(TheBiggestNumber(numbers));

            int[] numbersWithSevens = { 1, 2, 7, 7, 4, 5, 7, 7 };
            int index = Two7sNextToEachOther(numbersWithSevens);
            if (index != -1)
            {
                Console.WriteLine($"Two 7s found at index: {index}");
            }
            else
            {
                Console.WriteLine("No two 7s found next to each other.");
            }

            int[] increasingNumbers = { 1, 4, 5, 6, 12, 56, 11 };
            AllThreeIncreasingNumbers(increasingNumbers);


            SieveOfEratosthenes(30);

            Console.WriteLine(ExtractStringFromHashtags("fe##abcwdda##efwfewf"));

            Console.WriteLine(FullSequenceOfLetters('a', 'h'));

            Console.WriteLine(SumAndAvarageOfNumbers(1, 10));

            DrawTriangle();

            Console.WriteLine(ToThePowerOfNextNumber(-2, 3));

        }


        static void MultiplicationTable()
        {
            

            Console.Write("     ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i,4}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i,3} |");
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j,4}");
                }
                Console.WriteLine();
            }
        }

        static int TheBiggestNumber(int[] numbers)
        {
            int biggest = numbers[0];
            foreach (int number in numbers)
            {
                if (number > biggest)
                {
                    biggest = number;
                }
            }
            return biggest;
        }

        static int Two7sNextToEachOther(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 7 && numbers[i + 1] == 7)
                {
                    return i;
                }
            }
            return -1;
        }

        static void AllThreeIncreasingNumbers(int[] numbers)
        {
            bool found = false;
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i + 1] == numbers[i] + 1 && numbers[i + 2] == numbers[i + 1] + 1)
                {
                    Console.WriteLine($"Three increasing numbers found starting at index: {i} ({numbers[i]}, {numbers[i + 1]}, {numbers[i + 2]})");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No three increasing numbers found.");
            }
        }



        static void SieveOfEratosthenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }
            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }
            Console.WriteLine($"Prime numbers up to {n}:");
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
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

        static string SumAndAvarageOfNumbers(int firstNumber, int secondNumber)
        {
            int sum = 0;
            int count = secondNumber - firstNumber + 1;
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                sum += i;
            }

            double average = (double)sum / count;

            return $"Sum: {sum}, Average: {average}";
        }

        static string DrawTriangle()
        {
            string result = string.Empty;
            int height = 10;

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= height - i; j++)
                {
                    result += " ";
                }
                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    result += "*";
                }
                result += "\n";
            }
            Console.WriteLine(result);
            return result;
        }

        static int ToThePowerOfNextNumber(int a, int b)
        {
            int result = 1;
            for (int i = 1; i <= b; i++)
            {
                result *= a;
            }
            return result;
        }
    }
}
