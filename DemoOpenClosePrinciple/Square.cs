using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenClosePrinciple
{
    public class Square:Shape
    {
        public double Size {  get; set; }

        public override double Area() => (this.Size*this.Size);

    }
}
