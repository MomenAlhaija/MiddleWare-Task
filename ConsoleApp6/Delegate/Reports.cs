using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Delegate.Program;

namespace Delegate
{
    internal class Reports
    {
        public delegate bool illegiableSales(Employee emp);
        public void EmployeeProcess(Employee[] employees,string Title, illegiableSales illegiableSales) {


            Console.WriteLine(Title);
            Console.WriteLine("--------------------------------------");
            foreach (Employee emp in employees)
            {
                if (illegiableSales(emp))
                {
                    Console.WriteLine($"{emp.Id}|{emp.Name}|{emp.Gender}|{emp.TotalSales}");


                }
            }
            Console.WriteLine("\n\n");
        }
        public void ProcessEmployee60000plusSales(Employee[] emplyees)
        {
            Console.WriteLine("Employees with sales plus 60000 sales");
            Console.WriteLine("--------------------------------------");
            foreach (Employee emp in emplyees)
            {
                if (emp.TotalSales >= 60000)
                {
                    Console.WriteLine($"{emp.Id}|{emp.Name}|{emp.Gender}|{emp.TotalSales}");


                }
            }
            Console.WriteLine("\n\n");

        }

        public void ProcessEmployeebetween30000and59999Sales(Employee[] emplyees) { 
            Console.WriteLine("Employees with Salaes between 30000 and 59,999 sales");
            Console.WriteLine("--------------------------------------");
            foreach (Employee emp in emplyees)
            {
                if (emp.TotalSales < 60000 && emp.TotalSales>=30000)
                {
                    Console.WriteLine($"{emp.Id}|{emp.Name}|{emp.Gender}|{emp.TotalSales}");


                }
            }
            Console.WriteLine("\n\n");
        }
        public void ProcessEmploylessthan30000Sales(Employee[] emplyees)
        {

            Console.WriteLine("Employees with sales less than 30000 sales");
            Console.WriteLine("--------------------------------------");
            foreach (Employee emp in emplyees)
            {
                if (emp.TotalSales < 30000)
                {
                    Console.WriteLine($"{emp.Id}|{emp.Name}|{emp.Gender}|{emp.TotalSales}");


                }
            }
            Console.WriteLine("\n\n");

        }
    }
}
