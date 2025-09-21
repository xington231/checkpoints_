using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
        static int MathOperations(int num1, int num2, Operation op)
        {
            switch (op) {
                case Operation.Add:
                    return num1 + num2;
                case Operation.Subtract:
                    return num1 - num2;
                case Operation.Multiply:
                    return num1 * num2;
                case Operation.Divide:
                    return num1 / num2;
                default: return 0;
            }
        }
    
        

        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 число");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 число");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Сумма: " + MathOperations(num1, num2, Operation.Add));
            Console.WriteLine("Разность: " + MathOperations(num1, num2, Operation.Subtract));
            Console.WriteLine("Произведение: " + MathOperations(num1, num2, Operation.Multiply));
            Console.WriteLine("Частное: " + MathOperations(num1, num2, Operation.Divide));
        }
    }
}
