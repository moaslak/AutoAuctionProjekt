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
            PrivateUserRdBtn.IsChecked = true;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            CorporateUser corporateUser = new CorporateUser("", "", "", "", 0);
            
            if(PrivateUserRdBtn.IsChecked != null)
            {
                try
                {
                    privateUser.UserName = UserNameTxtbox.Text;
                    privateUser.Password = CreatePasswordTxtbox.Password;
                    privateUser.CPRNumber = UserNameTxtbox.Text;
                    privateUser.Zipcode = ZipcodeTextBox.Text;
                    privateUser.Balance = 0;

                    if (privateUser.Password == RepeatPasswordTxtBox.Password)
                    {
                        database.DatabaseCreate(privateUser);
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Passwords are not the same!!!");
                    
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
                    corporateUser.UserName = UserNameTxtbox.Text;
                    corporateUser.Password = CreatePasswordTxtbox.Password;
                    corporateUser.CVRNumber = UserNameTxtbox.Text;
                    corporateUser.Zipcode = ZipcodeTextBox.Text;
                    corporateUser.Balance = 0;
                    corporateUser.Credit = Convert.ToDecimal(CreditTxtBox.Text);
                    if (corporateUser.Password == RepeatPasswordTxtBox.Password)
                    {
                        database.DatabaseCreate(corporateUser);
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Passwords are not the same!!!");
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

        private void PrivateUserRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(PrivateUserRdBtn.IsChecked == true)
            {
                CVRlbl.Visibility = Visibility.Hidden;
                CreditLbl.Visibility = Visibility.Hidden;
                CreditTxtBox.Visibility = Visibility.Hidden;
                CorporateUserRdBtn.IsChecked = false;

                CPRlbl.Visibility = Visibility.Visible;
            }
        }

        private void CorporateUserRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (CorporateUserRdBtn.IsChecked == true)
            {
                CPRlbl.Visibility = Visibility.Hidden;
                PrivateUserRdBtn.IsChecked = false;

                CVRlbl.Visibility = Visibility.Visible;
                CreditLbl.Visibility = Visibility.Visible;
                CreditTxtBox.Visibility = Visibility.Visible;

            }
        }
    }
}
