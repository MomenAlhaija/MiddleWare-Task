using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class Solve
{
    public int[] Match()
    {
        int StrSize = Int32.Parse(Console.ReadLine().Trim());
        List<string> Strings = new List<string>();
        for (int i = 0; i < StrSize; i++)
        {
            string item = Console.ReadLine();
            Strings.Add(item);
        }
        int GurSize = Int32.Parse(Console.ReadLine().Trim());
        List<string> Quers = new List<string>();
        for (int i = 0; i < GurSize; i++)
        {
            string item = Console.ReadLine();
            Quers.Add(item);

        }
        List<int> ints = new List<int>();
        for (int i = 0; i < StrSize; i++)
        {
            int count = 0;
            for (int j = 0; j < GurSize; j++)
            {
                if (Strings[i] == Quers[j])
                    count++;
            }
            ints.Add(count);
        }
        return ints.ToArray();
    }

    public bool Palindrome(string s) {
     
        for(int i=0; i<s.Length; i++)
            if (s[i] != s[s.Length-1-i])
                return false;
        return true;
    }
    public bool Palindrome(int n)
    {
        string s=n.ToString();
        for (int i = 0; i < s.Length; i++)
            if (s[i] != s[s.Length - 1 - i])
                return false;
        return true;
    }
    public bool TwoSum(int[] nums,int target)
    {
        List<int> list = new List<int> ();
        int count = 0;
        foreach(int num in nums)
        {
            count = target - num;
            if (list.Contains(count))
                return true;
            list.Add(num);
        }
        return false;
    }
    public int[] Merge(int[] arr1,int[] arr2) {
        int[] arr3= new int[arr1.Length+arr2.Length];
        int i = 0,j= 0,k=0;
        while (i<arr1.Length&&j<arr2.Length)
        {
            if (arr1[i] <= arr2[j])
            {
                arr3[k] = arr1[i];
                i++;
            }
            else { 
                arr3[k] = arr2[j];
                j++; 
            }
            k++; 
        }
        while(i<arr1.Length)
        {
            arr3[k]= arr1[i];
            i++;k++;
        }
        while (j < arr2.Length)
        {
            arr3[k] = arr2[j];
            j++;k++;
        }

        return arr3;
    
    }
}

namespace ConsoleApp10
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Solve solve = new Solve();
            Console.WriteLine(solve.TwoSum(new int[] { 1, 2, 5, 4, 8, 9 }, 15));
            foreach(int num in solve.Merge(new int[] { 1,2,3,4,15},new int[] { 3, 10, 12, 13, 20, 22 }))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine(solve.Palindrome(254));

            foreach (var item in solve.Match())
            {
                Console.WriteLine(item);   
            }
        }
    }
}
