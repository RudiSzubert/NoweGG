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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            var wind = new RegisterWindow();
            wind.Show();
            this.Close();
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            var wind = new MainWindow();
            wind.Show();
            this.Close();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User("login","password", 123);
            string answer = null;
            MyTCP mytcp = new MyTCP();
            mytcp.Login(LoginBox.Text, PasswordBox.Text, ref user, ref answer);
        }
    }
}
