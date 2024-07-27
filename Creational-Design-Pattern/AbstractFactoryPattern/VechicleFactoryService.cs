using System;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// Product1 Interface
    /// </summary>
    public interface ICar
    {
        void GetDetails();
    }

    /// <summary>
    /// Product2 Interface
    /// </summary>
    public interface IBike
    {
        void GetDetails();
    }

    /// <summary>
    /// Concreate Product
    /// </summary>
    public class RegularBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching RegularBike Details..");
        }
    }

    /// <summary>
    /// Concreate Product
    /// </summary>
    public class SportsBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching SportsBike Details..");
        }
    }

    /// <summary>
    /// Concreate Product
    /// </summary>
    public class RegularCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching RegularCar Details..");
        }
    }
    /// <summary>
    /// Concreate Product
    /// </summary>
    public class SportsCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching SportsCar Details..");
        }
    }


    /// <summary>
    /// Create AbstractFactory
    /// </summary>
    public interface IVehicleFactory
    {
        //Abstract Product A
        IBike CreateBike();
        //Abstract Product B
        ICar CreateCar();
    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }
        public ICar CreateCar()
        {
            return new RegularCar();
        }
    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class SportsVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new SportsBike();
        }
        public ICar CreateCar()
        {
            return new SportsCar();
        }
    }

}