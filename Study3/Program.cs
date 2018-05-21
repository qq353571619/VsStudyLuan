using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Study3
{
    class Program
    {
        static void Main(string[] args)
        {

            //FileInfo fileInfo = new FileInfo("1.txt");
            //Console.WriteLine(fileInfo.Name);//文件名称
            //Console.WriteLine(fileInfo.FullName);//文件完整的路径
            //fileInfo.CopyTo("2.txt");//复制到指定路径文件
            //fileInfo.MoveTo("3.txt");//移动文件到指定位置和修改名称
            //FileInfo file = new FileInfo("6.txt");
            //if (!file.Exists) {//判断文件是否存在
            //    file.Create();//创建这个文件
            //}

            //DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\vs project\Study\Study3\bin\Debug\chicai");
            //Console.WriteLine(directoryInfo.Exists);//文件夹是否存在
            //Console.WriteLine(directoryInfo.Name);//文件名称
            //Console.WriteLine(directoryInfo.Parent);//文件夹的上级目录
            //Console.WriteLine(directoryInfo.Root);//文件夹的根目录
            //directoryInfo.CreateSubdirectory("chifan");//创建子文件夹
            //DirectoryInfo dir = new DirectoryInfo("cc");
            //if (!dir.Exists) {
            //    dir.Create();//创建文件夹
            //}

            string[] strs = File.ReadAllLines("2.txt");
            foreach (var s in strs) {
                Console.WriteLine(s);
            }

            File.WriteAllText("2.txt", "我是要写进来的");

            FileStream fileStream = new FileStream("2.txt", FileMode.Append);
            BinaryWriter w = new BinaryWriter(fileStream);
            w.Write("123");
            w.Close();
            fileStream.Close();

            StreamWriter streamWriter = new StreamWriter("2.txt");
            streamWriter.Write("hhah");
            streamWriter.Close();

            StreamReader streamReader = new StreamReader("2.txt");
            string ssss = streamReader.ReadLine();
            Console.WriteLine(ssss);

            Pri("hello", "i", "am");
            string[] strss = { "you", "is", "me" };
            Pri(strss);
            Pri();

            Console.ReadKey();

        }

            static void Pri(params string[] strs) {
                foreach (string str in strs) {
                    Console.WriteLine(str);
                }
            }
    }
}
