using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    public class FileReader : IDisposable
    {
        StreamReader sr;
        private bool disposed = false;
        public FileReader(string path)
        {
            sr = new StreamReader(path);
        }
        public IEnumerable<string> ReadAllLines()
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
        }
        public void Dispose()
        {
            if (!disposed)
            {
                sr?.Dispose();
                disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileReader file=new FileReader("C:\\Users\\degty\\source\\repos\\ConsoleApp58\\file1.txt"))
            {
                file.ReadAllLines();
                foreach (string line in file.ReadAllLines()) { Console.WriteLine(line); }  
            }
        }
    }
}
