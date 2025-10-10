using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp41
{
    public interface IList<T>
    {
        void Add(T item);
        void Remove(T item);
        T Get(int index);
        void Set(int index, T item);
        int Count();
    }

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

    public class ArrayList<T> : IList<T>
    {
        private T[] _items;
        private int _count;

        public ArrayList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Ёмкость не может быть отрицательной.");
            _items = new T[capacity];
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
                Resize(_items.Length == 0 ? 4 : _items.Length * 2); // Исправлено для случая с capacity = 0
            _items[_count++] = item;
        }

        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
                RemoveAt(index);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item))
                    return i;
            }
            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index} вне допустимого диапазона");

            for (int i = index; i < _count - 1; i++)
                _items[i] = _items[i + 1];

            _items[_count - 1] = default;
            _count--;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index} вне допустимого диапазона");
            return _items[index];
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index} вне допустимого диапазона");
            _items[index] = item;
        }

        public int Count() => _count;
    }

    public class LinkedList<T> : IList<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        public LinkedList()
        {
            head = null;
        }
        public void Add(T item)
        {
            var newNode = new Node(item); // Убрана проверка на null для работы с value types
            if (head == null)
            {
                head = newNode;
                return;
            }
            var current = head;
            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }
        public void Remove(T item)
        {
            if (head == null)
                return;

            if (head.Value.Equals(item))
            {
                head = head.Next;
                return;
            }

            var current = head;
            while (current.Next != null && !current.Next.Value.Equals(item))
            {
                current = current.Next;
            }

            if (current.Next == null)
                return;

            current.Next = current.Next.Next;
        }

        public T Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс не может быть отрицательным");

            var current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return current.Value;

                current = current.Next;
                currentIndex++;
            }
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс превышает длину списка");
        }
        public void Set(int index, T item)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс не может быть отрицательным");

            var current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    current.Value = item;
                    return;
                }
                current = current.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Индекс превышает длину списка");
        }
        public int Count()
        {
            int count = 0;
            var current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
        public void PrintAll()
        {
            if (head == null)
            {
                Console.WriteLine("Лист пустой");
                return;
            }

            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var intList = new ArrayList<int>(5);
            intList.Add(4);
            intList.Add(32);
            intList.Add(6);

            Console.WriteLine($"Количество элементов: {intList.Count()}");
            Console.WriteLine($"Элемент с индексом 2: {intList.Get(2)}");

            var stringList = new ArrayList<string>(3);
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");

            Console.WriteLine($"Количество элементов: {stringList.Count()}");
            Console.WriteLine($"Элемент с индексом 1: {stringList.Get(1)}");


            var linkedIntList = new LinkedList<int>();
            linkedIntList.Add(4);
            linkedIntList.Add(32);
            linkedIntList.Add(6);

            Console.WriteLine("Элементы связного списка:");
            linkedIntList.PrintAll();
            Console.WriteLine($"Количество элементов: {linkedIntList.Count()}");
            Console.WriteLine($"Элемент с индексом 0: {linkedIntList.Get(0)}");

            var personList = new LinkedList<Person>();
            personList.Add(new Person("Василий", 12));
            personList.Add(new Person("Мария", 32));

            Console.WriteLine("\nЛюди в связном списке:");
            personList.PrintAll();

        }
    }
}