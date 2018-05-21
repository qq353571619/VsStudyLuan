using System;

namespace 开闭原则
{
    class Add : ICal
    {
        public int Cal(int a, int b)
        {
            return a + b;
        }
    }
}
