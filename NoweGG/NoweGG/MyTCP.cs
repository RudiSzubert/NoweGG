using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace NoweGG
{
    internal class MyTCP
    {
        private  GGServer ggserver;

        private string MyIP = "192.168.1.229";

        private int MyPort = 51212;

        private User user;

        public MyTCP()
        {
        }

        public MyTCP(ref GGServer ggserv)
        {
            ggserver = ggserv;
        }

        public MyTCP(ref User usr)
        {
            this.user = usr;
        }

        public MyTCP(string ip, int port)
        {
            MyIP = ip;
            MyPort = port;
        }

        public MyTCP(string ip, int port, ref GGServer ggserv)
        {
            MyIP = ip;
            MyPort = port;
            ggserver = ggserv;
        }

        public MyTCP(string ip, int port, ref User usr)
        {
            MyIP = ip;
            MyPort = port;
            this.user = usr;
        }

        public void TcpClient(User user)
        {
            var client = new TcpClient();
            client.Connect(MyIP, MyPort);
            var stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, user);
            stream.Close();
            client.Close();
        }

        public void TcpClient(Message message)
        {
            var client = new TcpClient();
            client.Connect(MyIP, MyPort);
            var stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, message);
            stream.Close();
            client.Close();
        }

        //public static byte[] SerializeTo(object Object)
        //{
        //    var stream = new MemoryStream();
        //    IFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(stream, Object);
        //    return stream.ToArray();
        //}

        //public static object DeserializeFromByte(byte[] bytes)
        //{
        //    Stream stream = new MemoryStream(bytes);
        //    IFormatter formatter = new BinaryFormatter();
        //    stream.Seek(0, SeekOrigin.Begin);
        //    var Object = formatter.Deserialize(stream);
        //    return Object;
        //}

        public void TcpListener()
        {
            TcpListener _Listener = null;
            try
            {
                _Listener = new TcpListener(IPAddress.Parse(MyIP), MyPort);
                _Listener.Start();
                var bytes = new byte[256];
                string data = null;
                while (true)
                {
                    Thread.Sleep(100);
                    var client = _Listener.AcceptTcpClient();
                    var stream = client.GetStream();
                    IFormatter formatter = new BinaryFormatter();
                    var obj = formatter.Deserialize(stream);
                    if (obj.GetType() == typeof(Message))
                    {
                        var msgg = (Message) obj;
                        foreach (User usr in ggserver.Usrs)
                        {
                            if(msgg.From.Equals(usr))
                                usr.SaveMessage(msgg);
                        }
                    }
                    else if (obj.GetType() == typeof(User))
                    {
                        var usr = (User) obj;
                        ggserver.Usrs.Add(usr);
                        ggserver.ListToFile();
                    }
                    client.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.ReadLine();
            }

            finally
            {
                _Listener.Stop();
            }
        }
    }
}