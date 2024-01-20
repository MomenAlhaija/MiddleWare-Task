using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'rotLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER d
     */

    public static List<int> rotLeft(List<int> a, int d)
    {
        List<int> arr2 = new List<int>();
        arr2 = a;
        int firstitem = arr2[0];
        if (d > 0)
        {

            for (int i = 1; i < a.Count; i++)
            {
                arr2[i - 1] = arr2[i];
            }
            d--;
            arr2[arr2.Count - 1] = firstitem;
            return rotLeft(arr2, d);
        }
        return arr2;


    }

    class Solution
    {
        public static string RemoveExclamationMarks(string s)
        {
            // Your code goes here
            string s2 = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '!')
                    continue;
                s2 += s[i];
                if (char.IsLower(s[i])) { }
            }
            return s2;
        }

        public static string Correct(string text)
        {
            string s = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (s[i] == '0')
                    s += 'O';
                else if (s[i] == '5')
                    s+= 'S';
                else if (s[i] == '1')
                    s += 'I';
                else
                    s += text[i];


            }
            return s;
        }
        public static int[] SumOfDifferences(int[]  arr)
        {
            int[] arr2 = arr;
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = i + 1; j < arr2.Length; j++)
                    if (arr2[j] > arr2[i])
                    {
                        int temp = arr2[j];
                        arr2[j] = arr2[i];
                        arr2[i] = temp;
                    }
            }
            return arr2;
        }
        public static string BooleanToString(bool b)
        {
            //Please don't delete me!
            return Convert.ToString(b);
        }
        public static string solu(string str)
        {
            string str2 = "";
            for (int i = str.Length - 1; i >= 0; i++)
                str2 += str[i];
            return str2;
        }
        
        public static void Main(string[] args)
        {
           foreach(var item in SumOfDifferences(new int[] {2,1,10}))
            {
                Console.WriteLine(item);
            }
        }
    }
}