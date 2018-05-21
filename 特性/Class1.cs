using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    [My(250)]
    class Class1
    {
        [My(0)][My(1)]
        public int A;
        [My(2)]
        public bool B;
    }

    class Class2 : Class1
    {

    }
}
