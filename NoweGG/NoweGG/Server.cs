using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace NoweGG
{
    /*
    class SocketHelper
    {
        TcpClient mscClient;
        string mstrMessage;
        string mstrResponse;
        byte[] bytesSent;
        public void processMsg(TcpClient client, NetworkStream stream, byte[] bytesReceived)
        {
            // Handle the message received and 
            // send a response back to the client.
            mstrMessage = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length);
            mscClient = client;
            //mstrMessage = mstrMessage.Substring(0, 5);
            //if (mstrMessage.Equals("Hello"))
            //{
            //    mstrResponse = "Goodbye";
            //}
            //else
            //{
            //    mstrResponse = "What?";
            //}
            bytesSent = Encoding.ASCII.GetBytes(mstrResponse);
            stream.Write(bytesSent, 0, bytesSent.Length);
        }
    }
    */

    internal class GGServer
    {
        private string myIP;

        public List<User> Usrs = new List<User>();

        public GGServer(string ip, string port)
        {
            myIP = IPCheck();
            this.LoadList();
        }

        public string MyIP
        {
            get { return myIP; }
            set
            {
                if (myIP == null)
                    myIP = value;
            }
        }

        public void ListToFile()
        {
            var dir = @"c:\test\Na repy\gg\NoweGG";
            var SFile = Path.Combine(dir, "Users.bin");
            using (Stream stream = File.Open(SFile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this.Usrs);
            }
        }


        public void LoadList()
        {
            var dir = @"c:\test\Na repy\gg\NoweGG";
            var SFile = Path.Combine(dir, "Users.bin");
            using (Stream stream = File.Open(SFile, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                this.Usrs = (List<User>) bformatter.Deserialize(stream);
            }
        }

        public static string IPCheck()
        {
            IPHostEntry host;
            var localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    localIP = ip.ToString();
            return localIP;
        }
    }
}