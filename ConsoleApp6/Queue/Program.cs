using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<printJob> printJobs = new Queue<printJob>();
            printJobs.Enqueue(new printJob("documentation.docx", 1));
            printJobs.Enqueue(new printJob("USer_stories.pdf", 2));
            printJobs.Enqueue(new printJob("report.xlsx", 6));
            printJobs.Enqueue(new printJob("Payroll.report", 5));
            printJobs.Enqueue(new printJob("budget.xlsx", 4));
            printJobs.Enqueue(new printJob("alagortim.ppt", 3));

            Random rand= new Random();
            while(printJobs.Count>0) {
                Console.ForegroundColor = ConsoleColor.Green;
                var job= printJobs.Dequeue();
                Console.WriteLine($"prointing---[{job}]");
                System.Threading.Thread.Sleep(rand.Next(1,5)*1000);
            }

            Console.ReadKey();
        }
        class printJob
        {
            private readonly string _file;
            private readonly int _Copy;
            public printJob(string file,int copies)
            {
                _file = file;
                _Copy = copies;
            }
            public override string ToString() {
                return $"{_file}\t#{_Copy}Copies";
            }
        }
    }
}
