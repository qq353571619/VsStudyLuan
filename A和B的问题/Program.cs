using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A和B的问题
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12;
            int b = 5;
            Console.WriteLine(Add(a, b));


            Func<int, int, int> plus = (s, j) => s + j;

            Console.WriteLine(plus(10, 11));

            Console.ReadKey();
        }

        static int Add(int a, int b) {
            int c = 0;
            int d = 0;

            while (b != 0) {
                c = a ^ b;
                d = (a & b) << 1;

                a = c;
                b = d;
                }
            return a;
        }
    }
}
