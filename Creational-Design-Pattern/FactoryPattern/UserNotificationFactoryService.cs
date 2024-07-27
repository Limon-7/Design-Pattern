using System;

namespace FactoryPattern
{

    /// <summary>
    /// Product Interface
    /// </summary>
    public interface IUserNotifier
    {
        void NotifyUser(int id);
    }
    /// <summary>
    /// Concrete Product
    /// </summary>
    class EmailUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            // business logic
            Console.WriteLine($"Email Notification for {id} at {DateTime.Now}");
        }
    }
    /// <summary>
    /// Concrete Product
    /// </summary>
    class PhoneUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            // business logic
            Console.WriteLine($"Phone Notification for {id} at {DateTime.Now}");
        }
    }

    /// <summary>
    /// Creator that creates derived or product class's object
    /// </summary>
    public class UserNotificationFactoryService
    {
        public IUserNotifier UserNotifier(NotifierType type)
        {
            switch (type)
            {
                case NotifierType.Email: return new EmailUserNotifier();
                case NotifierType.Phone: return new PhoneUserNotifier();
                default: return null;
            }
        }
    }

    // client code
    public class DeliverService
    {
        private readonly UserNotificationFactoryService service;
        public DeliverService(UserNotificationFactoryService service)
        {
            this.service = service;
        }
        public void Shipment(NotifierType type)
        {
            service.UserNotifier(type).NotifyUser(1);
        }
    }

    public enum NotifierType
    {
        Email,
        Phone
    }
}