using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Program
    {
        enum Color
        {
            Red,
            Green,
            Blue,
            Yellow,
            Cyan,
            Magenta
        }
        static string getColor(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return "#FF0000";
                case Color.Green:
                    return "#00FF00";
                case Color.Blue:
                    return "#0000FF";
                case Color.Yellow:
                    return "#FFFF00";
                case Color.Cyan:
                    return "#00FFFF";
                case Color.Magenta:
                    return "#FF00FF";
                default:
                    return "#000000";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите цвет(Red, Green, Blue, Yellow, Cyan, Magenta)");
            string input = Console.ReadLine();
            Color color = (Color)Enum.Parse(typeof(Color), input);
            string code = getColor(color);
            Console.WriteLine("Код цвета: "+code);
        }
    }
}
