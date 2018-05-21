using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 统计数字
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticNum(12, 1);
            StaticNum(12, 2);
            StaticNum(400, 1);

            Console.WriteLine(digitCounts(1, 400));

            Console.ReadKey();
        }

        static void StaticNum(int num, int search)
        {
            int temp = 0;
            int test = 0;
            int count = 0;
            for (int i = 0; i <= num; i++)
            {
                temp = i;
                do
                {
                    test = temp % 10;
                    temp = temp / 10;

                    if (test == search)
                        count++;

                } while (temp != 0);
            }

            Console.WriteLine("0到" + num + "数字" + search + "出现了" + count + "次");
        }

        public static int digitCounts(int k, int n)
        {
            if (n == 0 && k == 0)
                return 1; // 特殊情况  
            int temp = n, cnt = 0, pow = 1;//pow代表当前位的后面低位是多少，1为个位，10为十位，100位千位  
            while (temp != 0)
            {
                int digit = temp % 10; // 根据当前位置数和k的大小关系，可以算出当前位置出现过k的次数  
                if (digit < k)
                    cnt += (temp / 10) * pow;
                else if (digit == k)
                    cnt += (temp / 10) * pow + (n - temp * pow + 1);
                else
                {
                    if (!(k == 0 && temp / 10 == 0)) // 排除没有更高位时，寻找的数为0的情况  
                        cnt += (temp / 10 + 1) * pow;
                }
                temp /= 10;
                pow *= 10;
            }
            return cnt;
        }
    }
}
