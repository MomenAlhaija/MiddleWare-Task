using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        public static bool isLastCharacterN(string s)
        {
            return s[s.Length - 1] == 'n';
        }
        public static bool oddOrEven(string s)
        {
            return s.Length % 2 == 0;
        }
        public static int Diff(int[] arr)
        {
            int min, max;
            min = max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }


                if (arr[i] > max) {
                    max = arr[i];
                }

            }
            return max - min;
        }
        public static bool EqualSlices(int total_slices, int no_recipients, int slices_each)
        {
            return no_recipients * slices_each <= total_slices;
        }
        enum Months
        {
            January =1,
	        February,
	        March,
	        April,
	        May,
	        June,
	        July,
	        August,
	        September,
	        October,
	        November,
	        December
        }
        public static int CountVowels(string s)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(char.ToLower(s[i])))
                    count++;
            }
            return count;
        }
        public static bool SameCase(string s) {

            if (char.IsUpper(s[0]))
            {
                for(int i = 1; i < s.Length; i++)
                {
                    if(!char.IsUpper(s[i]))
                    {
                        return false;
                    }    
                }
                return true;

            }
            else
            {
                for (int i = 1; i < s.Length; i++)
                {
                    if (!char.IsLower(s[i]))
                    {
                        return false;
                    }
                }
                return true;

            }

        }
        public static string NameShuffle(string s)
        {
            string[] s2=s.Split(' ').ToArray();
            string temp = s2[0];
            s2[0] = s2[1];
            s2[1] = temp;
            return string.Concat(s2[0]," ", s2[1]);
        }
        public static int Factorial(int n)
        {
            if(n<=2)
                return n;
            else 
                return n* Factorial(n-1);
        }
        public static bool isIdentical(string s)
        {
           char f= s[0];
            for(int j=1; j<s.Length; j++)
            {
                if (s[j] != s[0])
                {
                    return false;
                }
            }
            return true;
        }
        public static string FizzBuzz(int num)
        {
            if (num % 3 == 0 || num % 5 == 0)
            {
                string s = "";

                if (num % 3 == 0)
                    s += "Fizz";
                if (num % 5 == 0)
                    s += "Buzz";
                return s;
            }
            else
            {
                return num.ToString();
            }
        }
        public static bool DoubleLetters(string s)
        {
            Dictionary<char,int > CountLetters = new Dictionary<char,int>();
            for(int i=0; i<s.Length; i++)
            {
                if (!CountLetters.Keys.Contains(s[i]))
                {
                    CountLetters.Add(s[i],1);
                }
                else
                {
                    CountLetters[s[i]]++;
                }
            }
            for(int i = 0; i < CountLetters.Count; i++)
            {
                if (CountLetters[s[i]] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static int CountDs(string s)
        {
            int count = 0; 
            for(int i = 0; i < s.Length; i++)
            {
                if (char.ToUpper(s[0]) == 'D')
                {
                    count++;
                }
            }
            return count;
        }
        public static int[] ArrayOfMultiples(int number,int mult)
        {
            List<int> res = new List<int>();
            for(int i = 1; i <= mult; i++)
            {
                res.Add(number*i);
            }
            return res.ToArray();
        }
        public static int[] IndexOfCapitals(string s)
        {
            List<int> a= new List<int>();
            for(int i=0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                    a.Add(i);
            } 
            return a.ToArray();
        }
        public static int CountOnes(int BinaryNumber)
        {
            int DecimalNumber = 0;
            string binaryString = BinaryNumber.ToString();
            for (int i = 0; i < binaryString.Length; i++)
            {
                int binaryDigit = binaryString[i] - '0';
                DecimalNumber += binaryDigit * (int)Math.Pow(2, binaryString.Length - 1 - i);
            }
            return DecimalNumber;
        }
        public static bool IsSymmetrical(int num)
        {
            string nums = num.ToString();
            int MidIndex=(int) (num.ToString().Length)/2;
            
            for(int i = 0;i < MidIndex;i++)
            {
                if (nums[i] != nums[num.ToString().Length - i-1])
                    return false;

            }
            return true;    
            
        }
        public static bool Palindrome(int num)
        {
            string snum= num.ToString();
            for(int i = 0; i < snum.Length; i++)
            {
                if (snum[i] != snum[snum.Length-i-1])
                    return false;
            }
            return true;
        }
        public static bool Anagrams(string s1,string s2)
        {
            for(int i=0;i< s1.Length; i++)
            {
                if (!s2.Contains(s1[i]))
                    return false;   
            }
            return true;
        }
        public static int[] Duplicate_Numbers(int[] nums)
        {
            List<int> arr = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            // Count the occurrences of each number in the array
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], 1);
                }
                else
                {
                    dic[nums[i]]++;
                }
            }

            // Find the duplicated numbers
            foreach (var kvp in dic)
            {
                if (kvp.Value > 1)
                {
                    arr.Add(kvp.Key);
                }
            }

            return arr.ToArray();
        }
        public static char First_NonRepeated(string s2)
        {
           string s=s2.ToLower();
            Dictionary<char,int> dic=new Dictionary<char,int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (!dic.Keys.Contains(s[i]))
                {
                    dic.Add(s[i], 1);
                }
                else
                {
                    dic[s[i]]++;
                }
            }
            for(int i=0; i < dic.Count; i++)
            {
                if (dic[s[i]] == 1)
                {
                    return s[i];
                }
            }    
            return '\0';
        }
        public static int LargetsNumber(int[] nums)
        {
            int max = nums[0];
            for(int i=1; i<nums.Length; i++)  if (nums[i] > max) max = nums[i];
            return max; 
        }
        public static string ReverseString(string str)
        {
            string str2 = "";
            for(int i=str.Length-1; i>=0; i--)
            {
                str2 += str[i];
            }
            return str2;
        }
        public static int Fabonaci(int num)
        {
            if (num < 2)
            {
                return num;
            }
            return Fabonaci(num-1)+ Fabonaci(num-2);
        }
        public static void CountingDuplicates(int[] nums)
        {

            Dictionary<int,int> di = new Dictionary<int,int>();
            for(int i=0;i<nums.Length ; i++)
            {
                if (!di.Keys.Contains(nums[i]))
                {
                    di.Add(nums[i], 1);
                }
                else
                {
                    di[nums[i]]++;
                }
            }
            foreach(var i in di)
            {
                Console.WriteLine($"Number {i.Key} repeat {i.Value}");
            }
        }
        public static int[] Sorting(int[] nums)
        {
            for(int i=0;i<nums.Length ; i++)
            {
                for(int j=i+1;j<nums.Length ; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        int temp = nums[j];
                        nums[j] = nums[i];
                        nums[i] = temp;
                    }
                }
            }
            return nums;
        }
        static void Main(string[] args)
        {
            CountingDuplicates(new int[] {1,2,1,2,3,4,5,6,7,1,2,3,4,7,1,2,3});
            foreach(var item in Sorting(new int[] {5,8,2,4,3,2,15,7,9,1,10}))
            {
                Console.WriteLine(item);
            }
        }
    }
}
