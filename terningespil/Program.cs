namespace terningespil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Console.WriteLine("how many dice do you want to roll?");
            int numberOfDice = int.Parse(Console.ReadLine() ?? "1");
            Console.WriteLine("how many sides does the dice have?");
            int numberOfSides = int.Parse(Console.ReadLine() ?? "6");
            for (int i = 0; i < numberOfDice; i++)
            {
                Console.WriteLine(dice.Roll(1, numberOfSides + 1));  
            }


        }
    }

    public class Dice
    {
        private static readonly Random random = new Random();
        public int Roll(int a, int b)
        {
            return random.Next(a, b);
        }
    }
}
