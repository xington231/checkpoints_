using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string infix = "3/(2*7)-5";
            Dictionary<char, int> math_signs = new Dictionary<char, int>()
            {
                
                {'+', 1},
                {'-', 1},
                {'*', 2},
                {'/', 2}
            };
            var stack = new Stack<char>();
            var output = new List<string>();

            for (int i = 0; i < infix.Length; i++)
            {
                char token = infix[i];

                if (char.IsDigit(token))
                {
                    string number = token.ToString();
                    while (i + 1 < infix.Length && char.IsDigit(infix[i + 1]))
                    {
                        i++;
                        number += infix[i];
                    }
                    output.Add(number);
                }
                else if (token == ' ')
                {
                    continue;
                }
                else if (token == '(')
                {
                    stack.Push(token);
                }
                else if (token == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        output.Add(stack.Pop().ToString());
                    }
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Неправильно поставлены скобки");
                        return;
                    }
                    stack.Pop();
                }
                else if (math_signs.ContainsKey(token))
                {
                    while (stack.Count > 0 && math_signs.ContainsKey(stack.Peek()) &&
                           math_signs[stack.Peek()] >= math_signs[token])
                    {
                        output.Add(stack.Pop().ToString());
                    }
                    stack.Push(token);
                }
                else
                {
                    Console.WriteLine("Недопустимый символ!");
                    return;
                }
            }

            while (stack.Count > 0)
            {
                char op = stack.Pop();
                if (op == '(' || op == ')')
                {
                    Console.WriteLine("Неправильно поставлены скобки");
                    return;
                }
                output.Add(op.ToString());
            }

            Console.WriteLine(string.Join(" ", output));



        }
    }
}
