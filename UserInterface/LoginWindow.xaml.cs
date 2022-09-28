using AutoAuctionProjekt.Classes;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public LoginWindow()
        {
            InitializeComponent();
            this.Show();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseConnection databaseConnection = new();
            Database database = new Database();
            PrivateUser privateUser = database.DatabaseSelect(UserTxtbox.Text, new PrivateUser("", "", "", ""));
            CorporateUser corporateUser = database.DatabaseSelect(UserTxtbox.Text, new CorporateUser("", "", "", "", 0));

            if (privateUser != null)
            {
                try
                {
                    privateUser.LoginOK(privateUser.UserName, privateUser.Password);
                    privateUser.ToString();

                    MainWindow mainWindow = new MainWindow();
                    this.Hide();
                    mainWindow.Show();
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Wrong login", ex);
                }
            }
            else if(corporateUser != null)
            {
                try
                {
                    corporateUser.LoginOK(corporateUser.UserName, corporateUser.Password);
                    corporateUser.ToString();
                    MainWindow mainWindow = new MainWindow();
                    this.Hide();
                    mainWindow.Show();
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Wrong login", ex);
                }
            }
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
