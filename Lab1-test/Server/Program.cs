using System;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Program
    {
        private static TcpListener tcpLsn;
        private static Socket socket;

        static void Main(string[] args)
        {
            Console.WriteLine("Start server ...");
            serwuj();

            Console.ReadLine();
        }

        private static void serwuj() {
            tcpLsn = new TcpListener(IPAddress.Parse("127.0.0.1"), 2222);
            tcpLsn.Start();  // START *******************
            socket = tcpLsn.AcceptSocket(); // fun. blokująca az do momentu nadejszcia polacien

            Byte[] receiveByte = new Byte[100];
            int ret = socket.Receive(receiveByte, receiveByte.Length, 0);
            string tmp = null;
            tmp = System.Text.Encoding.ASCII.GetString(receiveByte);
            if(tmp.Length > 0)
            {
                Console.WriteLine("Odebrałem komunikat ");
                Console.WriteLine(tmp);
            }

            tcpLsn.Stop(); // STOP ******************
        }
    }
}
