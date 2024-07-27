using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationFactoryService notificationFactoryService = new NotificationFactoryService();
            INotificationService notificationService = notificationFactoryService.CreateNotificationService("email");
            notificationService.Send("You have received a pull request");

            DeliverService deleveryService = new DeliverService(new UserNotificationFactoryService());
            deleveryService.Shipment(NotifierType.Phone);
        }
    }
}
