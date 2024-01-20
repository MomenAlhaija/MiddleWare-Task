using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lesson1 = new Youtube { id = "YTV1", title = "varaibles", Duration = new TimeSpan(00, 30, 00) };
            var lesson2 = new Youtube { id = "YTV2", title = "Classes", Duration = new TimeSpan(01, 20, 00) };
            var lesson3 = new Youtube { id = "YTV3", title = "Expressions", Duration = new TimeSpan(00, 45, 00) };
            var lesson4 = new Youtube { id = "YTV4", title = "Iterations", Duration = new TimeSpan(01, 10, 00) };
            var lesson5 = new Youtube { id = "YTV5", title = "Generics", Duration = new TimeSpan(00, 20, 00) };
            LinkedList<Youtube> veidos= new LinkedList<Youtube>(new Youtube[]
            {
                lesson1,
                lesson2,
                lesson3,
                lesson4,
                lesson5,
            });

            Print("C# from zero to hero", veidos);
            Console.ReadKey();
        }
        static void Print(string Title,LinkedList<Youtube> vedios)
        {
            Console.WriteLine($"┌{Title}");
            foreach(var vedio in vedios)
            {
                Console.WriteLine(vedio);
            }
            Console.WriteLine($"─└");
        }
    }
}
