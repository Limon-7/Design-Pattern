using System;

namespace SingletonPattern
{
    /// <summary>
    /// This is not thread safe
    /// </summary>
    public sealed class Singleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }
        private static Singleton _instance;

        // We now have a lock object that will be used to synchronize threads
        // during first access to the Singleton.
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new Singleton();
                    _instance.Value = value;
                }
            }
            return _instance;
        }

        public string Value { get; set; }

        public void BusinessLogic()
        {
            // ...
        }

    }
}