using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp42
{
    public interface IComparer<T>
    {
        int Compare(T x, T y);
    }
    public class Book
    {
        public string Title;
        public int Price;
        public Book(string title, int price)
        {
            Title = title;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Title} : {Price} руб.";
        }
    }
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return string.Compare(x, y);
        }
    }
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Price.CompareTo(y.Price);
        }
    }

    internal class Program
    {
        public static void SortArray<T>(T[] array, IComparer<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Массив не может быть null");

            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer), "Comparer не может быть null");
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

            static void Main(string[] args)
            {
                string[] colors = { "red", "blue", "green" };
                SortArray(colors, new StringComparer());
                foreach (var color in colors)
                {
                    Console.WriteLine(color);
                }
                var comparer = new StringComparer();
                Console.WriteLine(comparer.Compare(colors[0], colors[1]));
                Book[] books = {
                    new Book("Преступление и наказание", 800),
                    new Book("Муму", 1400)
                };
                var comparer1 = new BookComparer();
                Console.WriteLine(comparer1.Compare(books[1], books[0]));
                SortArray(books, new BookComparer());
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
                    
            }
        }
    }

