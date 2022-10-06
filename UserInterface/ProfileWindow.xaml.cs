using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        Database database = new Database();
        public ProfileWindow(User user)
        {
            InitializeComponent();
            this.User = user;
            this.MyAuctions = database.DatabaseGetForUser(auction, User);

            foreach (Auction a in MyAuctions)
            {
                auctionListBx.Items.Add(a);
            }

            balTotal.Text = user.Balance.ToString();

            
            CorporateUser corporateUser = new CorporateUser("", "", "", "", 0);
            corporateUser = database.DatabaseSelect(User.UserName, corporateUser);

            if(corporateUser != null)
            {
                CreditLabel.Visibility = Visibility.Visible;
                crdTxt.Visibility = Visibility.Visible;
                crdTxt.Text = corporateUser.Credit.ToString();
            }
            else
            {
                CreditLabel.Visibility = Visibility.Hidden;
                crdTxt.Visibility = Visibility.Hidden;
            }

        }

        public ProfileWindow(User user, List<Auction> myAuctions)
        {
            InitializeComponent();
            this.User = user;
            this.MyAuctions = myAuctions;

            foreach (Auction a in MyAuctions)
            {
                auctionListBx.Items.Add(a);
            }        
        }

        public User User { get; set; }
        public List<Auction> MyAuctions { get; set; }
        private Auction auction { get; set; }
        public object ItemsSource { get; }
        private void auctionListBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selectedAuction = auctionListBx.SelectedItem;
            BuyerWindow buyerWindow = new BuyerWindow((Auction)selectedAuction, User);
            this.Hide();
            buyerWindow.Show();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(User);
            this.Close();
            mainWindow.Show();
        }

        private void addBalBtn_Click(object sender, RoutedEventArgs e)
        {
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            CorporateUser corporateUser = new CorporateUser("", "", "", "", 0);
            privateUser = database.DatabaseSelect(User.UserName, privateUser);
            corporateUser = database.DatabaseSelect(User.UserName, corporateUser);
            if(privateUser != null)
            {
                if (balanceBox.Text == "")
                    balanceBox.Text = "0";
                privateUser.Balance += Convert.ToDecimal(balanceBox.Text);
                database.DatabaseUpdate(privateUser);
                balTotal.Text = privateUser.Balance.ToString();
            }
            else
            {
                if (balanceBox.Text == "")
                    balanceBox.Text = "0";
                corporateUser.Balance += Convert.ToDecimal(balanceBox.Text);
                database.DatabaseUpdate(corporateUser);
                balTotal.Text = corporateUser.Balance.ToString();
            }

            MessageBox.Show("Balance added " + balanceBox.Text);
        }

        private void chPssBtn_Click(object sender, RoutedEventArgs e)
        {
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            CorporateUser corporateUser = new CorporateUser("", "", "", "", 0);
            corporateUser = database.DatabaseSelect(User.UserName, corporateUser);
            privateUser = database.DatabaseSelect(User.UserName, privateUser);

            if (chPassBox.Password == User.Password && reChPassBox.Password != User.Password && reChPassBox.Password == ConfirmBox.Password)
            {
                if (corporateUser != null)
                {
                    corporateUser.Password = reChPassBox.Password;
                    database.DatabaseUpdate(corporateUser);
                    this.User = corporateUser;
                }                    
                else
                {
                    privateUser.Password = reChPassBox.Password;
                    database.DatabaseUpdate(privateUser);
                    this.User = privateUser;
                }
                chPassBox.Clear();
                reChPassBox.Clear();
                ConfirmBox.Clear();
                MessageBox.Show("Password updated");
            }
            else
                MessageBox.Show("Current pass does not match or new password is not confirmed!!!");
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
