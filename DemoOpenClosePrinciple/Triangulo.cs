using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenClosePrinciple
{
    public class Triangulo : Shape
    {
        public double Base { get; set; }
        public double Altura { get; set; }

        public override double Area() => this.Base * this.Altura;
    }
}
