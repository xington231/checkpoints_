using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int x = 10;
            int y = 0;

            try
            {
                int z = x / y;
                Console.WriteLine(z);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Деление на ноль!");
            }
        }
    }
}
