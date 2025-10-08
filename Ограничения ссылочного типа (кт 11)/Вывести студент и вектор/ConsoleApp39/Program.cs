using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    public interface IPrintable<T>where T : class
    {
        void Print();   
    }
    public class Student: IPrintable<Student>
    {
        public string Name;
        public int Age;
        public int Grade;
        public Student(string name, int age, int grade  )
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        public void Print()
        {
            Console.WriteLine($"Имя = {Name}, Возраст = {Age}, Класс = {Grade}");
        }
    }
    public class Vector : IPrintable<Vector>
    {
        public int X;
        public int Y;
        public int Z;

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Print()
        {
            Console.WriteLine($"X = {X}, Y = {Y}, Z = {Z}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Варвара", 15, 9);
            student.Print();

            Vector vector = new Vector(5, 7, 1);
            vector.Print();

        }
    }
}
