using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开闭原则
{
    class Mul : ICal
    {
        public int Cal(int a, int b)
        {
            return a * b;
        }
    }
}
