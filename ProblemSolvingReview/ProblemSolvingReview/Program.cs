using System.Collections;

int[] FindNum(int[] num,int target) {
    
    Hashtable hashtable = new Hashtable();
    for (int i = 0; i < num.Length; i++)
    {
        int complement = target - num[i];
        if (hashtable.ContainsKey(complement))
            return new int[] { complement,i };
        hashtable.Add(complement, num[i]);  
    }
    return new int[] { -1, -1 };
}
string ReverseString( string str)
{
    string str2 = "";
    for(int i=0; i < str.Length; i++)
        str2 += str[str.Length-1-i];
    return str2;
}
bool IsPalindrome(string str)
{
    for(int i= 0; i < str.Length;i++)
        if (str[i] != str[str.Length-i-1])
            return false;
    return true;
}
int FindMaximum(int[] num)
{
    int max = num[0];
    foreach(int i in num)
        if(i > max)
            max = i;
    return max;
}
int[] RemoveDuplicates(int[] arr)
{
    List<int> NumsWithoutDuplicate = new List<int>();
    for(int i=0;i<arr.Length;i++)
        if (!NumsWithoutDuplicate.Contains(arr[i]))
            NumsWithoutDuplicate.Add(arr[i]);
    return NumsWithoutDuplicate.ToArray();
}
int MissingNumber(int[] nums)
{
    int n= nums[nums.Length-1];
    int VirtualSum = (n * (n + 1)) / 2;
    int ActualSum = 0;
    foreach (int i in nums)
        ActualSum += i;
    return VirtualSum - ActualSum;
}
int Factorial(int n)
{
    if (n == 0) return 1;
    else if (n == 1 || n == 2) return n;
    return n* Factorial(n-1);
}
bool Anagram(string str1,string str2)
{
    if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
        return false;
    else
    {
        bool ang1 = true, ang2 = true;
        foreach (char c in str1)
            if (!str2.Contains(c))
                ang1 = false;
        foreach (char c in str2)
            if (!str1.Contains(c))
                ang2 = false;
        return ang1 && ang2;
    }
}
int[] MergeTwoArrays(int[] num1, int[] num2)
{
    int[] arr = new int[num1.Length + num2.Length];
    int i = 0, j = 0, z = 0;

    while (i < num1.Length && j < num2.Length) 
    {
        if (num1[i] < num2[j])
        {
            arr[z] = num1[i];
            i++;
        }
        else
        {
            arr[z] = num2[j];
            j++;
        }
        z++;
    }

    while (i < num1.Length)
    {
        arr[z] = num1[i];
        i++; z++;
    }

    while (j < num2.Length)
    {
        arr[z] = num2[j];
        z++; j++;
    }

    return arr;
}
int FindSecondLarget(int[] arr)
{
    int larget , secondLarget;
    larget = secondLarget = arr[0];
    for(int i=0;i<arr.Length; i++)
    {
        if (arr[i] > larget)
        {
            secondLarget = larget;

            larget = arr[i];
        }
        else if (arr[i] > secondLarget && arr[i] != larget)
        {
            secondLarget = arr[i];
        }
    }
    return secondLarget;
}
bool IsPrimeNumber(int n)
{
    if (n < 2) return false;
    for(int i = 2; i < Math.Sqrt(n); i++)
        if (n % i == 0) return false;
    return true;
}
Dictionary<char,int> CountCharacters(string str)
{
    Dictionary<char,int> repeatCharacter= new Dictionary<char,int>();
    foreach(char c in str)
    {
        if (!repeatCharacter.ContainsKey(c)) 
            repeatCharacter.Add(c, 1);
        repeatCharacter[c]++;
    }
    return repeatCharacter;
}