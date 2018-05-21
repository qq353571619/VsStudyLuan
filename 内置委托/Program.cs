using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内置委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> a = NormalFunc;
            a("Hei");

            Func<int, int, string> func = ReturnFunction;
            Console.WriteLine(func(1, 2));

            Console.ReadKey();
        }

        static string ReturnFunction(int a, int b) {
            return "a+b=" + (a + b);
        }

        static void NormalFunc(string str) {
            Console.WriteLine("I am NORMAL FUNCTION " + str);
        }


    }
}
