using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 快速排序
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 100000; i++) {
                list.Add(r.Next(1, 10000));
            }
            int[] datas = new int[100000];
            for (int j = 0; j < 100000; j++) {
                datas[j] = r.Next(1, 100000);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //List<int> sort = quickSort(list);
            sortArray(0, datas.Length - 1, datas);
            stopwatch.Stop();
            //foreach (int data in sort) {
            //Console.WriteLine(data);
            //}

            foreach (int data in datas) {
                Console.WriteLine(data);
            }

            Console.WriteLine("是否排序好：" + isSort(datas));
            Console.WriteLine("运行时间:" + stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }

        static List<int> quickSort(List<int> datas) {
            int length = datas.Count;
            if (length < 2) {
                return datas;
            }

            //随机一个参考数
            Random r = new Random();
            int random_index = r.Next(0, length);
            int val = datas[random_index];
            datas.RemoveAt(random_index);
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            foreach (int data in datas) {
                if (data < val)
                {
                    left.Add(data);
                }
                else {
                    right.Add(data);
                }
            }

            left = quickSort(left);
            right = quickSort(right);
            left.Add(val);
            left.AddRange(right);

            return left;
        }

        static void sortArray(int start,int end,int[] datas) {

            if (start >= end) {
                return;
            }
            
            int i = start;
            int j = end;
            int refer = datas[start];
            while (i != j) {

                while (datas[j] >= refer && j > i)
                {
                    j--;
                }

                while (datas[i] <= refer && i < j)
                {
                    i++;
                }

                if (i < j) {
                    //交换
                    int temp = datas[i];
                    datas[i] = datas[j];
                    datas[j] = temp;
                }
            }

            datas[start] = datas[i];
            datas[i] = refer;

            sortArray(start, i - 1, datas);
            sortArray(i + 1, end, datas);
        }

        static bool isSort(int[] datas) {
            for (int i = 0; i < datas.Length -1; i++) {
                if (datas[i] > datas[i + 1]) {
                    return false;
                }
            }

            return true;
        }
    }
}
