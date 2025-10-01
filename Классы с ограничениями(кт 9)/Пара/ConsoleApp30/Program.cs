using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    public class Pair<T, U> where T : class 
    {
        public T First { get; set; }
        public U Second { get; set; }
        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }
        public void Swap()
        {
            T newFirst = (T)(object)Second;  
            U newSecond = (U)(object)First;  
            First = newFirst;
            Second = newSecond;
        }
        public void Display()
        {
            Console.WriteLine($"First: {First} Second: {Second}");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Pair<string, string> pair1 = new Pair<string, string>("Hello","World");
            pair1.Display();
            pair1.Swap();
            pair1.Display();
        }
    }
}
