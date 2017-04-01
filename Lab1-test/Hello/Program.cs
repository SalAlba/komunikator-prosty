using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Hello
{
    class Program
    {
       // private static TcpListener tcpLsn;
        private static Socket socket;

        static void Main(string[] args)
        {
            Console.WriteLine("Conect client :)");
            conect();
            Console.WriteLine("Client sending");
            send("hi there I'm Salem :)");
            Console.ReadLine();
        }

        private static void conect() {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress hostadd = IPAddress.Parse("127.0.0.1");
            int port = 2222;

            IPEndPoint ipEndPoint = new IPEndPoint(hostadd,port);
            socket.Connect(ipEndPoint);
        }


        private static void send(string msg) {
            Byte[] byteData = Encoding.ASCII.GetBytes(msg.ToCharArray());
            socket.Send(byteData, byteData.Length, 0);
        }


    }
}
