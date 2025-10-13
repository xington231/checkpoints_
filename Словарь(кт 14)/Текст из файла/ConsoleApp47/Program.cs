using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\degty\\source\\repos\\ConsoleApp47\\words.txt");
            string line = sr.ReadLine();
            var flowers = new Dictionary<string, int>();
            while (line != null)
            {
                if (flowers.ContainsKey(line))
                {
                    flowers[line]++;
                    line = sr.ReadLine();
                }
                else
                {
                    flowers[line] = 1;
                    line = sr.ReadLine();
                }
            }
            var SortedFlowers= flowers.OrderByDescending(x => x.Key);
            foreach (var item in SortedFlowers)  
            {
                Console.WriteLine($"ключ: {item.Key}  значение: {item.Value}");
            }
        }
    }
}
