using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64Help
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "{\"userid\": 100}";

            Console.WriteLine(Base64Helper.encode(str));

            Console.WriteLine(Base64Helper.decode(Base64Helper.encode(str)));

            Console.ReadKey();
        }
    }
}
