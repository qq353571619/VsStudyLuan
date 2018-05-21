using System;
using System.Reflection;

namespace 特性
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Class1);
            MyAttribute attribute = t.GetCustomAttribute(typeof(MyAttribute)) as MyAttribute;
            Console.WriteLine("Class1的特性Index:" + attribute.Index);

            FieldInfo[] fieldInfos = t.GetFields();

            foreach (var i in fieldInfos)
            {
                object[] mys = i.GetCustomAttributes(false);
                foreach (var j in mys)
                {
                    MyAttribute my = j as MyAttribute;
                    Console.WriteLine(i.Name + "的特性Index:" + my.Index);
                }
            }

            Console.WriteLine();Console.WriteLine("继承的类也有特性");
            t = typeof(Class2);
            attribute = t.GetCustomAttribute(typeof(MyAttribute)) as MyAttribute;
            Console.WriteLine("Class2的特性Index:" + attribute.Index);

            fieldInfos = t.GetFields();

            foreach (var i in fieldInfos)
            {
                object[] mys = i.GetCustomAttributes(false);
                foreach (var j in mys)
                {
                    MyAttribute my = j as MyAttribute;
                    Console.WriteLine(i.Name + "的特性Index:" + my.Index);
                }
            }

            Console.ReadKey();
        }
        
    }
}
