namespace Solving
{
    
    internal class Program
    {
        public static int FindMissingNum(int[] nums) {
            int ActualResult = 0, ExpectedResult = 0;
            for(int i = 1; i <= nums.Length + 1; i++)
                ExpectedResult+= nums[i];
            foreach(int num in nums)
                ActualResult+= num; 
            return ExpectedResult - ActualResult;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(FindMissingNum(new int[] {1,2,4,5}));
            Console.WriteLine("Hello, World!");
        }
    }
}