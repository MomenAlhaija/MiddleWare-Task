using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MyProblems;

namespace MyProblems
{      
    public class B
    {

        public int Sum(int a, int b) => a + b;
    }
    public class B2 : B
    {
        public new int Sum(int a, int b) => a * b;

    }
    public  class Solve 
    {

        public Solve(int a) 
        {

        }
        
        public string uncensor(string str1, string str2)
        {
            string str3 = "";
            int index = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '*')
                    str3 += str2[index++];
                else
                    str3 += str1[i];
            }
            return str3;
        }
        public byte[] ConvertToHex(string str)
        {
            int i = 0;
            List<byte> list = new List<byte>();
            foreach (char c in str)
            {
                list.Add(Convert.ToByte(char.ToUpper(c)));
            }
            return list.ToArray();
        }
        public int[] TrackRobot(string[] str)
        {
            int vertical = 0, horizontal = 0;
            foreach (string s in str)
            {
                string value = s.Split(' ')[1];
                if (s.StartsWith("right"))
                    horizontal += int.Parse(value);
                else if (s.StartsWith("left"))
                    horizontal -= int.Parse(value);
                else if (s.StartsWith("up"))
                    vertical += int.Parse(value);
                else if (s.StartsWith("down"))
                    vertical -= int.Parse(value);
            }
            int[] arr = new int[] { vertical, horizontal };
            return arr;
        }
        public void ReverseOdd(string str)
        {
            string[] strs2 = str.Split(' ').ToArray();
            foreach (string s in strs2)
            {
                if (s.Length % 2 != 0)
                    for (int i = s.Length - 1; i >= 0; i--)
                        Console.Write(s[i]);
                else
                    Console.Write(s);

                Console.Write(" ");
            }
        }
        public int reversedBinaryInteger(int num)
        {
            List<Int16> bools = new List<Int16>();
            int i = 0;
            int sum = 0;

            while (num > 0)
            {
                if (num % (int)Math.Pow(2, i) == 0)
                {
                    num -= (int)Math.Pow(2, i);
                    bools.Add(1);
                }
                else
                {
                    bools.Add(0);
                }

                i++;
            }

            Int16[] arr = bools.ToArray();
            for (int y = arr.Length - 1; y >= 0; y--)
            {
                if (arr[y] != 0)
                    sum += (int)Math.Pow(2, arr.Length - 1 - y);
            }

            return sum;
        }
        public static int[] MinMissPos(int[] nums)
        {
            int[] arr = new int[nums.Length];
            Array.Copy(nums, arr, nums.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = min;
                arr[minIndex] = temp;
            }

            return arr;
        }
    }
}

namespace Problems
{
    internal class Problem
    {
        static void Main(string[] args)
        {
            B2 b=new B2();
            Console.WriteLine(b.Sum(2, 5));
        }
    }
}
