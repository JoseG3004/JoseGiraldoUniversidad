using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionManagement
{
    public class Evapos
    {
        private Stack stack = new Stack(50);
        private string output = "";

        public void EvaPos(string expression)
        {
            foreach (char i in expression)
            {
                if (i == ' ') continue;

                if (IsANum(i))
                {
                    stack.Push(i.ToString());
                }
                else
                {
                    string a = stack.Pop();
                    string b = stack.Pop();
                    Evaloperator(i.ToString(), b, a);
                }
            }
            int result = int.Parse(stack.Pop());
            Console.WriteLine($"The Result was: {result}");
        }

        private bool IsANum(char i)
        {
            string eval = i.ToString();
            try
            {
                int.Parse(eval);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void Evaloperator(string i,string a, string b)
        {
            switch (i)
            {
                case "*":
                    stack.Push((int.Parse(a) * int.Parse(b)).ToString());
                    break;

                case "/":
                    stack.Push((int.Parse(a) / int.Parse(b)).ToString());
                    break;

                case "-":
                    stack.Push((int.Parse(a) - int.Parse(b)).ToString());
                    break;

                case "+":
                    stack.Push((int.Parse(a) + int.Parse(b)).ToString());
                    break;

                case "**":
                    stack.Push(Math.Pow(int.Parse(a), int.Parse(b)).ToString());
                    break;
            }
        }
    }
}
