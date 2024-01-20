using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPReview
{
    internal class Box<T> where T : class
    {
        public T GetItem()
        {
            return default(T);   
        }
    }
}
