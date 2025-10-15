using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp52
{
    public class PrimeNumbers: IEnumerator<int>
    {
        private int current;
        private int next;
        public PrimeNumbers()
        {
            Reset();
        }

        public bool MoveNext()
        {
            next=current+1;
            while (true)
            {
                if (IsPrime(next))
                {
                    current = next;
                    return true;
                }
                next++;
            }
        }
        public void Reset()=>current=1;
        public int Current => current;

        object IEnumerator.Current => Current;
        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false ;
                }
            }
            return true;
        }
        public void Dispose()
        {
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new PrimeNumbers();
            int count = 0;
            while (count<10)
            {
                numbers.MoveNext();
                Console.WriteLine(numbers.Current);
                count++;

            }
            
        }
    }
}
