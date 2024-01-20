using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Solve
    {
        public string Reverse(string s1)
        {
           string s2 = "";
            for(int i=s1.Length-1; i>=0; i--)
            {
                s2 += s1[i];
            }
            return s2;
        }
        public int missingNumber(int[] nums)
        {
            int n=nums.Length;
            int mustSum = n*(n + 1) / 2;
            int exactlysum = 0;
            for(int i = 0; i < n-1; i++)
            {
                exactlysum += nums[i];
                    
            }
            return mustSum - exactlysum;
        }
        public int[] removeDuplicates(int[] nums)
        {
            List<int> numsWithoutDuplicate=new List<int>(); 
            for(int i=0;i<nums.Length;i++) {
                if (! numsWithoutDuplicate.Contains(nums[i])) {
                    numsWithoutDuplicate.Add(nums[i]);  
                }
            }
            return numsWithoutDuplicate.ToArray();
        }
        public bool Palindrome(string s) { 
            
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] != s[s.Length - i - 1]) 
                    return false;
            }
            return true;
        }
        public bool twoSumProblem(int[] nums,int target)
        {
            List<int> complementSet = new List<int>();

            foreach (int num in nums)
            {
                int complement = target - num;

                if (complementSet.Contains(complement))
                {
                    return true;
                }

                complementSet.Add(num);
            }

            return false;
        }
        public Dictionary<char,int> countCharacters(string s)
        {
            Dictionary<char, int> letters= new Dictionary<char, int>(); 
            foreach(char c in s)
                if (!letters.ContainsKey(c))
                    letters.Add(c, 1);
                else
                    letters[c]++;    
            return letters;
            
        }
        public int[] mergeSortedArrays(int[] nums1,int[] nums2)
        {
            int i=0, j=0,k=0;
            int[] nums3= new int[nums1.Length+nums2.Length];
            while (i<nums1.Length && j<nums2.Length)
                if (nums1[i] <= nums2[j])
                    nums3[k++] = nums1[i++];
                else
                    nums3[k++] = nums2[j++];
            if (i < nums1.Length)
                while(i<nums1.Length)
                    nums3[k++] = nums1[i++];
            else if(j< nums2.Length)
                while(j<nums2.Length) 
                    nums3[k++] = nums2[j++];
            return nums3;

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solve s = new Solve();

            foreach(var t in s.mergeSortedArrays(new int[] { 1, 3, 5 },new int[] { 2, 4, 6 }))
            {
                Console.WriteLine(t);
            }
        }
    }
}
