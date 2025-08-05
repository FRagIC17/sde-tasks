namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddAndMultiply(2, 4, 5));

            Console.WriteLine(CelciusToFahrenheit(100));

            Console.WriteLine(ElementaryOperations(3, 8));

            Console.WriteLine(ResultIsSame(2, 2, 3, 5));

            Console.WriteLine(DivideModulus(11, 5, 2));

            Console.WriteLine(CubeOfNumber(-5.5));

            SwapNumbers(47, 85);
        }

        static int AddAndMultiply(int a, int b, int c) { 
            return (a + b) * c;
        }

        static double CelciusToFahrenheit(double celcius)
        {
            double fahrenheit = (celcius * 9 / 5) + 32;

            if (celcius < -271.15)
            {
                Console.WriteLine("ERROR: below absolute zero");
            }

            return fahrenheit;
        }

        static String ElementaryOperations(double a, double b)
        {
            double add = a + b;
            double subtract = a - b;
            double multiply = a * b;
            double divide = a / b;

            string result = add.ToString() + " " + subtract.ToString() + " " + multiply.ToString() + " " + divide.ToString();
            
            return result;
        }

        static String ResultIsSame(int a, int b, int c, int d)
        {
            
            int addition = a + b;
            int multiply = a * b;
            bool isEqual1 = addition == multiply;

            int divide = c / d;
            int subtraction = c - d;

            bool isEqual2 = divide == subtraction;

            return $"addition: {addition} multiply: {multiply} is equal = {isEqual1} \n" +
                $"subtraction: {subtraction} divide: {divide} is equal = {isEqual2}";

        }

        static double DivideModulus(double a, double b, double c)
        {
            double modulo = (a % b) % c;
            return modulo;
        }

        static double CubeOfNumber(double a)
        {
            double result = a * a * a;
            return result;
        }

        static Array SwapNumbers(int a, int b)
        {
            int[] array = new int[2];
            array[0] = a;
            array[1] = b;
            Console.WriteLine($"Before swap: {array[0]}, {array[1]}");
            // Swap the numbers
            int temp = array[0];
            array[0] = array[1];
            array[1] = temp;
            Console.WriteLine($"After swap: {array[0]}, {array[1]}");
            return array;
        }
    }
}
