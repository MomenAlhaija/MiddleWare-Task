using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPReview
{
    internal class Rectangle : Shape
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public override double CalculateArea()
        {
            return Length*Width;
        }
        public Rectangle(float l,float w)
        {
            this.Length = l;
            this.Width = w;
        }
    }
}
