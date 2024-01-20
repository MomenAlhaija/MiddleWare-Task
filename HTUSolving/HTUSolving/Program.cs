namespace HTUSolving
{
    class Car
    {
        private string[] _cars;
        public Car(string[] cars)
        {
            _cars= cars;
        }
        public IEnumerable<string> GetCars()
        {
            foreach(var car in _cars)
            {
              yield return car;
            }
        }
    }
    internal class Program
    {
        public static int[] FindSummations(int[] nums,int target)
        {
            int[] ints = new int[2];
            int j = 0;
            foreach (int i in nums)
            {
                if (nums.Contains(target - nums[i]))
                {
                    ints[j++] = nums[i];
                    ints[j++] = target - nums[i];
                    break;
                }
            }
            return ints;    
        }

        static void Main(string[] args)
        {
            Car c = new Car(new string[] { "XD", "BWM", "KIA" });
            c.GetCars();
            foreach (var i in FindSummations(new int[] { 1, 2, 5, 7, 8, 9, 10, 11, 12, }, 14)) 
                Console.WriteLine(i);
        }
    }
}