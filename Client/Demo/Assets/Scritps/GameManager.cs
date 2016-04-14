using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using protobuf;
using ProtoBuf;
using UnityEngine;

public class GameManager 
{
    private static GameManager ms_instance = null;
    public static GameManager getInstance()
    {
        if (null == ms_instance)
        {
            ms_instance = new GameManager();
        }

        return ms_instance;
    }

    private Socket tcpClient;

    public void initialize()
    {
        Debug.Log("initialize()");

        tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPAddress address = IPAddress.Parse("192.168.31.160");
        EndPoint ed = new IPEndPoint(address, 8086);
        try
        {
            tcpClient.Connect(ed);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return;
        }

        Thread t = new Thread(Recv);
        t.Start();
    }

    private void Recv()
    {
        byte[] dataBuff = new byte[1024];
        int len = tcpClient.Receive(dataBuff);
        MemoryStream ms = new MemoryStream(dataBuff, 0, len);

        LoginRsp rsp = Serializer.Deserialize<LoginRsp>(ms);
        Debug.Log(string.Format("recv a message, rsp = {0}, ret={1}", rsp.ToString(), rsp.ret));

    }

    public void Send()
    {
        Debug.Log("start sending");
        LoginReq req = new LoginReq();
        System.Random random = new System.Random();
        req.uin = random.Next(10, 1000);
        req.login_type = 0;
        MemoryStream msReq = new MemoryStream();
        Serializer.Serialize<LoginReq>(msReq, req);

        tcpClient.Send(msReq.ToArray());
        Debug.Log(string.Format("Send(), req={0}, uin={1}, type={2}", req.ToString(), req.uin, req.login_type));
    }
}
