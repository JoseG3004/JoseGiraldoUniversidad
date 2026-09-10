using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Intopos intopos = new Intopos();
            Evapos evapos = new Evapos();
            Console.WriteLine("Insert The Math Expression You Want To Convert\n(Numbers: 1-9 // Operator: + , - , * , / , **)\n");
            string input = Console.ReadLine();

            string result = intopos.InToPos(input);
            evapos.EvaPos(result);
        }
    }
}
