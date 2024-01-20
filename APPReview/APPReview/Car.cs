using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace APPReview
{
    enum CarType
    {

        Sedan,
        SUV,
        Convertible,
        Truck,
    }
    internal abstract class Car : IDriveable
    {
      
        public abstract void Accelerate();
        public static int NumberOfCars;
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public Engine? Engine { get; set; }
        public CarType? Type { get; set; }
        static Car()
        {
            NumberOfCars = 0;
        }
        public Car(string make, string model, int year, CarType type, Engine engine)
        {
            this.Year = year;
            this.Make = make;
            this.Model = model;
            this.Type = type;
            this.Engine = engine;
            NumberOfCars++;
        }
        public void Start()
        {
            Console.WriteLine("Car started");
        }
        public void start(string ignitionType)
        {
            Console.WriteLine($"Car started using {ignitionType} ignition");
        }
        public virtual void Honk()
        {
            Console.WriteLine("Honk honk!");
        }

        public void IDriveable(int miles)
        {
            Console.WriteLine($"Driving {miles} miles.");
        }




        
    }
}
