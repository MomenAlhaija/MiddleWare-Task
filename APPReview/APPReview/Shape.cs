using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace APPReview
{
    internal  abstract class Shape
    {
       public abstract double CalculateArea();

        public double PrintArea(Shape shape)
        {
           return shape.CalculateArea();
        }
    }
}
