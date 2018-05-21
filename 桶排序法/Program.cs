using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 桶排序法
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Random r = new Random();
            int[] datas = new int[100000];
            for (int i = 0; i < 100000; i++) {
                datas[i] = r.Next(1, 100000);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> res =  TongSort(datas);
            stopwatch.Stop();

            foreach (var data in res) {
                Console.WriteLine(data);
            }

            Console.WriteLine("用时:" + stopwatch.ElapsedMilliseconds);
            Console.WriteLine(Math.Log(100000));
            Console.WriteLine(res.Count);

            Console.ReadKey();

        }

        static List<int> TongSort(int[] datas) {
            int length = datas.Length;
            //根据数据长度计算桶的数量
            int num = (int)Math.Log(length) + 1;
            List<int>[] lists = new List<int>[num];//新建这么多个桶

            //初始化桶
            for (int init = 0; init < lists.Length; init++) {
                lists[init] = new List<int>();
            }

            //确定区间，用最大和最小值
            int min = 0, max = 0;
            for (int i = 0; i < length; i++) {
                if (min > datas[i])
                {
                    min = datas[i];
                }
                else {
                    if (max < datas[i])
                        max = datas[i];
                }
            }
            int section = (max - min) / num + 1;

            int index = 0;
            foreach (int data in datas) {
                index = data / section;
                lists[index].Add(data);
            }

            List<int> result = new List<int>();

            //对所有桶分别排序，再合并
            for (int j = 0; j < lists.Length; j++) {
                lists[j].Sort();//不知道是不是快排
                result.AddRange(lists[j]);
            }

            return result;
        }
    }
}
