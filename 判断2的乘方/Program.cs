using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 判断2的乘方
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                int data = Convert.ToInt32( Console.ReadLine());
                Console.WriteLine(Check2(data));
            }
        }

        static bool Check2(int data) {
            return (data & (data - 1)) == 0;
        }
    }
}
