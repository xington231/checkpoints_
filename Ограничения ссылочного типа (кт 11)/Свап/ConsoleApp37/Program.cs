using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    
    internal class Program
    {
        public static void Swap<T>(ref T x, ref T y) where T : struct
        {
            T z = x;
            x = y;
            y = z;
        }
        static void Main(string[] args)
        {
            int x = 4;
            int y = 5;
            Console.WriteLine($"int x = {x},y = {y}");
            Swap<int>(ref x, ref y);
            Console.WriteLine($"После замены:int x = {x},y = {y}");

            double x1 = 8;
            double y1 = 12;
            Console.WriteLine($"double x = {x1},y = {y1}");
            Swap<double>(ref x1, ref y1);
            Console.WriteLine($"После замены:double x = {x1},y = {y1}");

            bool x2 = true;
            bool y2 =false;
            Console.WriteLine($"bool x = {x2},y = {y2}");
            Swap<bool>(ref x2, ref y2);
            Console.WriteLine($"После замены:bool x = {x2},y = {y2}");
        }
    }
}
