using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    public interface IComparable<T>
    {
        int CompareTo(T y);
    }
    struct ComplexNumber: IComparable<ComplexNumber>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public int CompareTo(ComplexNumber other)
        {
            double thisMagnitude = Math.Sqrt(Math.Pow(Real,2) + Math.Pow(Imaginary, 2));
            double otherMagnitude = Math.Sqrt(other.Real * other.Real + other.Imaginary * other.Imaginary);

            return thisMagnitude.CompareTo(otherMagnitude);
        }
    }
    struct RationalNumber : IComparable<RationalNumber>
    {
        public double Number { get; set; }
        public RationalNumber(double number)
        {
            Number = number;    
        }
        public int CompareTo(RationalNumber y)
        {
            return Number.CompareTo(y.Number);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber r1 = new RationalNumber(4);
            RationalNumber r2 = new RationalNumber(8);
            int compareRational = r1.CompareTo(r2);
            Console.WriteLine(compareRational);
            ComplexNumber c1 = new ComplexNumber(3, 4);
            ComplexNumber c2 = new ComplexNumber(1, 1);
            int compareComplex = c1.CompareTo(c2);
            Console.WriteLine(compareComplex);
        }
    }
}
