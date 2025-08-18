using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicle_OOP
{
    public class Payment
    {
        int Amount;
        int Currency;

        public void ProcessPayment()
        {
            Console.WriteLine("Processing generic payment");
        }
    }

    public class CreditCardPayment : Payment
    {
        string CardNumber;
        public void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment");
        }
    }

    public class PayPalPayment : Payment
    {
        string Email;
        public void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment");
        }
    }
}
