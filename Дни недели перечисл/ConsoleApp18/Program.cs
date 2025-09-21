using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        enum DayOfWeek
        {
            Monday=1,
            Tuesday=2,
            Wednesday=3,
            Thursday=4,
            Friday=5,
            Saturday=6,
            Sunday=7
        }
        static DayOfWeek getday(int day)
        {
            if (Enum.IsDefined(typeof(DayOfWeek), day))
            {
                return (DayOfWeek)day;
            }
            else
            {
                Console.WriteLine("Введите корректное число");
                throw new ArgumentOutOfRangeException("Число должно быть от 1 до 7");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int day=int.Parse(Console.ReadLine());
            DayOfWeek dayname = getday(day);
            Console.WriteLine(dayname);
        }
    }
}
