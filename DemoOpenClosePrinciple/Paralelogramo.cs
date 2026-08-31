using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenClosePrinciple
{
    public class Paralelogramo : Shape
    {
        public double Base { get; set; }
        public double Altura { get; set; }

        public Paralelogramo(double baseParalelogramo, double altura)
        {
            this.Base = baseParalelogramo;
            this.Altura = altura;
        }

        public override double Area() => (this.Base * this.Altura) / 2;
    }
}
