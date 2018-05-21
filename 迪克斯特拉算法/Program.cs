using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迪克斯特拉算法
{

    class Vertex {//顶点
        public string Name;

        public Vertex(string name) {
            Name = name;
        }
    }

    class Edge {//边
        public Vertex From;
        public Vertex To;
        public int Weight;

        public Edge(Vertex from, Vertex to, int weight) {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    class VisitVertex {//用来记录存在的路径和总权重，简称路径
        public int Weight;
        public bool IsVisited;
        public Vertex Vertex;

        public VisitVertex(int weight, bool isVisited,Vertex vertex) {
            Weight = weight;
            IsVisited = isVisited;
            Vertex = vertex;
        }
    }

    class Program
    {

        static Dictionary<string, Edge[]> dict = new Dictionary<string, Edge[]>();
        static void Main(string[] args)
        {
            Vertex O = new Vertex("O");
            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Vertex C = new Vertex("c");

            //构建权重图
            Edge OA = new Edge(O, A, 6);
            Edge OB = new Edge(O, B, 3);
            dict.Add("O", new Edge[] { OA, OB });
            Edge BA = new Edge(B, A, 2);
            Edge BC = new Edge(B, C, 9);
            dict.Add("B", new Edge[] { BA, BC });
            Edge AC = new Edge(A, C, 1);
            dict.Add("A", new Edge[] { AC });

            SearchLow(C);
            Console.ReadKey();
        }

        static void SearchLow(Vertex x){
            Dictionary<Vertex, Vertex> parent = new Dictionary<Vertex, Vertex>();//保存最短节点与节点的关系
            Dictionary<Vertex, VisitVertex> weight = new Dictionary<Vertex, VisitVertex>();//记录当前最小权重

            //初始化三个字典，起点开始
            //获取到起点开始指向的边
            Edge[] edges;
            dict.TryGetValue("O", out edges);
            foreach (Edge e in edges)
            {
                parent.Add(e.To, e.From);
                weight.Add(e.To, new VisitVertex(e.Weight,false,e.To));
            }


            VisitVertex go = null;
            while ((go = GetLowVertex(weight)) != null) {
                Edge[] edges2;
                dict.TryGetValue(go.Vertex.Name, out edges2);
                if (edges2 == null) break;

                foreach (Edge ee in edges2) {
                    int myWeight = go.Weight + ee.Weight;
                    VisitVertex orightWeight;
                    weight.TryGetValue(ee.To, out orightWeight);
                    if (orightWeight == null)
                    {
                        //如果没有过该路径，就添加
                        weight.Add(ee.To, new VisitVertex(myWeight, false, ee.To));
                        parent.Add(ee.To, ee.From);
                    }
                    else {
                        if (orightWeight.Weight > myWeight)
                        {
                            //发现更短的路径，更新权重值，更改为没有访问过，修改父节点（新路径了）
                            orightWeight.Weight = myWeight;
                            orightWeight.IsVisited = false;
                            parent[ee.To] = ee.From;
                        }
                    }
                    
                }
            }

           
            //输出路径和权重总值
            VisitVertex finVist;
            weight.TryGetValue(x, out finVist);
            Console.WriteLine("总权重值：" + finVist.Weight);

            Console.WriteLine(x.Name);
            Vertex cur = x;
            
            while (true) {
                Vertex aaa;
                parent.TryGetValue(cur, out aaa);
                cur = aaa;
                if (aaa == null)
                {
                    break;
                }

                Console.WriteLine(aaa.Name);
            }
            

        }

        //获取总权重值最小，又没有被访问过路径
        static VisitVertex GetLowVertex(Dictionary<Vertex, VisitVertex> d) {
            int val = Int32.MaxValue;
            VisitVertex visit = null;
            foreach (var i in d) {
                if (i.Value.IsVisited == false) {
                    if (i.Value.Weight < val) {//新路径比旧路径权重值小
                        val = i.Value.Weight;
                        visit = i.Value;
                    }
                }
            }

            if (visit != null) {
                //标志该路径以被访问过
                visit.IsVisited = true;
            }
            return visit;
        }
    }
}
