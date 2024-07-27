using System;

namespace FactoryPattern
{

    // Product Interface
    public interface INotificationService
    {
        void Send(string message);
    }

    // Concreate EmailNotificationService Implementation
    public class EmailNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    // Concreate SMSNotificationService Implementation
    public class SMSNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    // NotificationServiceFactory
    public class NotificationFactoryService
    {
        public INotificationService CreateNotificationService(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotificationService();
                case "sms":
                    return new SMSNotificationService();
                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }
}