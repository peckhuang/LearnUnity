using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using protobuf;
using ProtoBuf;

namespace Tcp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> lstClients = new List<Client>();

            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress address = new IPAddress(new byte[] { 192, 168, 31, 160 });
            EndPoint ep = new IPEndPoint(address, 8086);
            tcpServer.Bind(ep);

            tcpServer.Listen(100);

            while (true)
            {
                Socket clientSocket = tcpServer.Accept();
                Console.WriteLine("a client is connected !");
                Client client = new Client(clientSocket);
                lstClients.Add(client);
            }
        }
    }
}
