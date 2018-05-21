using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旋转字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder("abcdefg");
            Console.WriteLine(s);
            reverse(s, 10);
            Console.WriteLine(s);
            Console.ReadKey();
        }

        static void reverse(StringBuilder s,int offfset) {
            int length = s.Length;
            int time = 0;
            char temp = s[0];
            char changeChar = s[0];
            int curIndex = 0;
            int changeIndex = 0;

            while (time <= length)
            {
                changeIndex = (curIndex + offfset) % length;
                temp = s[changeIndex];
                s[changeIndex] = changeChar;
                changeChar = temp;
                curIndex = changeIndex;
                time++;
            }    
        }
    }
}
