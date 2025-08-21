namespace dependency_injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService(new ConsoleLogger());

            PaymentService();

            EmailService();

            ProductService();

            GameService();
        }

        public static void UserService(ILogger logger)
        {
            // Create a logger instance
            ILogger consoleLogger = new ConsoleLogger();
            ILogger fileLogger = new FileLogger();
            // Use the logger
            consoleLogger.Info("This is an info message.");
            fileLogger.Info("This is an info message for the file logger.");

            Console.ReadKey();


        }

        public static void PaymentService()
        {
            Console.WriteLine("Hvilken betalingsmetode vil du bruge? (Paypal, eller Stripe): ");
            string paymentMethod = Console.ReadLine().ToLower();


            if (paymentMethod != "paypal" && paymentMethod != "stripe")
            {
                Console.WriteLine("Ugyldig betalingsmetode. Vælg venligst 'Paypal' eller 'Stripe'.");
                return;
            }
            else if (paymentMethod == "stripe")
            {
                Console.WriteLine("Du har valgt Stripe som betalingsmetode.");
                Console.WriteLine("Hvor meget vil du betale?: ");
                string amountInput = Console.ReadLine();
                if (!decimal.TryParse(amountInput, out decimal amount))
                {
                    Console.WriteLine("Ugyldigt beløb. Prøv igen.");
                    return;
                }
                IPaymentProcessor paymentProcessor = new StripePaymentProcessor();
                CheckoutService checkoutService = new CheckoutService(paymentProcessor);
                checkoutService.Checkout(amount);
            }
            else
            {
                Console.WriteLine("Du har valgt PayPal som betalingsmetode.");
                Console.WriteLine("Hvor meget vil du betale?: ");
                string amountInput = Console.ReadLine();
                if (!decimal.TryParse(amountInput, out decimal amount))
                {
                    Console.WriteLine("Ugyldigt beløb. Prøv igen.");
                    return;
                }
                IPaymentProcessor paymentProcessor = new PayPalPaymentProcessor();
                CheckoutService checkoutService = new CheckoutService(paymentProcessor);
                checkoutService.Checkout(amount);
            }

            Console.ReadKey();
        }

        public static void EmailService()
        {
            Console.WriteLine("Hvilken email service vil du bruge? (Console, eller Smtp): ");
            string emailService = Console.ReadLine().ToLower();
            if (emailService != "console" && emailService != "smtp")
            {
                Console.WriteLine("Ugyldig email service. Vælg venligst 'Console' eller 'Smtp'.");
                return;
            }
            else if (emailService == "console")
            {
                IEmailSender emailSender = new ConsoleEmailSender();
                NotificationService notificationService = new NotificationService(emailSender);
                notificationService.Notify("coworker", "Test", "This is a test email sent via console email sender.");
            }
            else
            {
                IEmailSender emailSender = new SmtpEmailSender();
                NotificationService notificationService = new NotificationService(emailSender);
                notificationService.Notify("coworker", "Test", "This is a test email sent via SMTP email sender.");
            }
            Console.ReadKey();
        }

        public static void ProductService()
        {
            while (true)
            {
                Console.WriteLine("Hvilken produkt service vil du bruge? (InMemory, eller Sql). Skriv 'exit' for at stoppe:");
                string productService = Console.ReadLine().ToLower();

                if (productService == "exit")
                {
                    Console.WriteLine("Produkt service stoppet.");
                    break;
                }

                if (productService != "inmemory" && productService != "sql")
                {
                    Console.WriteLine("Ugyldig produkt service. Vælg venligst 'InMemory' eller 'Sql'.");
                    continue;
                }
                else if (productService == "inmemory")
                {
                    IProductRepository productRepository = new InMemoryProductRepository();
                    productRepository.AddProduct("Product1");
                    var products = productRepository.GetAllProducts();
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                }
                else
                {
                    IProductRepository productRepository = new SqlProductRepository();
                    productRepository.AddProduct("Product2");
                    var products = productRepository.GetAllProducts();
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                }
            }
        }

        public static void GameService()
        {
            Console.WriteLine("Hvilken spil service vil du bruge? (rps eller gæt tallet): ");
            string gameService = Console.ReadLine().ToLower();
            if (gameService == "gæt tallet")
            {
                IGameEngine gameEngine = new GuessNumberGame();
                GameRunner gameRunner = new GameRunner(gameEngine);
                gameRunner.Run();
            }
            else if (gameService == "rps")
            {
                IGameEngine gameEngine = new RockPaperScissorsGame();
                GameRunner gameRunner = new GameRunner(gameEngine);
                gameRunner.Run();
            }
        }
    }
}
