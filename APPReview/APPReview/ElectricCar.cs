using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPReview
{
    internal class ElectricCar:Car
    {
        public double BatteryCapacity { get; set; }

        public ElectricCar(string model,string make,int year,double battercapacity,CarType type, Engine engine) :base(model,make,year,type,engine)
        {
            this.Model = model;
            this.Make = make;
            this.Year = year;
            this.BatteryCapacity = battercapacity;
        }
        public override void Honk()
        {
            Console.WriteLine("Beep beep!");
        }

        public override void Accelerate()
        {
           Console.WriteLine("Electric car is accelerating.");
        }
    }
}
