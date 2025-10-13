using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
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
    internal class Program
    {
        public static void Print<T>(T[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
        static void Main(string[] args)
        {
            int[] intArr = { 1, 2, 3, 4, 5, };
            string[] stringArr = { "kgsgs", "nbvn", "eoweap" };
            Book[] books = {new Book("Гарри Поттер", 800),new Book("Преступление и наказание", 500),};
            Print(books);
            Print(stringArr);
            Print(intArr);
        }
    }
}
