namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IPayment interface and its implementations
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            PayPalPayment payPalPayment = new PayPalPayment();

            creditCardPayment.ProcessPayment(100.00m);
            payPalPayment.ProcessPayment(200.00m);

            // IPrintable interface and its implementations
            List<IPrintable> printables = new List<IPrintable>
            {
                new Invoice(),
                new Report(),
                new Letter()
            };

            foreach (var printable in printables)
            {
                printable.Print();
            }


            // IDrivable interface and its implementations
            Car car = new Car();
            car.Start();
            car.Stop();
            Motorcycle motorcycle = new Motorcycle();
            motorcycle.Start();
            motorcycle.Stop();


            // IMakeSound interface and its implementations
            List<IMakeSound> animals = new List<IMakeSound>
            {
                new Dog(),
                new Cat(),
                new Cow()
            };

            foreach (var animal in animals)
            {
                animal.MakeSound();
            }

            // IWeapon interface and its implementations
            Sword sword = new Sword();
            Bow bow = new Bow();
            Staff staff = new Staff();
            sword.Attack();
            bow.Attack();
            staff.Attack();


        }
    }

    public interface IPayment
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount} kr");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount} kr");
        }
    }
}
