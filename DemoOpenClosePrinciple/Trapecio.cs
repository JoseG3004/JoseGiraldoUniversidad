using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenClosePrinciple
{
    public class Trapecio : Shape
    {
        public double BaseMayor { get; set; }
        public double BaseMenor { get; set; }
        public double Altura { get; set; }

        public Trapecio(double baseMayor, double baseMenor, double altura)
        {
            this.BaseMayor = baseMayor;
            this.BaseMenor = baseMenor;
            this.Altura = altura;
        }

        public override double Area() =>
            ((this.BaseMayor + this.BaseMenor) * this.Altura) / 2;
    }
}
