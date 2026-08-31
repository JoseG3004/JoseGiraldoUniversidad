using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenClosePrinciple
{
    public class AreaCalculator
    {

        public double TotalArea(List<Shape> shapes) => shapes.Sum(item => item.Area());
       
            /*
        {
            double sumatoria = 0;
            foreach (Shape shape in shapes)
            {
                sumatoria += shape.Area();
            }

            return sumatoria;
        }
            */
       

    }
}
