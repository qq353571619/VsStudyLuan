using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开闭原则
{
    class Cal
    {
        //默认使用加法
        private ICal calCode = new Add();

        //用来设置使用的运算方式
        public void SetCalCode(ICal code)
        {
            calCode = code;
        }

        public int DoCal(int a, int b)
        {
            return calCode.Cal(a, b);
        }
    }
}
