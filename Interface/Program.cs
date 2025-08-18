namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            PayPalPayment payPalPayment = new PayPalPayment();

            creditCardPayment.ProcessPayment(100.00m);
            payPalPayment.ProcessPayment(200.00m);


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
