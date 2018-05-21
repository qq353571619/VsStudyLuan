using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Serves
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = new IPAddress(new byte[] { 10, 0, 0, 8 });
            EndPoint endPoint = new IPEndPoint(iPAddress, 6058);
            socket.Bind(endPoint);
            socket.Listen(10);
            Console.WriteLine("等待客户端链接");

            Socket clientSocket = socket.Accept();
            Console.WriteLine("有一个客户端链接过来了");

            string message = "给客户端发送的消息2222";
            byte[] mes = Encoding.UTF8.GetBytes(message);
            Console.WriteLine("给客户端发送消息");
            clientSocket.Send(mes);

            byte[] datas = new byte[1024];
            int length = clientSocket.Receive(datas);
            string recStr = Encoding.UTF8.GetString(datas, 0, length);
            Console.WriteLine("接收到一条消息:"+recStr);

            Console.ReadKey();
        }
    }
}
