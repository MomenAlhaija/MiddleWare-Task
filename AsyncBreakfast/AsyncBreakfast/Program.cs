using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    internal class Program
    {
        public delegate string DelegateWithParameter(int i, int i2);
        static async Task  Main(string[] args)
        {

            DelegateWithParameter delegateWithParameter = new DelegateWithParameter(GetString);
            string str= delegateWithParameter(1,5);
            Console.WriteLine(str); 
        }
        public static void Print() => Console.WriteLine("Hello World!");
        public static string GetString(int i,int i2)=>Convert.ToString(i)+" "+Convert.ToString(i2);
    }
}

