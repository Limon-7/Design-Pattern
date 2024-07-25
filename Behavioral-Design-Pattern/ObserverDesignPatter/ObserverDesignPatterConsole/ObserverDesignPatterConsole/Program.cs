using System;
using System.Collections.Generic;

namespace ObserverDesignPatterConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User Limon = new User("Limon");
            User Likhon = new User("Likhon");
            Follower saad = new Follower("Saad");
            Follower sarah = new Follower("Sarah");
            Limon.Subscribe(saad); // saad follows Limon
            Likhon.Subscribe(sarah);   // sarah follows Likhon
            Limon.Subscribe(sarah);   // sarah follows Limon
            Limon.PostMessage("Hello from Limon!");
            Likhon.PostMessage("Rout's first post.");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Observer Interface
    /// </summary>
    public interface IObserver
    {
        void Update(User user, string message);
    }

    /// <summary>
    /// Concrete Observer: Follower
    /// </summary>
    public class Follower : IObserver
    {
        public string Name { get; private set; }
        public Follower(string name)
        {
            Name = name;
        }
        public void Update(User user, string message)
        {
            Console.WriteLine($"{Name} received a new post from {user.Name}: {message} time: {DateTime.Now}");
        }
    }

    /// <summary>
    /// Subject Interface
    /// </summary>
    public interface IUserSubject
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);
        void NotifyObservers(string message);
    }


    public class User : IUserSubject
    {
        public string Name { get; private set; }
        private List<IObserver> _observers = new List<IObserver>();
        public User(string name)
        {
            Name = name;
        }
        public void Subscribe(IObserver observer) => _observers.Add(observer);
        public void UnSubscribe(IObserver observer) => _observers.Remove(observer);
        public void PostMessage(string message)
        {
            Console.WriteLine($"{Name} posted: {message}");
            NotifyObservers(message);
        }
        public void NotifyObservers(string message) => _observers.ForEach(observer => observer.Update(this,message));
    }
}
