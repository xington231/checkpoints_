using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    public class Calculator
    {
        public double Add(double x, double y)
        { return x + y; }
        public double Subtract(double x, double y)
        { return x - y; }
        public double Multiply(double x, double y)
        { return x * y; }
        public double Divide(double x, double y)
        { return x / y; }

    }
    internal class Program
    {
        public static double NumObjects(object x, object y)
        {
            double xObj = Convert.ToDouble(x);
            double yObj = Convert.ToDouble(y);
            return xObj * yObj + 10; 
        }
        public static int MultiplyInt(double x, double y)
        {
            return (int)(x * y);
        }

        static double Operation(double x,double y, Func<double, double, double> operation)
        {
            return operation(x,y);
        }
        static void Main(string[] args)
        {


            double sum = Operation(12, 1, (x2, y2) => x2 + y2);
            Console.WriteLine(sum); 

            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Multiply(12, 1));
            Console.WriteLine(calculator.Add(12, 1));
            Console.WriteLine(calculator.Divide(12, 1));
            Console.WriteLine(calculator.Subtract(12, 1));

            //контрвариантность,использую более общий object,где ожидается конкретный double 

            Func<object, object, double> objectstodouble = NumObjects;

            Func<double, double, double> operation = (x1, y1) => objectstodouble(x1, y1);

            Console.WriteLine(Operation(2,6, operation));

            //ковариантность,метод возвращает int,но делегат ожидает double

            Func<double, double, int> multiplyInt = MultiplyInt;
            Func<double, double, double> operation2 = (x1, y1) => multiplyInt(x1, y1); 
            Console.WriteLine( Operation(10, 5, operation2));
        }
    }
}
