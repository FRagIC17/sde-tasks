using System.Security.Cryptography.X509Certificates;
using System;

namespace vehicle_OOP
{
    internal class Vehicles
    {
        static void Main(string[] args)
        {
           Car myCar = new Car();
           Bicycle myBicycle = new Bicycle();
           myCar.Drive();
           myBicycle.Drive();

            List<Animal> animals = new List<Animal>
            {
                new Lion(),
                new Elephant(),
                new Parrot()
            };

            foreach (var animal in animals)
            {
                Console.Write($"The {animal.GetType().Name} says: ");
                animal.MakeSound();
            }

            Payment myPayment = new Payment();
            CreditCardPayment myCreditCardPayment = new CreditCardPayment();
            PayPalPayment myPayPalPayment = new PayPalPayment();
            myPayment.ProcessPayment();
            myCreditCardPayment.ProcessPayment();
            myPayPalPayment.ProcessPayment();

            Circle myCircle = new Circle(5);
            Console.WriteLine("areal af cirkel: " + myCircle.GetArea());
            Console.WriteLine("omkreds af cirkel: " + myCircle.GetPerimeter());
            Rectangle myRectangle = new Rectangle(4, 6);
            Console.WriteLine("areal af firkant: " + myRectangle.GetArea());
            Console.WriteLine("omkreds af firkant: " + myRectangle.GetPerimeter());

            Character player1 = new Warrior("Aragorn", 100, 20);
            Character player2 = new Mage("Gandalf", 80, 30);
            while (player1.Health > 0 && player2.Health > 0)
            {
                player1.Health -= player2.Attack();
                player2.Health -= player1.Attack();
                Console.WriteLine($"{player1.Name} Health: {player1.Health}");
                Console.WriteLine($"{player2.Name} Health: {player2.Health}");
                Console.WriteLine($"{player1.Name} attacks with damage: {player1.Attack()}");
                Console.WriteLine($"{player2.Name} attacks with damage: {player2.Attack()}");
            }
            if (player1.Health <= 0)
            {
                Console.WriteLine($"{player2.Name} wins!");
            }
            else if (player2.Health <= 0)
            {
                Console.WriteLine($"{player1.Name} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }



        }
    }

    public class Vehicle
    {
        string Brand;

        int MaxSpeed;
        
        public void Drive() {             
            Console.WriteLine("The vehicle is moving.");
        }
    }

    public class Car : Vehicle
    {
        int NumberOfDoors;
        public new void Drive()
        {
            Console.WriteLine("The car is driving.");
        }
    }

    public class Bicycle : Vehicle
    {
        Boolean HasBell;

        public new void Drive()
        {
            Console.WriteLine("The bicycle is pedaling.");
        }
    }
}
