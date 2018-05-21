using System;

namespace 扔玻璃球问题
{
    class Program
    {
        static void Main(string[] args)
        {
            //输入层数，限制两个玻璃球
            while (true) {
                string num = Console.ReadLine();
                int inum = Int32.Parse( num );
                Cal(inum);
            }
            
        }

        static void Cal(int num)
        {
            int res = 0;
            int temp = (int)Math.Sqrt(num);
            while (res == 0) {
                if ((temp + 1) * temp >= (num - 1) * 2) {
                    res = temp;
                }

                temp++;
            }

            Console.WriteLine("结果为：" + res);

            //分别在第几层楼扔
            for (int i = 0; i < res; i++) {
                int stand = res * (i + 1);
                //偏移保证最大次数一样
                int offset = (i + 1) * i / 2;
                int floot = stand - offset;
                Console.Write(floot + " ");
            }

            Console.WriteLine();
        }
    }
}