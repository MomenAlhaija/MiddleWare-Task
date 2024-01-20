using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ConsoleApp17
{
    
    internal class Customer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Customer()
        {
            
        }
        public Customer(int _ID,string name)
        {
            this.Id = _ID;
            this.Name = name;
        }
        public void PrentId() =>
            Console.WriteLine($"Employee ID:{Id}\n");
        public void PrentName() =>
           Console.WriteLine($"Employee Name:{Name}");
    }
}
