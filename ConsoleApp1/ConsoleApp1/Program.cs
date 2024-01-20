using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public int numberTwo(int[] arr)
        {
            int sumtwo = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2 == 0)
                {
                    sumtwo += arr[i]/2;
                }
            }
          return sumtwo;
        }
        public bool containString(string s1,string s2)
        {
            for(int i=0; i<s1.Length; i++)
            {
                if (!s2.Contains(s1[i]))
                {
                    return false;

                }
            }
            return true;
        }
        public string ReverseWord(string str1)
        {
            string[] arr_Str = str1.Split(' '); 
            string str2 = "";
            for(int i = 0; i < arr_Str.Length; i++)
            {
                string s = arr_Str[i]; 
                for(int j = s.Length-1; j>=0; j--)
                {
                    str2 += s[j];
                }
                str2 +=' ';
            }

            return str2.Trim();
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 6, 2, 1, 2 };
  
            Program m= new Program();
            Console.WriteLine(m.numberTwo(arr));
            //Console.WriteLine(m.containString("abc","ahbgde"));
            Console.WriteLine("please enteer your value");
            var str1= Console.ReadLine();
            var str2= Console.ReadLine();
            Console.WriteLine(m.containString(str1, str2));
            string str3 = Console.ReadLine().ToString(); 
            Console.WriteLine(m.ReverseWord(str3));

            Console.ReadKey();
        }

    }
}
