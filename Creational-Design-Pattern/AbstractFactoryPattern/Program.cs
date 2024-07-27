using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            INotificationFactory notificationFactory = new NotificationFactory();

            // Create an EmailNotificationServiceFactory using the NotificationFactory
            INotificationServiceFactory emailFactory = notificationFactory.CreateEmailNotificationServiceFactory();
            INotificationService emailService = emailFactory.CreateNotificationService();
            emailService.Send("Hello from email notification!");

            // Create an SMSNotificationServiceFactory using the NotificationFactory
            INotificationServiceFactory smsFactory = notificationFactory.CreateSMSNotificationServiceFactory();
            INotificationService smsService = smsFactory.CreateNotificationService();
            smsService.Send("Hello from SMS notification!");

            IVehicleFactory regularVehicleFactory = new RegularVehicleFactory();
            IBike regularBike = regularVehicleFactory.CreateBike();
            regularBike.GetDetails();

            ICar regularCar = regularVehicleFactory.CreateCar();
            regularCar.GetDetails();
        }
    }
}
