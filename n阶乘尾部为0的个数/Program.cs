using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n阶乘尾部为0的个数
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Int64 sum = 1;

            for (int i = 1; i <= n; i++) {
                sum *= i;
            }

            Console.WriteLine("结果:" + sum);
            Console.WriteLine(cal(n));
            Console.ReadKey();
        }

        static int cal(int n) {
            int temp = n;
            int count = 0;

            while (temp != 0) {
                temp = temp / 5;
                count += temp;
            }

            return count;
        }
    }
}
