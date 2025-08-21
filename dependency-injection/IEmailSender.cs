using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    public interface IEmailSender
    {
        void SendEmail(string to, string subject, string body);
    }

    public class ConsoleEmailSender : IEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}' via console");
        }
    }

    public class SmtpEmailSender : IEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}' via stmp");
        }



    }
    public class NotificationService
    {
        private readonly IEmailSender _emailSender;
        public NotificationService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public void Notify(string to, string subject, string body)
        {
            _emailSender.SendEmail(to, subject, body);
        }
    }
}
