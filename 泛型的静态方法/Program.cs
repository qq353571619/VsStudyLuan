using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型的静态方法
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager g = Singleton<GameManager>.GetInstance();
            NetManager n = Singleton<NetManager>.GetInstance();
            Console.WriteLine(n.Name + g.t);

            GameManager h = Singleton<GameManager>.GetInstance();
            if (g == h) {
                Console.WriteLine("同一个实例");
            }
            Console.ReadKey();
        }
    }
}
