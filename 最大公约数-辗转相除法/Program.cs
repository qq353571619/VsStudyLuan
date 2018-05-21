using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 最大公约数
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入两个整数，求最大公约数");
            int a, b;
            Stopwatch stopwatch = new Stopwatch();
            while (true) {
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                stopwatch.Reset();
                stopwatch.Start();
                int res = getGYSByQuick(a, b);
                stopwatch.Stop();
                Console.WriteLine(res + " 用时：" + stopwatch.ElapsedMilliseconds);
            }
        }

        //穷举法
        static int getGYSByQJF(int a, int b) {
            int bigNum = 0;
            int minNum = 0;
            if (a > b)
            {
                bigNum = a;
                minNum = b;
            }
            else if (a < b)
            {
                bigNum = b;
                minNum = a;
            }
            else {
                return a;
            }
            int result = 1;
            for (int i = 2; i < minNum / 2; i++) {
                if (bigNum % i == 0 && minNum % i == 0) {
                    result = i;
                }
            }
            
            return result;
        }

        //辗转相除法
        static int getGYSByZZXCF(int a, int b) {

            if (a == 0 || b == 0) {
                return 1;
            }

            int bigNum = 0;
            int minNum = 0;
            if (a > b)
            {
                bigNum = a;
                minNum = b;
            }
            else {
                bigNum = b;
                minNum = a;
            }

            int yu = bigNum % minNum;
            if (yu == 0)
            {
                return minNum;
            }
            else {
                return getGYSByZZXCF(yu, minNum);
            }
        }

        //相减法
        static int getGYSByXJF(int a, int b) {
            if (a == b) {
                return a;
            }
            if (a > b)
            {
                return getGYSByXJF(a - b, b);
            }
            else {
                return getGYSByXJF(b - a, a);
            }
        }

        //相减法 不用递归
        static int getGYSByXJF2(int a, int b)
        {

            while (a != b) {
                if (a > b)
                {
                    a = a - b;
                }
                else {
                    b = b - a;
                }
            }

            return a;
        }

        //更向减损术和移位结合
        static int getGYSByQuick(int a, int b) {

            if (a == b) {
                return a;
            }

            if ((a & 1) == 0 && (b & 1) == 0)
            {
                //两个都是偶数
                return getGYSByQuick(a >> 1, b >> 1) << 1;
            }
            else if ((a & 1) == 0 && (b & 1) == 1)
            {
                //a是偶数,b不是
                return getGYSByQuick(a >> 1, b);
            }
            else if ((a & 1) == 1 && (b & 1) == 0)
            {
                //b是偶数，a不是
                return getGYSByQuick(a, b >> 1);
            }
            else {
                //都是奇数
                int mid = 0;
                int min = 0;
                if (a > b)
                {
                    mid = a - b;
                    min = b;
                }
                else {
                    mid = b - a;
                    min = a;
                }
                return getGYSByQuick(mid, min);
            }
        }
    }
}
