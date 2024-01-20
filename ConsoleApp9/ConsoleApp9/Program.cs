using System;
using System.Collections.Generic;
using System.Linq;

class Solve{
    public string Reverse(string str)
    {
        string str2 = "";
        for(int i=str.Length-1; i>=0; i--)
        {
            str2 += str[i];
        }
        return str2;
    }
    public bool Palindrome(string str1,string str2) {
        if (str1.Length == str2.Length) {
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[str2.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    public bool Sum(int[] arr,int target)
    {
        for(int i=0; i < arr.Length; i++)
            for(int j=i+1;j< arr.Length; j++)
                if (arr[i] + arr[j]>=target)
                    return true;
        return false;
    }

    public int Found(int[] arr)
    {
        int min=arr[0];
        int max=arr[0];

        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= max)
            {
                max = arr[i];
            }
            if (arr[i] <= min)
            {
                min = arr[i];
            }
        }
        for(int j=min; j<=max; j++)
        {
            if (!arr.Contains(j))
                return j;
        }
        return -1;
    }
    public bool Anagrams(string str1,string str2)
    {
       if(str1.Length!=str2.Length)
            return false;
        int[] newchar = new int[26];
        for (int i = 0; i < str1.Length; i++)
            newchar[str1[i] - 'a']++;
        for (int j = 0; j < str2.Length; j++)
            newchar[str2[j] - 'a']--;
        for(int i = 0; i < 26; i++)
        {

            if (newchar[i]!=0)
                return false;
        }
        return true;
    }
}

public class MergeNames
{
   
    public static void Main(string[] args)
    {
        Solve s = new Solve();
     Console.WriteLine(s.Reverse("hello"));
        Console.WriteLine(s.Palindrome("Momen", "nemom"));
        Console.WriteLine(s.Found(new int[] {1,4,5,3}));
    }
    
    
}
