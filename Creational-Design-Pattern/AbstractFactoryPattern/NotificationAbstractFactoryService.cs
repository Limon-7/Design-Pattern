using System;

namespace AbstractFactoryPattern
{

    /// <summary>
    /// Product Interface
    /// </summary>
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

    // Factories Interfaces
    public interface INotificationServiceFactory
    {
        INotificationService CreateNotificationService();
    }

    public interface INotificationFactory
    {
        INotificationServiceFactory CreateEmailNotificationServiceFactory();
        INotificationServiceFactory CreateSMSNotificationServiceFactory();
    }


    // Implementations of Factories
    public class NotificationFactory : INotificationFactory
    {
        public INotificationServiceFactory CreateEmailNotificationServiceFactory()
        {
            return new EmailNotificationServiceFactory();
        }

        public INotificationServiceFactory CreateSMSNotificationServiceFactory()
        {
            return new SMSNotificationServiceFactory();
        }
    }

    public class EmailNotificationServiceFactory : INotificationServiceFactory
    {
        public INotificationService CreateNotificationService()
        {
            return new EmailNotificationService();
        }
    }

    public class SMSNotificationServiceFactory : INotificationServiceFactory
    {
        public INotificationService CreateNotificationService()
        {
            return new SMSNotificationService();
        }
    }
}