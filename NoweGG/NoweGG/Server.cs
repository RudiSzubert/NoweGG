using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NoweGG
{
    class Server
    {
        List<User> Usrs = new List<User>();

        private string myIP = null;

        public string MyIP
        {
            get
            {
                return myIP;
            }
            set
            {
                if (myIP == null)
                {
                    myIP = value;
                }
            }
        }

        private static string IPCheck()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public Server()
        {
            this.myIP = Server.IPCheck();
        }
    }
}
