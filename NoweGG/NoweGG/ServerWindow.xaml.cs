using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoweGG
{
    /// <summary>
    /// Interaction logic for GGServerWindow.xaml
    /// </summary>
    public partial class GGServerWindow : Window
    {
        public GGServerWindow()
        {
            InitializeComponent();
            GGServer = new GGServer(GGServer.IPCheck(), PortBlock.Text);
            IPBlock.Text = "Your IP address:" + GGServer.MyIP;
        }
        private GGServer GGServer=null;

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    User user = new User();
        //    user.TCPClient();
        //}

        private void CheckingButton_Click(object sender, RoutedEventArgs e)
        {
            IPBlock.Text = GGServer.Usrs.Count.ToString();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            MyTCP mytcp = new MyTCP(GGServer.MyIP, 51212, ref GGServer);
            Thread Thread1 = new Thread(new ThreadStart(mytcp.TcpListener));
            Thread1.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MyTCP mytcp = new MyTCP();
            User usr = new User("login", "password", 53);
            mytcp.TcpClient(usr);
        }
    }
}
