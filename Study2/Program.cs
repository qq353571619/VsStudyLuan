using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Study2
{
    class Program
    {



        static void Main(string[] args)
        {
            Task t = new Task(First);
            Task t2 = t.ContinueWith(Second);
            Task t3 = t.ContinueWith(Third);
            t.Start();

            //while (true)
            //{
            //    console.writeline(t.status);
            //    thread.sleep(500);
            //}

            Class1 c = new Class1();
            Thread go1 = new Thread(CallFunc);
            go1.Start(c);
            Thread go2 = new Thread(CallFunc);
            go2.Start(c);

        }

            static void CallFunc(object obj) {
                Class1 o = obj as Class1;
                lock (o) {
                    while (true) {
                        o.Cooo();
                    }
                }
            }

        static void First() {
            Console.WriteLine(2017);
            Console.WriteLine("First End");
        }

        static void Second(Task t) {
            Console.WriteLine("Second End");
        }

        static void Third(Task t) {
            Console.WriteLine("Third Start");
            Thread.Sleep(2000);
            Console.WriteLine("Third End");
        }
    }
}
