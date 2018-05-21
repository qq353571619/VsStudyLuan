using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开闭原则
{
    class Program
    {
        static void Main(string[] args)
        {
            Cal cal = new Cal();
            int r1 = cal.DoCal(10, 20);
            Console.WriteLine(r1);

            cal.SetCalCode(new Mul());
            int r2 = cal.DoCal(10, 20);
            Console.WriteLine(r2);

            Console.ReadKey();
        }
    }
}
