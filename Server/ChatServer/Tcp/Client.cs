using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using protobuf;
using ProtoBuf;

namespace Tcp
{
    class Client
    {
        protected Socket m_socket;

        protected Thread t;

        public Client(Socket s)
        {
            m_socket = s;
            t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                //在接收数据之前  判断一下socket连接是否断开
                if (m_socket.Poll(10, SelectMode.SelectRead))
                {
                    m_socket.Close();
                    Console.WriteLine("a client is close.");
                    break;//跳出循环 终止线程的执行
                }

                byte[] dataBuff = new byte[1024];
                int len = m_socket.Receive(dataBuff);
                if (len > 0)
                {
                    MemoryStream msReq = new MemoryStream(dataBuff, 0, len);

                    LoginReq req = Serializer.Deserialize<LoginReq>(msReq);
                    Console.WriteLine("req = {0}, uin={1}", req.ToString(), req.uin);

                    

                    try
                    {
                        LoginRsp rsp = new LoginRsp();
                        Random random = new Random();
                        rsp.ret = random.Next(10, 1000);
                        MemoryStream msRsp = new MemoryStream();
                        Serializer.Serialize<LoginRsp>(msRsp, rsp);
                        m_socket.Send(msRsp.ToArray());

                        Console.WriteLine("send a message to client, ret={0}", rsp.ret);
                    }
                    catch (Exception e)
                    {
                        
                        Console.WriteLine(e.ToString());
                    }
                    
                }
           
            }
        }
    }
}
