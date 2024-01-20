using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
public class MATH
{ 
    private int plus;
    private int minus;
    private int Mult;
    private int Div;
    private int Mod;
    public MATH() { }
    public MATH(int plus,int minus,int muy,int div,int mod) { 
        this.plus = plus;
        this.minus = minus;
        this.Mult = muy;
        this.Div = div;
        this.Mod = mod;
    }
    public MATH Sum(MATH m1,MATH m2)
    {
        MATH m = new MATH();

        m.plus = m1.plus+m2.plus;
        m.Mult = m1.Mult*m2.Mult; 
        m.Div = m1.Div/m2.Div;
        m.minus = m1.minus-m2.minus;
        return m;
    }
}

namespace ConsoleApp3
{
    enum Months
    {
        January = 1,    // 0
        February,   // 1
        March,    // 6
        April,      // 7
        May,        // 8
        June,       // 9
        July        // 10
    }

    internal class Program
    {
        static void Main(string[] args)
        {
          Months months = Months.March;
            switch (months) { 
            case Months.January:
                    Console.WriteLine(1);
                    break; 
             case Months.February:
                    Console.WriteLine(1);
                    break;
             case Months.March:
                    Console.WriteLine(3);
                    break;
             case Months.June:
                    Console.WriteLine(4);
                    break;
             case Months.July:
                    Console.WriteLine(5);
                    break;

                default:
                    Console.WriteLine(7);
                    break;

            }
        }
    }
}
