using System;
using System.Text.Json;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderBuilder = new OrderBuilder();
            var order = orderBuilder.SetProductName("Laptop")
                                    .SetQuantity(2)
                                    .SetPrice(1000)
                                    .CalculateTotalAmount()
                                    .Build();
            Console.WriteLine(JsonSerializer.Serialize<Order>(order));
        }
    }

    public class Order
    {
        public string ProductName { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal Price { get; internal set; }
        public decimal TotalAmount { get; internal set; }
    }

    public class OrderBuilder
    {
        private Order _order = new Order();

        public OrderBuilder SetProductName(string productName)
        {
            _order.ProductName = productName;
            return this;
        }

        public OrderBuilder SetQuantity(int quantity)
        {
            _order.Quantity = quantity;
            return this;
        }

        public OrderBuilder SetPrice(decimal price)
        {
            _order.Price = price;
            return this;
        }

        public OrderBuilder CalculateTotalAmount()
        {
            _order.TotalAmount = _order.Quantity * _order.Price;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}
