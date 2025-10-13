using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>()
            {
                ["Италия"]="Рим",
                ["Франция"] = "Париж",
                ["Чехия"] = "Прага"
            };
            Dictionary<string, int> population = new Dictionary<string, int>()
            {
                ["Италия"] = 58,
                ["Франция"] = 68,
                ["Чехия"] = 10
            };
            while (true)
            {
                Console.WriteLine("Введите страну");
                string country=Console.ReadLine();
                if (!countries.ContainsKey(country))
                {
                    Console.WriteLine("Данной страны нет в списке");
                    continue;
                }
                foreach (var c in countries)
                {
                    if (c.Key == country)
                    {
                        Console.WriteLine($"Столица данной страны:{c.Value}");
                    }
                }
                foreach (var p in population)
                {
                    if (p.Key == country)
                    {
                        Console.WriteLine($"Численность данной страны:{p.Value} млн");
                    }
                }
                
            }
        }
    }
}
