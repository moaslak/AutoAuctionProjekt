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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.Show();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            createUserWindow.Show();
            this.Close();
        }

        private void UserTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
