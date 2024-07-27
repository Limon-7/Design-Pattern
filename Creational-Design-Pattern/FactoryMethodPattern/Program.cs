using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new EmailNotificationServiceCreator().CreateNotificationService();
            service.Send("Hello from limon");
        }
    }

    /// <summary>
    /// Product Interface
    /// </summary>
    public interface INotificationService
    {
        void Send(string message);
    }
    // Concrete Prodct for EmailNotificationService
    public class EmailNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    // Concrete Prodct for SMSNotificationService
    public class SMSNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
    // Base Creator Class
    public abstract class NotificationServiceCreator
    {
        public abstract INotificationService CreateNotificationService();
    }

    // EmailNotificationServiceCreator
    public class EmailNotificationServiceCreator : NotificationServiceCreator
    {
        public override INotificationService CreateNotificationService()
        {
            return new EmailNotificationService();
        }
    }

    // SMSNotificationServiceCreator
    public class SMSNotificationServiceCreator : NotificationServiceCreator
    {
        public override INotificationService CreateNotificationService()
        {
            return new SMSNotificationService();
        }
    }

    // // Usage
    // public class NotificationController : ControllerBase
    // {
    //     private readonly SMSNotificationServiceCreator _creator;

    //     public NotificationController(SMSNotificationServiceCreator creator)
    //     {
    //         _creator = creator;
    //     }

    //     public IActionResult SendNotification(string message)
    //     {
    //         var service = _creator.CreateNotificationService();
    //         service.Send(message);
    //         return Ok();
    //     }
    // }
}
