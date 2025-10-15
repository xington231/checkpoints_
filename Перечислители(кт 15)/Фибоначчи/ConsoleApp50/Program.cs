using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{
    public class Fibonacci : IEnumerable<int>
    {
        private int size;
        public Fibonacci(int size)
        {
            this.size = size;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int prev = 0, current = 1;

            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    yield return 0;
                }
                else if (i == 1)
                {
                    yield return 1;
                }
                else
                {
                    int next = prev + current;
                    yield return next;
                    prev = current;
                    current = next;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fib = new Fibonacci(10);
            foreach (int f in fib)
            {
                Console.WriteLine(f);
            }
        }
    }
}