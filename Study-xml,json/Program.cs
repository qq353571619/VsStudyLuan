using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LitJson;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace Study_xml_json
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument xml = new XmlDocument();
            //xml.Load("xml.txt");//需要加载的XML文件

            //XmlNode firstNode = xml.FirstChild;//获取第一个节点
            //Console.WriteLine(firstNode.NextSibling.Name);//获取节点的名称
            //Console.WriteLine(firstNode.Attributes["time"].Value);//获取第一个节点属性time的值
            //XmlNodeList nodes = firstNode.ChildNodes;//获取第一个节点的所有子节点
            //foreach (XmlNode node in nodes)
            //{
            //    Console.WriteLine(node.Name);
            //    Console.WriteLine(node.InnerText);//获取节点的类容
            //}

            //JsonData jsonData = JsonMapper.ToObject(File.ReadAllText("json.txt"));
            //JsonData notes = jsonData["employees"];
            //for (int i = 0; i < notes.Count; i++) {
            //    Console.WriteLine(notes[i]["firstName"]);
            //}


            //string filePath = "装备信息.xls";//XML文件
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";//链接字符串固定
            //OleDbConnection connection = new OleDbConnection(strConn);//创建链接
            //connection.Open();//链接
            //string sql = "select * from [Sheet1$]";//sql语句
            //OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);//去指定链接中查询sql语句，用来查询的类
            //DataSet data = new DataSet();//用来存储数据的类，在System.Data空间中
            //adapter.Fill(data);//将查询到的数据填充到DataSet里
            //connection.Close();//关闭链接

            //DataTable table = data.Tables[0];//获取第一个表的数据
            //DataRowCollection rowCollection = table.Rows;//获取这个表的所有行数据

            //foreach (DataRow row in rowCollection) {//遍历每一行
            //    for (int i = 0; i < 8; i++) {
            //        Console.Write(row[i]+" ");//通过索引访问列值
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine(row["描述"]);//通过字段名访问
            //}



            Console.ReadKey();
        }
    }
}
