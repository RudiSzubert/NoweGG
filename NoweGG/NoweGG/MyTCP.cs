using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace NoweGG
{
    internal class MyTCP
    {
        private readonly GGServer ggserver;

        private readonly string MyIP = "192.168.1.229";

        private readonly int MyPort = 51212;

        private Thread thread1;

        public MyTCP()
        {
        }

        public MyTCP(ref GGServer ggserv)
        {
            ggserver = ggserv;
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

        public void Listening(MyTCP mytcp)
        {
            thread1 = new Thread(mytcp.TcpListener);
            thread1.Start();
        }

        public void Disconnect()
        {
            thread1.Abort();
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

        public bool Login(string login, string password, ref User usr, ref string answer)
        {
            var client = new TcpClient();
            client.Connect(MyIP, MyPort);
            var stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();
            var log = new string[2];
            log[0] = login;
            log[1] = password;
            formatter.Serialize(stream, log);
            var obj = formatter.Deserialize(stream);
            if (obj.GetType() == typeof(User))
            {
                usr = (User) obj;
                return true;
            }
            else if (obj.GetType() == typeof(string))
            {
                if ((string) obj == "1")
                    answer = "Password is incorrect";
                else if ((string) obj == "2")
                    answer = "Login is incorrect";
                return false;
            }
            else return false;
        }

        public List<User> ForSearch()
        {
            var client = new TcpClient();
            client.Connect(MyIP, MyPort);
            var stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();
            int messg = 1;
            formatter.Serialize(stream,messg);
            List<User> UsrList = (List<User>)formatter.Deserialize(stream);
            return UsrList;
        }

        public void TcpListener()
        {
            TcpListener _Listener = null;
            try
            {
                _Listener = new TcpListener(IPAddress.Parse(MyIP), MyPort);
                _Listener.Start();
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
                        foreach (var usr in ggserver.Usrs)
                            if (msgg.From.Equals(usr))
                                usr.SaveMessage(msgg);
                    }
                    else if (obj.GetType() == typeof(User))
                    {
                        var usr = (User) obj;
                        ggserver.Usrs.Add(usr);
                        ggserver.ListToFile();
                    }
                    else if (obj.GetType() == typeof(string[]))
                    {
                        var log = new string[2];
                        log = (string[]) obj;
                        var helper = false;
                        var msg = "1";
                        foreach (var usr in ggserver.Usrs)
                            if (usr.login == log[0])
                                if (usr.password == log[1])
                                {
                                    helper = true;
                                    formatter.Serialize(stream, usr);
                                }
                                else
                                {
                                    formatter.Serialize(stream, msg);
                                    break;
                                }
                            else if (helper)
                                break;
                        if (helper == false)
                        {
                            msg = "2";
                            formatter.Serialize(stream, msg);
                        }
                    }
                    else if (obj.GetType() == typeof(int))
                    {
                        if ((int) obj == 1)
                        {
                            formatter.Serialize(stream,this.ggserver.Usrs);
                        }
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