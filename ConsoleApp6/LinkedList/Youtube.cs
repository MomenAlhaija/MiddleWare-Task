using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Youtube
    {
        public string id { get;set; }
        public string title { get;set; }
        public TimeSpan Duration { get;set; }

        public override string ToString()
        {
            return $"├─{title} ({Duration})\n|\thttps://WWW.youtube.com/whatch?v={id}";
        }

    }
}
