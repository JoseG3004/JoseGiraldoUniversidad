using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionManagement
{
    public class Intopos
    {
        private Stack stack = new Stack(50); //default value to avoid overflows
        private string Output = "";

        private Dictionary<string, int> OSP = new Dictionary<string, int>()
        {
            {"**", 4},
            {"*", 2},
            {"/", 2},
            {"+", 1},
            {"-", 1},
            {"(", 4}

        };

        private Dictionary<string, int> ISP = new Dictionary<string, int>()
        {
            {"**",3 },
            {"*",2 },
            {"/",2 },
            {"+",1 },
            {"-",1 },
            {"(",0 }

        };
        public string InToPos(string expression)
        {
            foreach (char i in expression)
            {
                if (IsANum(i))
                {
                    Output += i.ToString() + " ";
                }
                else if (i.ToString() == "(")
                {
                    stack.Push(i.ToString());
                }
                else if (i.ToString() == ")")
                {
                    while (!stack.IsEmpty() && stack.Peek() != "(")
                    {
                        Output += stack.Pop() + " ";
                    }
                    stack.Pop();
                }
                else
                {
                    while (!stack.IsEmpty() &&
                           OSP[i.ToString()] >= ISP[stack.Peek()])
                    {
                        Output += stack.Pop() + " ";
                    }
                    stack.Push(i.ToString());
                }
            }

            while (!stack.IsEmpty())
            {
                Output += stack.Pop() + " ";
            }

            Console.WriteLine($"The Postfix Expression is: {Output}");
            return Output;
        }

        private bool IsANum(char i)
        {
            string eval = i.ToString();
            try
            {
                int.Parse(eval);
                return true ;
            }
            catch (FormatException)
            {
                return false;
            }
        } 
    }
}
