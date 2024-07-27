using System;
using System.Collections.Generic;

/*Subject

*/
namespace ObserverDesignPattern
{
    public interface IPublisher<T>
    {
        void RegisterObserver(IWatcher<T> observer);
        void RemoveObserver(IWatcher<T> observer);
        void NotifyObservers();
    }
    public interface IWatcher<T>
    {
        void Update(string message, T entity = default);
    }

    public class ProductPublisher : IPublisher<Product>
    {
        private List<IWatcher<Product>> observers = new List<IWatcher<Product>>();
        private string productUpdateMessage = "";
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(productUpdateMessage);
            }
        }

        public void RegisterObserver(IWatcher<Product> observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IWatcher<Product> observer)
        {
            observers.Remove(observer);
        }

        public void UpdateProductStocks(Product product, string message)
        {
            productUpdateMessage = message;
            NotifyObservers();
        }
    }

    public class ProductSubscriber : IWatcher<Product>
    {
        private string Name;
        public ProductSubscriber(string name)
        {
            Name = name;
        }
        void IWatcher<Product>.Update(string message, Product product)
        {
            Console.WriteLine($"Hello!{Name} Here is upadte{message} ");
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Product(int id, string productName, int price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }
    }
}