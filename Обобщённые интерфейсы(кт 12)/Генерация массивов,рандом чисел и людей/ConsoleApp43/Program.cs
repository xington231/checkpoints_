using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp43
{
    public interface IFactory<T>
    {
        T Create();
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
    public class RandomNumberFactory : IFactory<int>
    {
        private static Random rnd = new Random();
        public int Create()
        {
            return rnd.Next(100);  
        }
        
    }
    public class PersonFactory: IFactory<Person>
    {
        public Person Create()
        {

            Console.WriteLine("Введите имя пользователя");
            string name=Console.ReadLine();
            int age;
            while (true)
            {
                Console.WriteLine("Введите возраст");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод,повторите снова");
                }
            }
            return new Person(name, age);
            

        }
    }
    internal class Program
    {
        public static T[] CreateArr<T>(IFactory<T> factory, int n)
        {
            T[] arr = new T[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = factory.Create();
            }
            return arr;
        }
        static void Main(string[] args)
        {
            PersonFactory factory = new PersonFactory();
            Person person = factory.Create();
            Console.WriteLine(person);

            RandomNumberFactory randomNumberFactory = new RandomNumberFactory();
            int[] numbers = CreateArr(randomNumberFactory, 5);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
