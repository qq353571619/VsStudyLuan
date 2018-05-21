using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivatorA
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("ActivatorA.ClassA", true);
            ClassA a =  Activator.CreateInstance(type) as ClassA;
            a.Print();

            Console.ReadKey();
        }
    }
}
