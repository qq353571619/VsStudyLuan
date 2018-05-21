using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace XMLLLL
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic a = 100;
            Console.WriteLine(a.GetType());//System.Int32
            dynamic s = "hahaha";
            Console.WriteLine(s.GetType());//System.String
            var t = "asd15";
            Console.WriteLine(t.GetType());//System.String

            s = 1520;
            Console.WriteLine(s.GetType());//System.Int32

            Console.ReadKey();
        }
    }
}
