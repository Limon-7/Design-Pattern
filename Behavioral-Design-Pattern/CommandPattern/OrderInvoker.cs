using System;
using System.Collections.Generic;

namespace CommandPattern
{

    // Base Command Interface
    public interface ICommnad
    {
        void Execute();
    }
    // Order command Interface
    public interface IOrderCommand : ICommnad { }

    // Receiver
    public class Kitchen
    {
        public void PreparePasta()
        {
            Console.WriteLine("Preparing Pasta...");
        }
        public void PrepareBurger()
        {
            Console.WriteLine("Preparing Burger...");
        }
    }

    // Concrete command
    public class PastaOrderCommand : IOrderCommand
    {
        private Kitchen _kitchen;
        public PastaOrderCommand(Kitchen kitchen)
        {
            _kitchen = kitchen;
        }
        public void Execute()
        {
            _kitchen.PreparePasta();
        }
    }

    // Concrete command
    public class BurgerOrderCommand : IOrderCommand
    {
        private Kitchen _kitchen;
        public BurgerOrderCommand(Kitchen kitchen)
        {
            _kitchen = kitchen;
        }
        public void Execute()
        {
            _kitchen.PrepareBurger();
        }
    }

    // Invocker holds the command
    public class OrderInvoker
    {
        private List<IOrderCommand> _orders = new List<IOrderCommand>();
        public void TakeOrder(IOrderCommand orderCommand)
        {
            _orders.Add(orderCommand);
        }
        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}