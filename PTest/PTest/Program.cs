using System.Xml;

namespace PTest
{
    public class Car
    {
        private string _filed;
        static Car()
        {
            
        }
        public void MakeObj()
        {
            Car c = new Car();
        }
        public string prop => _filed;
    }
    internal class Program
    {
        public static int[] RemoveDuplicateNumber(int[] nums)
        {
            
        
            List<int> list = new List<int>();
            foreach (int num in nums)  
                if(!list.Contains(num))
                    list.Add(num);
            return list.ToArray();
        }
        public static string Reverse(string s)
        {
            string s2="";
            for (int i = s.Length-1; i >= 0; i--)
                s2 += s[i];
            return s2;  
        }
        public static int[] DuplicateNumberOddRepeated(int[] nums) { 
            Dictionary<int,int> dict = new Dictionary<int,int>();
            List<int> list = new List<int>();   
            foreach (var num in nums)
                if(!dict.Keys.Contains(num))
                    dict.Add(num, 1);
                else
                    dict[num]++;
            foreach (var item in dict)
               if(item.Value % 3 == 0) 
                    list.Add(item.Key);
            return list.ToArray();
        }
        public static int[] SortArray(ref int[] nums)
        {
            int temp;
            for(int i=0; i<nums.Length; i++)
            {
                for(int j=i+1;j<nums.Length; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        temp = nums[j];
                        nums[j] = nums[i];
                        nums[i] = temp;
                    }
                }
            }
            return nums;
        }
        public static void MergeSort(int[] arr)
        {
            if(arr.Length<=1) return;
            int mid = arr.Length / 2;
            int[] left=new int[mid];
            int[] right=new int[arr.Length-mid];
            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);
            MergeSort(left);
            MergeSort(right);
            Merge(ref arr, left, right);
        }
        public static void Merge(ref int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, z = 0;
            while (i < left.Length && j < right.Length)
                arr[z++] = left[i] > right[j] ? left[i++] : right[j++];
            while (i < left.Length)
                arr[z++] = left[i++];
            while (j < right.Length)
                arr[z++] = right[j++];
        }
        static void Main(string[] args)
        {

             Console.Write(Reverse("MOMEN"));
            
        }
    }
}