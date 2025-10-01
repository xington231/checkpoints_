using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    public class Calculator<T> where T : new()
    {
        public T Add(T x, T y)
        {
            dynamic dx = x;
            dynamic dy = y;
            return dx + dy;

        }
        public static T Zero()
        {
            return new T();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator<int> calculator=new Calculator<int>();
            Console.WriteLine(calculator.Add(3, 2));
            int zero = Calculator<int>.Zero();
            Console.WriteLine(zero);
        }
    }
}
