using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp45
{
    public class Person
    {
        public string Name;
        public int Age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} : {Age} лет";
        }
    }
    internal class Program
    {
        public static void Swap<T>(ref T x, ref T y) 
        {
            T temp = x; x = y; y = temp;
        }
        public static void SwapWithConstraints<T>(ref T x,ref T y)where T : class
        {
            T temp=x; x=y; y=temp;
        }
        static void Main(string[] args)
        {
            int a = 2;
            int b = 7;
            Console.WriteLine($"До замены: {a}, {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"После замены: {a}, {b}");

            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine($"До замены: {str1}, {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"После замены: {str1}, {str2}");


            Person Alina = new Person("Алина",18);
            Person Vladimir = new Person("Владимир", 32);
            Console.WriteLine($"До замены: {Alina}, {Vladimir}");
            SwapWithConstraints(ref Alina, ref Vladimir);
            Console.WriteLine($"После замены: {Alina}, {Vladimir}");
        }
    }
}
