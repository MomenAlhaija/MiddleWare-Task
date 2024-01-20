using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Egyp = new Country() { IsoCode = "EGY", Name = "Egypt" };
            var EJor = new Country() { IsoCode = "JOR", Name = "Jordan" };
            var Eira = new Country() { IsoCode = "IRQ", Name = "Iraq" };
            var Efra = new Country() { IsoCode = "FRA", Name = "France" };

            Country[] countries = new Country[] { Egyp, EJor, Eira,Efra };

            //Contsructor for List

                        List<Country> list = new List<Country>();
            //            List<Country> list = new List<Country>(3); =>//Intial Capacity
           ///            List<Country> list = new List<Country>(countries);
            //Properties for List


            //Methods for list
            list.Add(Egyp);//add the item at end of the list Time Complixity O(1)
            list.AddRange(countries); ;//add the items at end of the list Time Complixity O(1) 
            list.Insert(1, new Country{IsoCode="BRA",Name="Brasil"});
            Print(list);
            Console.WriteLine("---------------------------------------------");
            list.RemoveAt(2); //Time complixty O(n)
            Print(list);
            Console.WriteLine("---------------------------------------------");
            list.RemoveAll(x => x.Name.EndsWith("ce"));
            Print(list);
            Console.WriteLine("---------------------------------------------");
            list.Remove(new Country() { IsoCode = "FRA", Name = "France" });
            Print(list);
            Console.ReadKey();
        }

        static void Print(List<Country> countries)
        {
            foreach(var item in  countries)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Count:{countries.Count}");  //Actual count
            Console.WriteLine($"Capacity:{countries.Capacity}"); 
        }
    }
}
 