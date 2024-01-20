using ConsoleApp19.Enums;

namespace ConsoleApp19
{
    public class Program
    {
        public static int[] GetNonDuplicatedNumbers(int[] arr1) { 
            Dictionary<int,int> keyValuePairs = new Dictionary<int,int>();
            int[] z = new int[arr1.Length];
            int j = 0;
            foreach (int i in arr1)
                keyValuePairs[i] = keyValuePairs.ContainsKey(i) ? keyValuePairs[i] + 1 : 1;
            foreach (var keyValue in keyValuePairs.Keys)
                if (keyValuePairs[keyValue] == 1)
                    z[j++] = keyValue;
            return z.Take(j).ToArray();
        }
        public static string FindLongestPalindromeWord(string word)
        {
            string palindromeWord = "";
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] == word[word.Length - i - 1])
                    palindromeWord += word[i];
                else
                    break;
            }
            return palindromeWord;
        }

        public static bool isEven(int num)=>num%2==0;
        static void Main(string[] args)
        {
            int[] arr=new int[] {1,2,2,3,4,5,6,7,3,7,5,4,8,2};
            foreach(int i in GetNonDuplicatedNumbers(arr))
                Console.WriteLine(i);
            Console.WriteLine(FindLongestPalindromeWord("kayak"));
        }
    }
}