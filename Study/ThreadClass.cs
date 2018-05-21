
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class ThreadClass
    {
        private int a;
        private int b;
        private int sum = 10;

        public ThreadClass(int a,int b) {
            this.a = a;
            this.b = b;
        }

        public void sumThread() {
            this.sum = a + b;
        }

        public int getResult() {
            return this.sum;
        }
    }
}
