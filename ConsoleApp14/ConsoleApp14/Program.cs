using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp142
{

    public class Solving
    {

        public string Reverse(string str)
        {
            string str2="";
            for(int i=str.Length-1; i>=0; i--)
            {
                str2 += str[i];
            }
            return str2;    
        }
        public int[] RemoveDuplicated(int[] nums)
        {
            List<int> Numbers_withoutDuplicate_List = new List<int>();
            for(int i=0; i<nums.Length; i++)
            {
                if (!Numbers_withoutDuplicate_List.Contains(nums[i]))
                {
                    Numbers_withoutDuplicate_List.Add(nums[i]);
                }
            }
            return Numbers_withoutDuplicate_List.ToArray();
        }
        public int[] IndexOfCapitals(string str)
        {
            List<int> Numbers_Index = new List<int>();
            for(int i=0;i<str.Length ; i++) {

                if (char.IsUpper(str[i]))
                {
                    Numbers_Index.Add(i);
                }
            }
            return Numbers_Index.ToArray();
        }
        public string GetMiddle(string str)
        {
            string str2 = "";
            int n = (int)str.Length / 2;
            if (str.Length % 2 == 0)
            {
                for (int i = n - 1; i >= n + 1; i++)
                {                
                    str2 += str[i];
                }
                return str2;
            }
            return str2 = str[n].ToString();
        }
        public int[] CountPosSumNeg(int[] nums)
        {
            int[] Count_Sum = new int[2];
            int count = 0,
            sum = 0;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] >= 0)
                    count++;
                else
                    sum += nums[i];
            Count_Sum[0] = count;
            Count_Sum[1]= sum;
            return Count_Sum;
        }
        public bool AlmostPalindrome(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] != str[str.Length - 1 - i])
                     count++;
                else
                    return false;
            return count <= 1;
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> result = new Dictionary<int, int>(); 
            for(int i=0;i<nums.Length; i++)
            {
                int complement = target - nums[i];
                if (result.Keys.Contains(complement))
                    return new int[] { result[complement], i };
                result.Add(nums[i], i);
            }
            return new int[] { -1, -1 };
        }
        public static int RemoveDuplicates(int[] nums)
        {
            List<int> result = new List<int>();
            for(int i=0 ; i<nums.Length ; i++)
                if (!result.Contains(nums[i]))
                    result.Add(nums[i]);
            int count=result.Count;
            return count;
        }
        public bool IsAnagram(string str1,string str2)
        {
            int[] result = new int[26];
            if(str1.Length!=str2.Length) return false;  
            for(int i=0;i<str1.Length ; i++)
            {
                result[str1[i] - 'a']++;
                result[str2[i] - 'a']--;
            }
            foreach (int item in result)
            {
                if(item!=0) return false;
            }
            return true;
        }
        public int MissingNumber(int[] nums)
        {
            int n=nums.Length+1;
            int MustSum = (n) * (n + 1) / 2;
            int ActualSum = 0;
            for(int i=0;i<nums.Length ; i++)
            {
                ActualSum+= nums[i];    
            }
           return MustSum-ActualSum;

        }

        public int[] MergeTwoArray(int[] arr1, int[] arr2)
        {
            int[] arr3 = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] <= arr2[j])
                {
                    arr3[k++] = arr1[i++];
                }
                else
                {
                    arr3[k++] = arr2[j++];
                }
            }

            while (i < arr1.Length)
            {
                arr3[k++] = arr1[i++];
            }

            while (j < arr2.Length)
            {
                arr3[k++] = arr2[j++];
            }

            return arr3;
        }

         public string Reverse_Words(string str)
        {
            string[] strs=str.Split(' ').ToArray();
            string str2 = "";
            foreach (string s in strs)
            {
                str2 += s;
            }
            return str2;
        }

        public string Longest_Common_Prefix(string[] strs)
        {
            string prefx = strs[0];
            for(int i = 1;i< strs.Length; i++)
            {
                while (!strs[i].StartsWith(prefx))
                {
                    prefx = strs[i].Substring(0,strs[i].Length-1);
                }
            }
            return prefx;
        }
        public int MaximumProduct(int[] nums)
        {
            int products = 0;
            for(int i=0;i< nums.Length;i++)
                for(int j=i+1;j< nums.Length;j++)
                    if (nums[i] * nums[j] > products)
                        products = nums[i]*nums[j];
            return products;
        }

        public int CountVowels(string str)
        {
            int count=0;
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'u', 'o' };
            for(int i=0;i<str.Length;i++)
                if (vowels.Contains(char.ToLower(str[i])))
                    count++;    
            return count;
        }
    }

    public class test1
    {
        public int sum(int x,int y)
        {
            return x + y;
        }
    }
    public class test2 : test1
    {
        public double sum(int x, int y)
        {
            return x + y;
        }
    }
    internal class Program
    {
        static void Main(string[] args) {
        
             test2 test = new test2();
            Console.WriteLine(test.sum(1, 2));

           
        }

    }
}
