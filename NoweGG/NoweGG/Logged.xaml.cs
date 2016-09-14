using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Logged.xaml
    /// </summary>
    public partial class Logged : Window
    {
        public Logged(User user)
        {
            InitializeComponent();
            listBox.Items.Add("asdasd");
            listBox.Items.Add("asdasd" + "43d32");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MyTCP mytcp = new MyTCP();
            List<User> list = new List<User>();
            list = mytcp.ForSearch();
            foreach (User user in list)
            {
                listBox.Items.Add(user.login);
            }
        }
    }
}
