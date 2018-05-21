using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class4
    {
        List<int> list = new List<int>(20);

        public Class4() {
            for (int i = 0; i < 20; i++) {
                list.Add(i);
            }
        }

        public int this[int index] {
            get {
                if (index < 0) {
                    index = 0;
                }

                if (index > 19) {
                    index = 19;
                }

                return list[index];
            }

            set {
                if (index < 0)
                {
                    index = 0;
                }

                if (index > 19)
                {
                    index = 19;
                }

                list[index] = value;//value就是赋值的数据
            }
        }
    }
}
