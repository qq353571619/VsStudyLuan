using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64Help
{
    public class Base64Helper
    {
        public static string encode(string str)
        {
            try
            {
                System.Text.Encoding encode = System.Text.Encoding.ASCII;
                byte[] bytedata = encode.GetBytes(str);
                string strBase64 = Convert.ToBase64String(bytedata, 0, bytedata.Length);
                return strBase64;
            }
            catch
            {
                return null;
            }
        }

        public static string decode(string str)
        {
            try
            {
                byte[] bytedata = Convert.FromBase64String(str);
                string strText = System.Text.ASCIIEncoding.Default.GetString(bytedata);
                return strText;
            }
            catch
            {
                return null;
            }
        }

    }
}
