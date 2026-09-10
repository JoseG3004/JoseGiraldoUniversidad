using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionManagement
{
    public class Stack
    {
        private string[] stack;
        private int Size;
        private int Top;

        public Stack(int size)
        {
            this.Size = size;
            stack = new string[size];
            Top = -1;
        }

        public void Push(string add)
        {
            if (Top == Size - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            Top++;
            stack[Top] = add;
        }

        public string Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The Stack Is Empty");
                return "";
            }
            return stack[Top];
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The Stack Is Empty");
                return "";
            }
            string value = stack[Top];
            Top--;
            return value;
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }
    }
}
