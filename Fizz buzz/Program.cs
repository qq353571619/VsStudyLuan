using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz_buzz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Cal(15);

            foreach (var s in list)
            {
                Console.WriteLine(s);
            }
            

            Console.ReadKey();
        }

        static List<string> Cal(int n)
        {
            List<string> res = new List<string>();
            string[] temp = { "fizz", "fizz buzz", "buzz" };

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    res.Add(i.ToString());
                }
                else
                {
                    int a = i % 3;
                    int b = i % 5;

                    int off = a - b;
                    //映射 0-0,--1,+-2
                    int index = Math.Sign(off / (double)int.MaxValue) + 1;

                    res.Add(temp[index]);
                }
            }

            return res;
        }
    }
}
