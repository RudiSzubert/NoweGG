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
        private MyTCP mytcp;
        public GGServerWindow()
        {
            InitializeComponent();
            GGServer = new GGServer(GGServer.IPCheck(), PortBlock.Text);
            IPShower.Text = "Your IP address:" + GGServer.MyIP;
            mytcp = new MyTCP(GGServer.MyIP, 51212, ref GGServer);
        }
        private GGServer GGServer=null;

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    User user = new User();
        //    user.TCPClient();
        //}

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            mytcp.Listening(mytcp);
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            mytcp.Disconnect();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var wind = new MainWindow();
            wind.Show();
            //this.Close();
        }
    }
}
