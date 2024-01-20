using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<command> undo=new Stack<command>();   
            Stack<command> redo=new Stack<command>();
            String line;
            while (true)
            {
                Console.WriteLine("Url exit to quit:");
                line = Console.ReadLine().ToLower();
                if (line == "exit") { break; }
                else if(line == "back")
                {
                    if (undo.Count > 0)
                    {
                        var item = undo.Pop();
                        redo.Push(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if(line == "forward") {
                  
                    if(redo.Count > 0)
                    {
                        var item = redo.Pop();
                        undo.Push(item);
                    }
                    else { continue; }
                    
                }
                else
                {
                    //add url to list
                    undo.Push(new command(line));
                }
                Console.Clear();
                Print("Back", undo);
                Print("Forward", redo);
            }
         
            Console.ReadKey();  

        }
        public class command
        {
            private readonly DateTime _createdAt;
            private readonly string _url;
            public command(string url)
            {
                _createdAt = DateTime.Now;
                _url = url;
            }
            public override string ToString() {

                return $"[{this._createdAt.ToString("yyyy-MM-dd hh:mm")}]{this._url}";
            }
        }
        static void Print(string name,Stack<command> command)
        {
            Console.WriteLine($"{name} history");
            Console.BackgroundColor =name.ToLower()=="back"? ConsoleColor.DarkGreen:ConsoleColor.DarkBlue;
            foreach (var item in command)
            {
                Console.WriteLine($"\t{item}");
            }
            Console.BackgroundColor=ConsoleColor.Black;
        }
    }
}
