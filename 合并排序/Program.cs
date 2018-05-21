using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 合并排序
{
    class Program
    {
        static void Main(string[] args)
        {
            //随机10W个数据
            int[] datas = new int[100000];
            Random r = new Random();
            for (int i = 0; i < 100000; i++) {
                datas[i] = r.Next(1,10000);
            }
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            sort(datas);//排序
            stopwatch.Stop();

            foreach (var data in datas) {
                Console.WriteLine(data);
            }
            Console.WriteLine();
            Console.WriteLine("用时：" + stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }

        static void sort(int[] datas) {
            int length = datas.Length;
            int[] temp = new int[length];
            sort(datas, 0, length - 1, temp);
        }

        static void sort(int[] datas,int left,int right,int[] temp) {
            if (left < right) {
                int mid = (left + right)/2;
                //拆分
                sort(datas, left, mid, temp);
                sort(datas, mid + 1, right, temp);
                //合并，拆到不能拆就合并
                merge(datas, left, mid, right, temp);
            }
        }

        static void merge(int[] datas, int left, int mid, int right, int[] temp) {
            int i = left;
            int j = mid + 1;
            int t = 0;

            //对比左右两边,排序填充到临时数组
            while (i <= mid && j <= right) {
                if (datas[i] < datas[j])
                {
                    temp[t++] = datas[i++];
                }
                else {
                    temp[t++] = datas[j++];
                }
            }

            //填充剩下了
            while (i <= mid) {
                temp[t++] = datas[i++];
            }

            while (j <= right) {
                temp[t++] = datas[j++];
            }

            //将排序好的临时数据覆盖到原来的数组中
            t = 0;
            while (left <= right) {
                datas[left++] = temp[t++];
            }
        }
    }
}
