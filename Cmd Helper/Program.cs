using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmd_Helper
{
    class Program
    {
        static void Main(string[] args)
        {

            string output;
            CmdHelper.RunCmd("php -v", out output);
            Console.WriteLine(output);

            Console.ReadKey();

        }
    }
}
