using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 列出n个数的全排列
{
    class Program
    {
        static int n;
        static void Main(string[] args)
        {
            Console.WriteLine("输入1-9的数字");
            Console.WriteLine(DateTime.Now);
            n = Convert.ToInt32( Console.ReadLine());
            dfs();
            
            Console.ReadKey();
        }

        static int[] book = new int[10];//用来标志数有没被用
        static int[] result = new int[10];//记录结果
        static void dfs(int step = 1) {
            if (step > n) {
                foreach (var val in result) {
                    if (val != 0) {
                        Console.Write(val + " ");
                    }
                }
                Console.WriteLine();
                return;//退出口
            }

            for (int i = 1; i <= n; i++) {
                if (book[i] == 0) {
                    result[step] = i;
                    book[i] = 1;
                    dfs(step+1);
                    book[i] = 0;
                }
            }
        }
    }
}
