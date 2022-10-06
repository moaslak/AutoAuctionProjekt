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
            InitializeComponent();
            

            this.Auction = auction;
            this.User = user;
            BidBtn.Visibility = Visibility.Hidden;
            SellBtn.Visibility = Visibility.Hidden;
            if (this.Auction.ClosingDate.CompareTo(DateTime.Now) < 0)
            {
                this.Auction.CloseAuction();
                Database database = new Database();
                database.DatabaseUpdate(this.Auction);
            }
                

            if (Auction.Buyer.UserName == User.UserName && !(Auction.Closed))
            {

                BidBtn.Visibility = Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility = Visibility.Visible;
                SellBtn.Visibility = Visibility.Hidden;
            }
            if(Auction.Seller.UserName == User.UserName && !(Auction.Closed))
            {
                SellBtn.Visibility = Visibility.Visible;
                BidBtn.Visibility = Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility = Visibility.Hidden;
            }
            if(Auction.Buyer.UserName != User.UserName && !(Auction.Closed) && Auction.Seller.UserName != User.UserName)
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

            if(Auction.Seller.UserName == User.UserName)
            {
                SellBtn.Visibility = Visibility.Visible;
                BidBtn.Visibility= Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility= Visibility.Hidden;
            }
                
            auctionListBx.Items.Add(Auction);
            ClosingDateAndStandingBidList.Items.Add(Auction);
        }

        Auction Auction { get; set; }
        User User { get; set; }
        CorporateUser cUser { get; set; }
        PrivateUser pUser { get; set; }
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
            AuctionBid auctionBid = new AuctionBid(Auction, User.UserName);
            BidWindow bidWindow = new BidWindow(auctionBid, User, this);
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

            CorporateUser cBuyer = database.DatabaseSelect(Auction.Buyer.UserName, new CorporateUser("", "", "", "", 0));
            PrivateUser pBuyer = database.DatabaseSelect(Auction.Buyer.UserName, new PrivateUser("", "", "", ""));

            foreach(PrivateUser p in privateUsers)
            {
                if(p.UserName == User.UserName)
                {
                    PrivateUser privateUser = database.DatabaseSelect(User.UserName, new PrivateUser("","","",""));
                    privateUser.Balance = privateUser.Balance + Auction.StandingBid;
                    privateUser = database.DatabaseUpdate(privateUser);
                    if(cBuyer != null)
                    {
                        cBuyer.Balance = cBuyer.Balance - Auction.StandingBid;
                        cBuyer = database.DatabaseUpdate(cBuyer);
                    }
                    else if(pBuyer != null)
                    {
                        pBuyer.Balance = pBuyer.Balance - Auction.StandingBid;
                        pBuyer = database.DatabaseUpdate(pBuyer);
                    }
                }     
            }
            foreach (CorporateUser c in corporateUsers)
            {
                if (c.UserName == User.UserName)
                {
                    CorporateUser corporateUser = database.DatabaseSelect(User.UserName, new CorporateUser("", "", "", "",0));
                    corporateUser.Balance = corporateUser.Balance + Auction.StandingBid;
                    corporateUser = database.DatabaseUpdate(corporateUser);

                    if (cBuyer != null)
                    {
                        cBuyer.Balance = cBuyer.Balance - Auction.StandingBid;
                        cBuyer = database.DatabaseUpdate(cBuyer);
                    }
                    else if (pBuyer != null)
                    {
                        pBuyer.Balance = pBuyer.Balance - Auction.StandingBid;
                        pBuyer = database.DatabaseUpdate(pBuyer);
                    }
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
