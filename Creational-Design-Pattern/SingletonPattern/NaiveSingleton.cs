using System;

namespace SingletonPattern
{
    /// <summary>
    /// This is not thread safe
    /// </summary>
    public sealed class NaiveSingleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private NaiveSingleton() { }
        private static NaiveSingleton _instance;
        public static NaiveSingleton GetInstance(string value)
        {
            if (_instance == null)
            {
                _instance = new NaiveSingleton();
                _instance.Value = value;
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