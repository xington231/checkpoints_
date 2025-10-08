using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp38
{
    public class Book
    {
        public string Title;
        public int Price;
        public Book(string title, int price )
        {
            Title = title;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Title} : {Price} руб.";
        }
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
    public class LinkedList<T> where T : class
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
            if (item == null) throw new ArgumentNullException(nameof(item));
            var newNode = new Node(item);
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
        public bool Remove(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (head == null)
                return false;

            if (head.Value.Equals(item))
            {
                head = head.Next;
                return true;
            }

            var current = head;
            while (current.Next != null && !current.Next.Value.Equals(item))
            {
                current = current.Next;
            }

            if (current.Next == null)
                return false;

            current.Next = current.Next.Next;
            return true;
        }
        public bool Contains(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
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
                LinkedList<String> listString = new LinkedList<String>();
                listString.Add("Hello");
                listString.Add("World");
                listString.PrintAll();
                Console.WriteLine(listString.Contains("Hello"));
                listString.Remove("World");
                listString.PrintAll();

                Console.WriteLine();

                LinkedList<Book> bookList = new LinkedList<Book>();
                Book dushi = new Book("Мертвые души", 700);
                bookList.Add(dushi);
                Book prestuplenie = new Book("Преступление и наказание", 1000);
                bookList.Add(prestuplenie);
                bookList.PrintAll();
                Console.WriteLine(bookList.Contains(prestuplenie));
                bookList.Remove(prestuplenie);
                bookList.PrintAll();

                Console.WriteLine();

                LinkedList<Person> personList = new LinkedList<Person>();
                Person maria = new Person("Мария", 18);
                personList.Add(maria);
                Person vladimir = new Person("Владимир", 28);
                personList.Add(vladimir);
                personList.PrintAll();
                Console.WriteLine(personList.Contains(maria));
                personList.Remove(maria);
                personList.PrintAll();

        }
    }
}
