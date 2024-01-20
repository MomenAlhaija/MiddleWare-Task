using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var article =
                "Ability to develop and run on Windows, macOS, and Linux" +
                "Ability to develop and run on Windows, macOS, and Linux" +
                "Support for hosting Remote Procedure Call (RPC) services using gRPC"+
                "Support for hosting Remote Procedure Call (RPC) services using gRPC";
            Dictionary<char,List<string>> letters= new Dictionary<char,List<string>>();

            foreach (var word in article.Split())
            {
                foreach (var letter in word)
                {
                    if (!letters.ContainsKey(letter))
                    {
                        letters.Add(letter, new List<string>() {word});
                    }
                    else { letters[letter].Add(word);}
                }
            }
            foreach (var entry in letters)
            {
                Console.WriteLine($"'{entry.Key}':");
                foreach (var word in entry.Value)
                {
                    Console.WriteLine($"\t\t\"{word}\"");
                }
                Console.WriteLine("\t\t\t"+entry.Value.Count);
            }


            var emps = new List<Employee>()
            {
                new Employee() {Id=100,Name="Reem s.",Reportid=null  },
                new Employee() {Id=101,Name="Reem M.",Reportid=100  },
                new Employee() {Id=102,Name="Ali B.",Reportid=100  },
                new Employee() {Id=103,Name="Abber s.",Reportid=102  },
                new Employee() {Id=104,Name="Redwan N.",Reportid=102  },
                new Employee() {Id=105,Name="Nancy A.",Reportid=101  },
                new Employee() {Id=106,Name="Saleh R.",Reportid=104  }

            };
//            var mengers = emps.GroupBy(x => x.Reportid);

            var mengers = emps.ToLookup(x => x.Reportid).ToDictionary(x=>x.Key??-1,x=>x.ToList());
            foreach (var entry in mengers)
            {
                if (entry.Key == -1) { continue; }
                var man=emps.First(x=>x.Id==entry.Key);
                Console.WriteLine($"{man}");
                foreach(var e in entry.Value)
                {
                    Console.WriteLine($"\t\t\"{e}\"");
                }
            }
            Console.ReadKey();
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? Reportid { get; set; }

            public override string ToString()
            {
                return $"[{Id}]{Name}";
            }
        }

    }
}
