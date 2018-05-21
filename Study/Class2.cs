using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class2:Class1
    {
        public override void a()
        {
            Console.WriteLine("class2");
        }

        new public void  b() {
            Console.WriteLine("b.class2");
        }
    }
}
