using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp21.Program;

namespace ConsoleApp21
{
    internal class Program
    {
        public interface IConverter<in T, out U>
        {
            U Convert(T value);
        }
        public class StringToIntConverter:IConverter<string, int>
        { 
            public int Convert(string stroka)
            {
                return System.Convert.ToInt32(stroka);
            }
        }
        public class ObjectToStringConverter: IConverter<object, string>
        {
            public string Convert(object obj)
            {
                return System.Convert.ToString(obj);
            }
        }
        public delegate U ConverterDelegate<T, U>(T value);
        public static U[] ConvertArr<T, U>(T[] arr, ConverterDelegate<T, U> converter)
        {
            return arr.Select(item => converter(item)).ToArray();
        }

        static void Main(string[] args)
        {
            string stroka = "1";
            StringToIntConverter stringToIntConverter = new StringToIntConverter();
            int num = stringToIntConverter.Convert(stroka);
            Console.WriteLine(num);

            object object1 = "vbcbc";
            ObjectToStringConverter objectToStringConverter = new ObjectToStringConverter();
            string stroka1 = objectToStringConverter.Convert(object1);
            Console.WriteLine(stroka1);

            string[] stringNumbers = { "1", "2", "3", "4", "5" };
            int[] numbers1 = ConvertArr(stringNumbers, s => int.Parse(s));
            Console.WriteLine(string.Join(", ", numbers1));

            // ковариантность, конвертер, возвращающий string, возвращает object
            IConverter<object, string> stringConverter = new ObjectToStringConverter();
            IConverter<object, object> objectConverter = stringConverter;

            // контрвариантность,приводим IConverter<string, int> к IConverter<object, int>
            IConverter<string, int> stringToInt = new StringToIntConverter();
            IConverter<object, int> objectConverter1 = (IConverter<object, int>)stringToInt;

        }

    }
}
