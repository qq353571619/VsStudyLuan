using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 广度优先搜索
{
    class Vertex {
        public string data;
        public bool isVisited;

        public Vertex(string d) {
            data = d;
            isVisited = false;
        }
    }

    class Program
    {
        static Dictionary<string, Vertex[]> dict = new Dictionary<string, Vertex[]>();
        static void Main(string[] args)
        {
            Vertex A = new Vertex("Bom");
            Vertex B = new Vertex("Tom");
            Vertex C = new Vertex("Chicai");
            Vertex D = new Vertex("Marry");

            //构建关系图，谁是谁的好友
            dict.Add("I", new Vertex[] { A, B });
            dict.Add("Bom", new Vertex[] { D });
            dict.Add("Tom", new Vertex[] { D });
            dict.Add("Marry", new Vertex[] { A,B,C });
            dict.Add("Chicai", new Vertex[] { D });

            Search("Chicai");

            Console.ReadKey();

        }

        static void Search(string name) {
            Queue<Vertex> queue = new Queue<Vertex>();
            Vertex[] datas;
            dict.TryGetValue("I", out datas);
            foreach (Vertex x in datas) {
                queue.Enqueue(x);
            }

            while (queue.Count > 0) {
                Vertex x = queue.Dequeue();
                if (x.isVisited) {
                    continue;
                }
                x.isVisited = true;
                if (x.data == name)
                {
                    Console.WriteLine("找到了:" + name);
                    return;
                }
                else {
                    Console.WriteLine(x.data);
                    Vertex[] vertex;
                    dict.TryGetValue(x.data, out vertex);
                    foreach (Vertex v in vertex) {
                            queue.Enqueue(v);
                    }
                }
            }

            Console.WriteLine("找不到啊");
        }
    }
}
