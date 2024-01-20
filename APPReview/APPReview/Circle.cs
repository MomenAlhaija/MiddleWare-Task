using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPReview
{
    internal class Circle : Shape
    {
        public float R { get; set; }
        public Circle(float r)
        {
            this.R = r;
        }
        public override double CalculateArea()
        {
            return Math.PI*Math.Pow(R, 2);
        }
    }
}
