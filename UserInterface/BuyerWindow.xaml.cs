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
            this.Auction = auction;
            this.User = user;
            BidBtn.Visibility = Visibility.Hidden;
            if (Auction.Buyer.UserName == User.UserName)
            {
                BidBtn.Visibility = Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility = Visibility.Visible;
            }
                
            
            else
            {
                BidBtn.Visibility = Visibility.Visible;
                CurrentHighBidderTextblock.Visibility = Visibility.Hidden;
            }
                
            
            if (Auction.Closed)
            {
                BidBtn.Visibility = Visibility.Hidden;
                CurrentHighBidderTextblock.Visibility = Visibility.Visible;
                CurrentHighBidderTextblock.Text = "Auction is closed";
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
            BidWindow bidWindow = new BidWindow(auctionBid, auctionBid.Bidder);
            bidWindow.Show();
        }

        private void ClosingDateAndBid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
