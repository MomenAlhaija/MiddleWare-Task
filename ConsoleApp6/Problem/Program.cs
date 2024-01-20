using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Dictionary<int, List<string>> YoungPepole = new Dictionary<int, List<string>>();
            //List<person> persons = new List<person>()
            //{
            //    new person() {Name="Momen",Age=23},
            //    new person() {Name="Mohammad",Age=18},
            //    new person(){Name="Jawad",Age=12},
            //    new person(){Name="Omar",Age= 13},
            //    new person(){Name="Karam",Age=11},
            //    new person(){Name="Zena",Age=10}
            //};
            //foreach (var person in persons)
            //{
            //    if (person.Age < 18)
            //    {
            //        if (!YoungPepole.Keys.Contains(person.Age))
            //        {
            //            YoungPepole.Add(person.Age, new List<string> { person.Name });
            //        }
            //        else
            //        {
            //            YoungPepole[person.Age].Add(person.Name);
            //        }
            //    }
            //}
            //foreach (var item in YoungPepole)
            //{
            //    Console.Write($"[{item.Key}]");
            //    foreach (var person in item.Value)
            //    {
            //        Console.WriteLine($"{person}");
            //    }

            //Dictionary<string,float> Comp=new Dictionary<string,float>();
            //List<Compaines> compaines = new List<Compaines>()
            //{
            //    new Compaines() {Name="Momen",stockprice=2300},
            //    new Compaines() {Name="Mohammad",stockprice=18000},
            //    new Compaines(){Name="Jawad",stockprice=1020},
            //    new Compaines(){Name="Omar",stockprice= 1130},
            //    new Compaines(){Name="Karam",stockprice=1201},
            //    new Compaines(){Name="Zena",stockprice=1780}
            //};
            //Compaines compMAx =new Compaines();
            //int x = 0;
            //foreach (var comp in compaines)
            //{
            //    if (x == 0)
            //    {
            //        compMAx = compaines[x];
            //    }
            //    else
            //    {
            //        if(comp.stockprice>compMAx.stockprice)
            //        {
            //            compMAx = comp;
            //        }
            //    }
            //    x++;
            //}
            //Comp.Add(compMAx.Name, compMAx.stockprice);
            //Console.WriteLine(compMAx.Name);
            //Console.WriteLine(compMAx.stockprice);

            //Dictionary<char,int> letterCount=new Dictionary<char,int>();
            //string word = "bility to develop and run on Windows, macOS, and Linux";
            //foreach(char c in word)
            //{
            //    if (!letterCount.ContainsKey(c))
            //    {
            //        letterCount.Add(c, 1);
            //    }
            //    else
            //    {
            //        letterCount[c]++;   
            //    }
            //}
            //foreach(var c in letterCount) {
            //    if (!( c.Value % 2 == 0))
            //    {
            //        Console.WriteLine($"[{c.Key}]=>count:{c.Value}");
            //    }
            //}
            //List<student> students = new List<student>()
            //{
            //        new student(){Name="Momen",grade=20},
            //        new student(){Name="Mohammad",grade=18},
            //        new student(){Name="Jawad",grade=12},
            //        new student(){Name="Omar",grade= 15},
            //        new student(){Name="Karam",grade=12},
            //        new student(){Name="Zena",grade=17},
            //        new student(){Name="Momen",grade=18},
            //        new student(){Name="Mohammad",grade=19},
            //        new student(){Name="Jawad",grade=17},
            //        new student(){Name="Omar",grade= 10},
            //        new student(){Name="Karam",grade=15},
            //        new student(){Name="Zena",grade=12},
            //        new student(){Name="Momen",grade=10},
            //        new student(){Name="Mohammad",grade=19},
            //        new student(){Name="Jawad",grade=11},
            //        new student(){Name="Omar",grade= 10},
            //        new student(){Name="Karam",grade=18},
            //        new student(){Name="Zena",grade=20},

            //};
            //Dictionary<string, List<int>> grade = new Dictionary<string, List<int>>();
            //foreach(var name in students)
            //{
            //    if (!grade.Keys.Contains(name.Name))
            //    {
            //        grade.Add(name.Name, new List<int>() { name.grade});
            //    }
            //    else
            //    {
            //        grade[name.Name].Add(name.grade);
            //    }
            //}
            //int count = 0;
            //float avg = 0;
            //foreach(var student in grade)
            //{

            //    Console.WriteLine($"Student\t{student.Key}");
            //    foreach(int grad in student.Value)
            //    {
            //        count += grad;
            //    }
            //    avg=count/student.Value.Count;
            //    Console.WriteLine($"GPA\t{avg}");
            //    count = 0;
            //}
            foreach (var arg in reverse("Momen")) { 
                Console.WriteLine(arg);
            }
        }
       
        static List<int> PowerRanger(int pow,int start,int end) {
        
           List<int> result = new List<int>();

            for(int i = 0; i <= end; i++)
            {
                if(Math.Pow(i, pow) >= start && Math.Pow(i, pow) <= end)
                {
                    result.Add(i);
                }

            }
            return result;
        }
        static Stack<char> reverse(string str)
        {
            Stack<char> s = new Stack<char>();
            Stack<char> r = new Stack<char>();  
            foreach(char c in str)
            {
                s.Push(c);
            }
            while (s.Count > 0)

            {
                var y=s.Pop();
                r.Push(y);
            }
            s.Clear();
            return r;
        }
        static string Interview(int[] nums,int limit)
        {
            int sum = 0;
            if (nums.Length < 8) return "disqualified";
            else
            {
                if (nums[0] > 5 || nums[1] > 5)
                    return "disqualified";
                else if (nums[2] > 10 || nums[2] > 10)
                    return "disqualified";
                else if (nums[4] > 15 || nums[5] > 15)
                    return "disqualified";
                else if (nums[6] > 20 || nums[7] > 20)
                    return "disqualified";
                else if (limit > 120) 
                    return "disqualified";
                else 
                    return "qualified";
            }
        }
        static bool IsSmooth(string s) {

            List<string> l = s.Split(' ').ToList();
            char[] i= l[0].ToArray();
            char[] i2 = l[1].ToArray();
            if (i[i.Length - 1] == i2[0])
                return true;

            return false;
        }
        static List<int> RemoveDuplicates(List<int> l)
        {
            List<int> nums= new List<int>();
            foreach(int i in l)
            {
                if (!nums.Contains(i)) { 
                    nums .Add(i);
                }
            }
            return nums;
        }
        static bool Anagram(string str1,string str2)
        {
            List<char> l1 = new List<char>();
            List<char> l2 = new List<char>();
            foreach (var item in str1)
            {
                if(!l1.Contains(item)) l1.Add(item);
            }
            foreach (var item in str2)
            {
                if (!l2.Contains(item)) l2.Add(item);
            }
            bool flaq = false;
            foreach(var item in l1)
            {
                if (!l2.Contains(item)) { flaq=false; break; }   
            }
            return flaq;
        }
        static int[] Merge(int[] str1,int[] str2)
        {
            List<int> list = new List<int>();
            foreach(var item in str1)
            {
                list.Add(item);
            }
            foreach(var item in str2)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }
        static bool Palindrome(string s1)
        {
            string s="";
            for(int i=s1.Length-1; i>=0; --i)
            {
                s +=Convert.ToChar(s1[i]);
            }
           
            return s== s1;
        }
        static string HighLow(string str)
        {
            int[] arr = new int[str.Split(' ').Count()];
            for(int i=0; i<arr.Length; i++)
            {
                arr[i] = int.Parse(str.Split(' ')[i]);

            }
            int max, min; max = min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                else if (arr[i] < min)
                {
                    min = arr[i];
                }

            }
            string s = $"{max} {min}";
            return s;
        }
        static int[] CountPosSumNeg(int[] nums)
        {
            int nunnev = 0;
            int count = 0;
            foreach (int num in nums)
            {
                if (num < 0)
                {
                    
                    count+=num;
                }
                else
                {
                    nunnev++;
                }
                

            }
            return new int[] { nunnev, count };
        }
        static string ReverseCase(string input)
        {
            string s = "";
            foreach (var item in input.Split(' ')) {
                    
                foreach (var c in item) {
                    if(char.IsUpper(c))
                    {
                        s += char.ToLower(c);
                    }
                    else
                    {
                        s += char.ToUpper(c);
                    }
                }
                s += ' ';
            }
            return s;
        }
        static List<int> IndexOfCapitals(string str) {
        
            List<int> list = new List<int>();
            for(int i=0; i<str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public class person
        {
            public string Name;
            public int Age;


        };
        public class Compaines
        {
            public string Name;
            public float stockprice;
        };
        public class student
        {
            public string Name;
            public int grade;
        };
        static Dictionary<string, int> TrackRobot(string[] str) {
        
            Dictionary<string,int> keyValuePairs = new Dictionary<string,int>(); 
            foreach(string key in str)
            {
                if (!keyValuePairs.ContainsKey(key))
                {
                    keyValuePairs.Add(key.Split(' ')[0], int.Parse(key.Split(' ')[1]));
                }
                else
                {
                    keyValuePairs[key.Split(' ')[0]] +=int.Parse(key.Split(' ')[1]);
                }
            }
            return keyValuePairs;
        } 
    }
}
