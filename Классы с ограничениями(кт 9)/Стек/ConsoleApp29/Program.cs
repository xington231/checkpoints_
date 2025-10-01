using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{

    public class Stack<T>where T : IComparable<T>
    {
        private T[] items;
        private int count;

        public Stack(int capacity = 16)
        {
            items = new T[capacity];
            count = 0;
        }

        public void Push(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length * 2);
            items[count++] = item;
        }
        public T Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            items[count] = default;
            return item;
        }
        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Стек пуст");
            return items[count - 1];
        }
        public T Max()
        {
            T max = items[0];
            for (int i = 1; i < count; i++)
            {
                if (items[i].CompareTo(max) > 0)
                    max = items[i];
            }
            return max;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(3);
            stack.Push(13);
            stack.Push(7);
            stack.Push(1);;
            Console.WriteLine("Максимальное значение: " + stack.Max());
        }
    }
}
