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
    /// Interaction logic for BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        public BuyerWindow(Auction auction, User user)
        {
            //TODO: Dynamic update window
            InitializeComponent();
            Database database = new Database();
            this.Auction = auction;
            this.User = user;
            BidBtn.Visibility = Visibility.Hidden;
            SellBtn.Visibility = Visibility.Hidden;
            if (Auction.Buyer.UserName == User.UserName && !(Auction.Closed) || Auction.Seller.UserName == User.UserName )
            {
                BidBtn.Visibility = Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility = Visibility.Visible;
                if (Auction.Seller.UserName == User.UserName)
                    SellBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BidBtn.Visibility = Visibility.Visible;
                CurrentHighBidderTextblock.Visibility = Visibility.Hidden;
                SellBtn.Visibility = Visibility.Hidden;
            }

            if(Auction.Seller.UserName != User.UserName || Auction.Buyer.UserName == "")
            {
                BidBtn.Visibility = Visibility.Visible;
                CurrentHighBidderTextblock.Visibility = Visibility.Hidden;
                SellBtn.Visibility = Visibility.Hidden;
            }

            if (Auction.Closed)
            {
                BidBtn.Visibility = Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility = Visibility.Visible;
                CurrentHighBidderTextblock.Text = "Auction is closed";
                SellBtn.Visibility = Visibility.Hidden;
            }
                
            auctionListBx.Items.Add(Auction);
            ClosingDateAndStandingBidList.Items.Add(Auction);
        }

        Auction Auction { get; set; }
        User User { get; set; }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(User);
            this.Close();
            mainWindow.Show();
        }

        private void auctionListBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BidBtn_Click(object sender, RoutedEventArgs e)
        {
            AuctionBid auctionBid = new AuctionBid(Auction, User);
            BidWindow bidWindow = new BidWindow(auctionBid, auctionBid.Bidder, this);
            bidWindow.Show();
        }

        private void ClosingDateAndBid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SellBtn_Click(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            User.Balance = User.Balance + Auction.StandingBid;

            List<PrivateUser> privateUsers = database.DatabaseGet(new PrivateUser("", "", "", ""));
            List<CorporateUser> corporateUsers = database.DatabaseGet(new CorporateUser("", "", "", "", 0));

            foreach(PrivateUser p in privateUsers)
            {
                if(p.UserName == User.UserName)
                {
                    PrivateUser privateUser = database.DatabaseSelect(User.UserName, new PrivateUser("","","",""));
                    privateUser.Balance = privateUser.Balance + Auction.StandingBid;
                    privateUser = database.DatabaseUpdate(privateUser);
                }     
            }
            foreach (CorporateUser c in corporateUsers)
            {
                if (c.UserName == User.UserName)
                {
                    CorporateUser corporateUser = database.DatabaseSelect(User.UserName, new CorporateUser("", "", "", "",0));
                    corporateUser.Balance = corporateUser.Balance + Auction.StandingBid;
                    corporateUser = database.DatabaseUpdate(corporateUser);
                }
            }
            Auction.CloseAuction();
            database.DatabaseUpdate(Auction);
            MessageBox.Show("Auction closed");
            this.Close();
            MainWindow mainWindow = new MainWindow(User);
            mainWindow.Show();
        }
    }
}
