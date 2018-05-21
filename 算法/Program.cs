using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法
{

class Data {
    public int id;
    public string Name;
}

class Program
{
    static Dictionary<int,Data> list;

    static void Main(string[] args)
    {
        list = new Dictionary<int, Data>();
        for (int i = 1; i <= 100; i++) {
            Data data = new Data();
            data.id = i;
            data.Name = "Name" + i;
            list.Add(i,data);
        }

        while (true) {
            Console.WriteLine("输入你要查找的数字");
            string input = Console.ReadLine();
            int num;
            Int32.TryParse(input, out num);
            int index = searchNum(num, 1, list.Count);
            Console.WriteLine(index);
        }
    }

    static int searchNum(int value, int from, int to) {

        int result = -1;

        int temp = (int)Math.Floor((double)(from + to) / 2);

        if (temp < 1 || temp > list.Count) {
            return -1;
        }

        //获取中间元素的值
        int tempVal = list[temp].id;

        if (tempVal == value) {
            return temp;
        }

        if (from == to)
        {
            //找不到
            return -1;
        }

        if (tempVal > value) {
            result =  searchNum(value, from, temp-1);
        }

        if (tempVal < value) {
            result = searchNum(value, temp+1, to);
        }

        return result;
    }
}
}
