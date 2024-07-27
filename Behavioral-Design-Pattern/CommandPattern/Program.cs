using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Kitchen kitchen = new Kitchen();

            // create command
            IOrderCommand pastaOrder = new PastaOrderCommand(kitchen);
            IOrderCommand burgerOrder = new BurgerOrderCommand(kitchen);
            
            OrderInvoker orderInvoker = new OrderInvoker();
            
            // add command to invoker
            orderInvoker.TakeOrder(pastaOrder);
            orderInvoker.TakeOrder(burgerOrder);

            // execute the command
            orderInvoker.PlaceOrders();
        }
    }
}
