using C__Advance.MyFamily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Advance.Employees
{
    internal class Employee
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Address { get; set; }
        public Employee()
        {
            
        }
        public Employee(string firstName,string lastName,string Address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.Address = Address;
        }
        public virtual void PrintEmployeeInfo()
        {
            Console.WriteLine($"Employee Name:{firstName + " " + lastName}\n" +
                $"Address:{Address}\n");
        }

    }
}
