using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;

namespace Study
{

    public delegate void TeType(int a);

class Data {
    public int A { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return "A:"+A+",Name:"+Name;
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");
            int[] scores = { 1, 25, 5, 1, 3 };
            int[] scores2 = new int[] { 2, 3 };
            foreach (int i in scores) {
                Console.WriteLine(i);
            }

            string str = "  www.chicai.group";
            Console.WriteLine(str[6]);
            Console.WriteLine(str.ToUpper());
            Console.WriteLine(str.TrimStart());
            string[] strArray = str.Split('.');
            foreach (string s in strArray) {
                Console.WriteLine(s);
            }

            Console.WriteLine(Add(5, 10));

            TeType t;
            t = func;
            t(100);


            Func<int, int, int> d = new Func<int, int, int>(Add);
            d += fAdd;
            Console.WriteLine(d(2, 3));

            Action l = new Action(mes1);
            l += mes2;
            l();

            int[] ints = { 1, 5, 2 };
            try
            {
                throw new Exception("我错了");
                ints[4] = 5;
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            Class1 a = new Class2();
            a.a();
            a.b();

            Class3<int> obj = new Class3<int>();
            obj.a = 3;
            obj.b = 15;
            Console.WriteLine(obj.Add());

            Console.WriteLine(Add<double>(3.2, 2.4));

            Class4 ii = new Class4();
            ii[1] = 100;
            Console.WriteLine(ii[1]);

            int[,] iii = new int[2, 3];
            iii[0, 1] = 2;
            int[][] iiii = new int[2][];

            string regex = "I am a boy";
            string newstr = Regex.Replace(regex, "^", "开始：");
            Console.WriteLine(newstr);

            /*string input = Console.ReadLine();
            bool isMatch = Regex.IsMatch(input, @"^\d*$");
            Console.WriteLine(isMatch);*/

            string sttr = "123addyou恩啊1a";
            MatchCollection coll = Regex.Matches(sttr, @"[a-z]|\d");
            foreach (Match m in coll) {
                Console.WriteLine(m.ToString());
            }

            string spistr = "i,love.you!memeda";
            string[] strArr = Regex.Split(spistr, "[,.!]");
            foreach (string s in strArr) {
                Console.WriteLine(s);
            }

            Action aa = test1;
            aa += test2;
            aa -= test1;
            if (aa != null)
                aa();

            List<Data> datas = new List<Data>() {
                new Data() { A = 1,Name = "me"},
                new Data(){ A = 10,Name = "hello"},
                new Data(){ A = 5,Name = "world"}
            };

            //var newData = from m in datas where m.A >= 5 select m;
            var newData = datas.Where(m => m.A >= 5 && m.Name =="hello");
            //var newData = from m in datas
            //  from n in datas
            //  where m.A > 5 && n.A == 1 select new{ m,n};

            //var newData = from m in datas orderby m.A descending select m;
            //newData = datas.OrderBy(m => m.A);

            //var newData = from m in datas group m by m.A into groups select new { key = groups.Key, num = groups.Count() };
            foreach (var data in newData) {
                Console.WriteLine(data);
            }

            Console.WriteLine(datas.Any(m => m.A == 1));
            Console.WriteLine(datas.All(m => m.A > 0));


            ReflectClass r = new ReflectClass();
            Type type = r.GetType();
            Console.WriteLine(type.Namespace);//命名空间
            Console.WriteLine(type.Name);//类名
            Console.WriteLine(type.Assembly);//程序集

            //获取公有成员
            FieldInfo[] fieldInfo = type.GetFields();
            foreach (FieldInfo f in fieldInfo) {
                Console.Write(f.Name + " ");
            }

            //获取公有属性
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo p in propertyInfo) {
                Console.Write(p.Name + " ");
            }

            //获取公有成员方法
            MethodInfo[] methodInfo = type.GetMethods();
            foreach (MethodInfo m in methodInfo) {
                Console.Write(m.Name + " ");
            }

            //获取程序集中的所有类
            Assembly assem = type.Assembly;
            Console.WriteLine(assem.FullName);
            Type[] types = assem.GetTypes();
            foreach (Type tp in types) {
                Console.WriteLine(tp);
            }

            Assembly loadAssembly = Assembly.Load("Study");
            Console.WriteLine(loadAssembly.FullName);

            Assembly loadFromAssembly = Assembly.LoadFrom(@"D:\vs project\ClassLibrary1.dll");
            Console.WriteLine(loadFromAssembly.FullName);

            OldMethod();

            Func<int, int, int> th = Thread1;
            th.BeginInvoke(5, 3, ar =>
            {
                int result = th.EndInvoke(ar);
                Console.WriteLine("结果：" + result);
            }, null);
            
            Console.WriteLine("Hello world");

            th.BeginInvoke(9, 10, CallBack, th);

            Thread thread = new Thread(Thread2);
            thread.Start(new int[] { 5, 8 });

            ThreadClass tc = new ThreadClass(101 , 150);
            Thread tcTh = new Thread(tc.sumThread);
            tcTh.Start();
            tcTh.Join();
            Console.WriteLine(tc.getResult());

            ThreadPool.QueueUserWorkItem(Thread3);
            ThreadPool.QueueUserWorkItem(Thread3);

            //任务开启线程
            Task tas = new Task(test1);
            tas.Start();

            TaskFactory tf = new TaskFactory();
            Task tass = tf.StartNew(test2);

            Console.WriteLine("Main");

            Console.ReadKey();
        }

        static void Thread3(object state) {
            Console.WriteLine("线程开始:"+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("线程结束");
        }

        static void Thread2(object a) {
            int[] s = a as int[];
            int result = s[0] + s[1];
            Console.WriteLine("结果为：" + result);
        }

        static int Thread1(int a,int b) {
            Console.WriteLine("Thread1");
            return a + b;
        }

        static void CallBack(IAsyncResult ar) {
            Func<int, int, int> th = ar.AsyncState as Func<int, int, int>;
            int result = th.EndInvoke(ar);
            Console.WriteLine("结果为:" + result);
        }


        [Obsolete("旧方法",false)]
        static void OldMethod() {
            Console.WriteLine("旧方法");
        }

        static void test1() {
            Console.WriteLine("test1 1231321");
        }

        static void test2() {
            Console.WriteLine("test2");
        }

        static void func(int t) {
            Console.WriteLine(t);
        }

        static void mes1() {
            Console.WriteLine("mes1");
        }

        static void mes2() {
            Console.WriteLine("mes2");
        }

        static int Add(int a, int b) {
            return a + b;
        }

        static int fAdd(int a, int b) {
            return a + b * 10;
        }

        static string Add<T>(T a,T b){
            return a + "" + b;
        }
    }
}
