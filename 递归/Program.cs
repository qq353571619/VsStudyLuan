using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 递归
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Mul(5));
            Console.ReadKey();
        }

        //计算1到n的累积
        static int Mul(int n) {
            if (n == 1) {
                return 1;
            }
            return n * Mul(n - 1);
        }
    }
}
