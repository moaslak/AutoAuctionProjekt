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
            User.UserName += Convert.ToDecimal(balanceBox.Text);
            if(privateUser != null)
            {
                privateUser.Balance += Convert.ToDecimal(balanceBox.Text);
                database.DatabaseUpdate(privateUser);
            }
            else
            {
                corporateUser.Balance += Convert.ToDecimal(balanceBox.Text);
                database.DatabaseUpdate(corporateUser);
            }
            MessageBox.Show("Balance added " + balanceBox.Text);
        }
    }
}
