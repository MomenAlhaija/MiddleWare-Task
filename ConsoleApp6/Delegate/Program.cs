using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = new Employee[] {
            new Employee { Id = 1, Name = "Issam A", Gender = "M", TotalSales = 65000m },
            new Employee { Id = 2, Name = "Reem S", Gender = "F", TotalSales = 50000m },
            new Employee { Id = 3, Name = "Suzan B", Gender = "F", TotalSales = 65000m },
            new Employee { Id = 4, Name = "Sara A", Gender = "F", TotalSales = 40000m },
            new Employee { Id = 5, Name = "Salah C", Gender = "M", TotalSales = 420000m },
            new Employee { Id = 6, Name = "Rateb A", Gender = "M", TotalSales = 30000m },
            new Employee { Id = 7, Name = "Abeer C", Gender = "F", TotalSales = 16000m },
            new Employee { Id = 8, Name = "Marwan M", Gender = "M", TotalSales = 15000m }



            };
            var report = new Reports();
            //report.ProcessEmployee60000plusSales(emps);
            //report.ProcessEmployeebetween30000and59999Sales(emps);
            //report.ProcessEmploylessthan30000Sales(emps);

            report.EmployeeProcess(emps, "sales>=60000",  e=> e.TotalSales > 60000 );
            report.EmployeeProcess(emps, "sales<60000&&sales>=30000", e=> e.TotalSales > 30000 && e.TotalSales < 60000);
            report.EmployeeProcess(emps, "sales<30000",  e => e.TotalSales < 30000);

            Console.ReadKey();
        }
        public class Employee 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal TotalSales { get; set; }
            public string Gender { get; set; }
        }
        static bool ISGreaterthan60000(Employee e) => e.TotalSales >= 60000;
        static bool ISbetween30000and600000(Employee e) => e.TotalSales >= 30000&&e.TotalSales<60000;
        static bool ISlessthan30000(Employee e) => e.TotalSales < 30000;

    }
}
