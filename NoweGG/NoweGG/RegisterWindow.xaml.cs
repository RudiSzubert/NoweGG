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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text == ConfirmBox.Text && LoginBox.Text.Length >3  && PasswordBox.Text != "" & NumberBox.Text.Length > 4)
            {
                User usr = new User(LoginBox.Text, PasswordBox.Text, Int32.Parse(NumberBox.Text));
                if (AgeBox.Text != "")
                {
                    usr.Age = Int32.Parse(AgeBox.Text);
                }
                if (CityBox.Text != "")
                {
                    usr.City = CityBox.Text;
                }
                if (CountryBox.Text != "")
                {
                    usr.City = CountryBox.Text;
                }
                if (NameBox.Text != "")
                {
                    usr.Name = NameBox.Text;
                }
                if (LastBox.Text != "")
                {
                    usr.LastName = LastBox.Text;
                }
                MyTCP mytcp = new MyTCP();
                mytcp.TcpClient(usr);
                var wind = new RgstredWindow();
                wind.Show();
                this.Close();
            }
            else if( PasswordBox.Text != ConfirmBox.Text)
            {
                AlertBlock.Text = "Password does not match";
            }
            

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            var wind = new UserWindow();
            wind.Show();
            this.Close();
        }
    }
}
