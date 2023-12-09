using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    internal class Program
    {

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Sub(int x, int y)
        {
            return x - y;
        }

        public static int Function(Func<int, int, int> operation1, Func<int, int, int> operation2, int x, int y)
        {
            return operation1(x, y) + operation2(x, y);
        }

        public static Func<int, Func<int, int>> Curry(Func<int, int, int> operation1, Func<int, int, int> operation2)
        {
            Func<int, int> X(int x)
            {
               int Y(int y)
               {
                    return operation1(x, y) + operation2(x, y);
                }
                return Y;
            }
            return X;
        }

        static void Main(string[] args)
        {
            var res1 = Function(Add, Sub, 2, 3);
            Console.WriteLine($"Результат функції вищого порядку: {res1}");
            var res2 = Curry(Add, Sub);
            Console.WriteLine($"Результат карінгу: {res2(2)(3)}");
        }
    }
}
