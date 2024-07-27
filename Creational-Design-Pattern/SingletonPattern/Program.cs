using System;
using System.Threading;


namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread process1 = new Thread(() =>
           {
               TestSingleton("FOO");
               TestNaiveSingleton("FOO");
           });
            Thread process2 = new Thread(() =>
            {
                TestNaiveSingleton("BAR");
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();
            process1.Join();
            process2.Join();
        }

        public static void TestNaiveSingleton(string value)
        {
            NaiveSingleton naiveSingleton = NaiveSingleton.GetInstance(value);
            Console.WriteLine($"Naive Singleton: {naiveSingleton.Value}");
        }

        public static void TestSingleton(string value)
        {
            Singleton singleton = Singleton.GetInstance(value);
            Console.WriteLine($"Thread-safe Singleton: {singleton.Value}");
        }
    }
}
