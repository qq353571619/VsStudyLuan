using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 域名转IP
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.IPHostEntry iPHostEntry = System.Net.Dns.GetHostEntry("www.chicai.group");
            System.Net.IPAddress[] address = iPHostEntry.AddressList;
            Console.WriteLine(address[0].ToString());

            Console.WriteLine(System.Net.Dns.GetHostAddresses("www.chicai.group")[0]);

            Console.WriteLine(GetSystemMetrics(1));
            

            Console.ReadKey();
        }

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
    }
}
