using AutoAuctionProjekt.Classes;
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
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            CorporateUser corporateUser = new CorporateUser("", "", "", "", 0);
            
            if(PrivateUserRdBtn.IsChecked != null)
            {
                try
                {
                    database.DatabaseCreate(privateUser);
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Wrong", ex);
                }
            }
            else if(CorporateUserRdBtn.IsChecked != null)
            {
                try
                {
                    database.DatabaseCreate(corporateUser);
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Wrong", ex);
                }
            }
        }

        private void CancelNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();

        }

        private void UserNameTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RepeatPasswordTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
