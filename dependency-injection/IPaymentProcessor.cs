using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    public interface IPaymentProcessor
    {
        void Process(decimal amount);
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void Process(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} through PayPal.");
        }
    }

    public class StripePaymentProcessor : IPaymentProcessor
    {
        public void Process(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} through Stripe.");
        }
    }

    public class CheckoutService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void Checkout(decimal amount)
        {
            _paymentProcessor.Process(amount);
        }
    }
}
