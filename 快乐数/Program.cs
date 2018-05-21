using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 快乐数
{
    class Program
    {
        static void Main(string[] args)
        {
            CalNum(4);
            Console.ReadKey();
        }

        static void CalNum(int n)
        {
            int sum = 0;

            while (n != 0)
            {
                int i = n % 10;
                n = n / 10;
                sum += i * i;
            }
            Console.WriteLine(sum);

            if (sum == 1)
            {
                Console.WriteLine("快乐数");
                return;
            }
            else if (sum == 4) {
                Console.WriteLine("不太快乐数");
                return;
            }

            CalNum(sum);
        }
    }
}
