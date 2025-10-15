using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp51
{
    public class Matrix:IEnumerable<double>
    {
        private double[,]arr;
        private int length;
        private int width;
        public Matrix(int length, int width)
        {
            this.length = length;
            this.width = width;
            arr = new double[length, width];
        }
        public double this[int i, int j]
        {
            get { return arr[i, j]; }
            set { arr[i, j] = value; }
        }
        public IEnumerable<double> GetRow(int index)
        {
            for (int j = 0; j < width; j++)
            {
                yield return arr[index, j];
            }
        }
        public IEnumerable<double> GetColumn(int index)
        {
            for (int i = 0; i < length; i++)
            {
                yield return arr[i, index];
            }
        }
        public IEnumerator<double> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
                for (int j = 0; j < width; j++)
                    yield return arr[i, j];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Matrix arr= new Matrix(3, 5);
            arr[0, 0] = 4;
            arr[0, 1] = 5;
            arr[0, 2] = 6;
            arr[0, 3] = 7;
            arr[0, 4] = 8;  

            arr[1, 0] = 10;
            arr[1, 1] = 11;
            arr[1, 2] = 12;
            arr[1, 3] = 13;
            arr[1, 4] = 14;

            arr[2, 0] = 20;
            arr[2, 1] = 21;
            arr[2, 2] = 22;
            arr[2, 3] = 23;
            arr[2, 4] = 24;

            foreach (double value in arr.GetRow(0))
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            foreach (double value in arr.GetColumn(0))
            {
                Console.WriteLine(value);
            }
        }
    }
}
