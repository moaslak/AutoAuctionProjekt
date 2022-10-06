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
    /// Interaction logic for BidWindow.xaml
    /// </summary>
    public partial class BidWindow : Window
    {
        public BidWindow(AuctionBid auctionBid, User user, BuyerWindow buyerWindow)
        {
            InitializeComponent();
            this.AuctionBid = auctionBid;
            this.User = user;
            this.BuyerWindow = buyerWindow;
        }

        AuctionBid AuctionBid { get; set; }
        PrivateUser pBuyer { get; set; }
        CorporateUser cBuyer { get; set; }
        User User { get; set; }
        BuyerWindow BuyerWindow { get; set; }

        private void BidBtn_Click(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            pBuyer = database.DatabaseSelect(User.UserName, pBuyer);
            cBuyer = database.DatabaseSelect(User.UserName, cBuyer);
            bool fundsOK = false;
            if( AuctionBid.Auction.ClosingDate.CompareTo(AuctionBid.BidDate) < 0)
            {
                AuctionBid.Auction.CloseAuction();
                database.DatabaseUpdate(this.AuctionBid.Auction);
            }
                
            if (cBuyer != null)
            {

                if ((cBuyer.Balance + cBuyer.Credit) < Convert.ToDecimal(BidInput.Text) && AuctionBid.Auction.Closed == false)
                    MessageBox.Show("Not enough money!!");
                else if (AuctionBid.Auction.StandingBid >= Convert.ToDecimal(BidInput.Text) || AuctionBid.Auction.MinimumPrice > Convert.ToDecimal(BidInput.Text))
                    MessageBox.Show("To low bid");
                else
                    fundsOK = true;
                User = cBuyer;
            }
            else
            {
                if (pBuyer.Balance < Convert.ToDecimal(BidInput.Text) || AuctionBid.Auction.StandingBid > Convert.ToDecimal(BidInput.Text)
                    && AuctionBid.Auction.Closed == false)
                    MessageBox.Show("Not enough money!!!");
                else if (AuctionBid.Auction.StandingBid >= Convert.ToDecimal(BidInput.Text) || AuctionBid.Auction.MinimumPrice > Convert.ToDecimal(BidInput.Text))
                    MessageBox.Show("To low bid");
                else
                    fundsOK = true;
                User = pBuyer;
            }

            if (fundsOK && AuctionBid.Auction.Closed == false) 
            {
                AuctionBid.Bid(AuctionBid.Auction, Convert.ToDecimal(BidInput.Text));
                MessageBox.Show("Bid made");
            }
            else
                MessageBox.Show("No bid made");
            

            BuyerWindow newBuyerWindow = new BuyerWindow(AuctionBid.Auction, User);
            BuyerWindow.Close();
            this.Close();
            newBuyerWindow.Show();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BidInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "," && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;

        }
    }
}
