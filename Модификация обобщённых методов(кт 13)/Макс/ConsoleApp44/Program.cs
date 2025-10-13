using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
{
    internal class Program
    {
        public static T Max<T>(T x, T y) where T : IComparable<T>
        {
            if (x == null && y == null) return default(T);
            if (x == null) return y;
            if (y == null) return x;
            return x.CompareTo(y) > 0 ? x:y ;

        }
        static void Main(string[] args)
        {
            int x = 3;
            int y = 5;
            Console.WriteLine(Max(x,y));

            string str1 = "hello";
            string str2 = "world!";
            Console.WriteLine(Max(str1, str2));

            DateTime date1 = new DateTime(2025, 3, 12);
            DateTime date2 = new DateTime(2025, 1, 4);
            Console.WriteLine(Max(date1, date2));
        }
    }
}
