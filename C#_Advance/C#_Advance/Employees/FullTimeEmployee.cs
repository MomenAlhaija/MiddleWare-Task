using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Advance.Employees
{
    internal class FullTimeEmployee:Employee
    {
        public FullTimeEmployee()
        {

        }
        public FullTimeEmployee(string firstName, string lastName, string Address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.Address = Address;
        }
        public override void PrintEmployeeInfo() =>
            Console.WriteLine($"Employee Name:{firstName + " " + lastName}\n" +
                $"Address:{Address}\n" +
                $"The Employee work as full Time\n");
    }
}
