using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    public interface IClonable<T>where T: class
    {
        T Clone();
    }
    public class Point: IClonable<Point>
    {
    
        public int X { get; set; }
        public int Y { get; set; }
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point Clone()
        {
            return new Point(this);
        }

    }
    public class Rectangle: IClonable<Rectangle>
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(Rectangle rectangle)
        {
            Width = rectangle.Width;
            Height = rectangle.Height;
        }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public Rectangle Clone()
        {
            return new Rectangle(this);
        }



    }
    internal class Program
    {
        public static T CloneObject<T>(T obj) where T : class, IClonable<T>
        {
            return obj.Clone();
        }


        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle ( 4, 5 );
            Point point = new Point(1, 3);
            Rectangle rectangle1=rectangle.Clone();
            Point point1=point.Clone();
            Console.WriteLine($"Ширина прямоугольника: {rectangle.Width}, высота прямоугольника: {rectangle.Height}");
            Console.WriteLine($"Координаты точки: x = {point.X}, y = {point.Y}");

            Console.WriteLine($"Клонированный прямоугольник: ширина = {rectangle1.Width}, высота = {rectangle1.Height}");
            Console.WriteLine($"Клонированная точка: x = {point1.X}, y = {point1.Y}");

        }
    }
}
