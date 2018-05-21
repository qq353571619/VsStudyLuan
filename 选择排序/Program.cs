using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 选择排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] datas = new int[100000];
            Random r = new Random();
            for (int i = 0; i < 100000; i++) {
                datas[i] = r.Next(1, 10000);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] newdatas = SortChoice(datas);
            stopwatch.Stop();
            foreach (int data in newdatas) {
                Console.WriteLine(data);
            }

            Console.WriteLine("用时：" + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static int[] Sort(int[] datas) {
            int length = datas.Length;
            int[] newArr = new int[datas.Length];
            for (int x = 0; x < length; x++) {
                newArr[x] = datas[x];
            }
            
            for (int i = 0; i < length; i++) {
                for (int j = i + 1; j < length; j++) {
                    if (newArr[j] < newArr[i]) {
                        int temp = newArr[i];
                        newArr[i] = newArr[j];
                        newArr[j] = temp;
                    }
                }
            }
            return newArr;
        }

        static int[] SortChoice(int[] datas)
        {
            int length = datas.Length;
            int[] newArr = new int[datas.Length];
            for (int x = 0; x < length; x++)
            {
                newArr[x] = datas[x];
            }

            int index = 0;
            for (int i = 0; i < length; i++)
            {
                index = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (newArr[j] < newArr[index])
                    {
                        index = j;
                    }
                }

                if (index != i) {
                    int temp = newArr[i];
                    newArr[i] = newArr[index];
                    newArr[index] = temp;
                }
            }
            return newArr;
        }
    }
}
