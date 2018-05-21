using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study2
{
    class Class1
    {
        public int i = 5;
        public void Cooo() {
            this.i++;
            if (this.i == 5) {
                Console.WriteLine("我可能会被输出");
            }

            this.i = 5;
        }
    }
}
