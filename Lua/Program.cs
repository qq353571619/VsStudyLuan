using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Lua
{

    



    class Program
    {

        public string Name = "chicai";

        static void Main(string[] args)
        {

            LuaInterface.Lua lua = new LuaInterface.Lua();
            lua.DoString("print('12345')");
            lua.DoFile("test.lua");
            Console.WriteLine((string)lua["str"]);//访问lua中的变量

            Program p = new Program();
            lua.RegisterFunction("NormalMethod", p, p.GetType().GetMethod("Method"));
            lua.DoString("NormalMethod()");
            lua.RegisterFunction("StaticMethod", null, typeof(Program).GetMethod("StaticMethod"));
            lua.DoString("StaticMethod()");

            lua.DoFile("go.lua");

            Console.ReadKey();

        }

        public void OutMethod(string str,out int length) {
            Console.WriteLine(str);
            length = str.Length;
        }

        public void RefMethod(string str, ref int length) {
            Console.WriteLine(str);
            Console.WriteLine(length);
            length = str.Length;
        }

        public void Method() {
            Console.WriteLine("我是c#普通方法");
        }

        public static void StaticMethod() {
            Console.WriteLine("我是一个C#静态方法");
        }
    }
}
