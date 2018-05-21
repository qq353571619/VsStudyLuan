using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellman_Ford
{

    class Vectex {
        public int Index;
        public Vectex(int index) {
            Index = index;
        }
    }

    class Edge {

        public Vectex From,To;
        public int Weight;

        public Edge(Vectex from, Vectex to,int weight) {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            Vectex O = new Vectex(0);
            Vectex A = new Vectex(1);
            Vectex B = new Vectex(2);
            Vectex C = new Vectex(3);
            Vectex D = new Vectex(4);
            Vectex[] vectexs = new Vectex[] { O, A, B, C, D };

            Dictionary<Vectex, Edge[]> datas = new Dictionary<Vectex, Edge[]>();
            Edge OA = new Edge(O, A, 2);
            Edge OB = new Edge(O, B, 3);
            Edge AC = new Edge(A, C, 7);
            Edge AD = new Edge(A, D, -1);
            Edge BD = new Edge(B, D, 1);
            Edge DC = new Edge(D, C, 2);
            datas.Add(O, new Edge[] { OA, OB });
            datas.Add(A, new Edge[] { AC,AD });
            datas.Add(B, new Edge[] { BD });
            datas.Add(D, new Edge[] { DC });

            int[] results = Ford(datas, vectexs);
            foreach (var ii in results) {
                Console.Write(ii + " ");
            }

            Console.ReadKey();
        }

        static int[] Ford(Dictionary<Vectex,Edge[]> datas, Vectex[] vectexs) {
            int vNum = vectexs.Length;
            int[] book = new int[vNum];
            int[] dis = new int[vNum];

            for (int i = 0; i < vNum; i++) {
                dis[i] = int.MaxValue;
            }
            dis[0] = 0;

            Queue<Vectex> queue = new Queue<Vectex>();
            queue.Enqueue(vectexs[0]);
            book[0] = 1;
            
            Vectex v;
            while(queue.Count>0){
                v = queue.Dequeue();
                Edge[] edges;
                datas.TryGetValue(v, out edges);
                book[v.Index] = 0;
                if (edges == null) {
                    continue;
                }

                foreach (var e in edges) {
                    if (dis[e.To.Index] > dis[v.Index] + e.Weight) {
                        dis[e.To.Index] = dis[v.Index] + e.Weight;
                        queue.Enqueue(e.To);
                        book[e.To.Index] = 1;
                    }
                }
            }

            return dis;
        }
    }
}
