namespace ObserverDesignPattern
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


            Product product = new Product(1, "IMAC", 300);
            var productPublisher = new ProductPublisher();
            IWatcher<Product> productSubscriber1 = new ProductSubscriber("Limon");
            IWatcher<Product> productSubscriber2 = new ProductSubscriber("XXXX");

            productPublisher.RegisterObserver(productSubscriber1);
            productPublisher.RegisterObserver(productSubscriber2);

            productPublisher.UpdateProductStocks(product, "New product is created");

        }
    }
}
