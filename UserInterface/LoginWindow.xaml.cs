using AutoAuctionProjekt.Classes;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;
using System.Collections.Generic;

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
            Database database = new Database();
            try
            {
                PrivateUser privateUser = database.DatabaseSelect(UserTxtbox.Text, new PrivateUser("", "", "", ""));
                CorporateUser corporateUser = database.DatabaseSelect(UserTxtbox.Text, new CorporateUser("", "", "", "", 0));
                Auction auction = null;
                List<Auction> auctions = database.DatabaseGet(auction);
                if (privateUser != null)
                {
                    try
                    {
                        privateUser = database.DatabaseSelect(UserTxtbox.Text, privateUser);
                        //privateUser.LoginOK(privateUser.UserName, privateUser.Password);
                        List<Auction> myAuctions = database.DatabaseGetForUser(auction, privateUser);
                        MainWindow mainWindow = new MainWindow(privateUser, auctions, myAuctions);
                        this.Hide();
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {

                        throw new ArgumentException("Wrong login", ex);
                    }
                }
                else if (corporateUser != null)
                {
                    try
                    {
                        corporateUser = database.DatabaseSelect(UserTxtbox.Text, corporateUser);
                        //corporateUser.LoginOK(corporateUser.UserName, corporateUser.Password);
                        List<Auction> myAuctions = database.DatabaseGetForUser(auction, corporateUser);
                        MainWindow mainWindow = new MainWindow(corporateUser, auctions, myAuctions);
                        this.Hide();
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {

                        throw new ArgumentException("Wrong login", ex);
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
