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
    /// Interaction logic for BidWindow.xaml
    /// </summary>
    public partial class BidWindow : Window
    {
        public BidWindow(AuctionBid auctionBid, User buyer, BuyerWindow buyerWindow)
        {
            InitializeComponent();
            this.AuctionBid = auctionBid;
            this.Buyer = buyer;
            this.BuyerWindow = buyerWindow;
        }

        AuctionBid AuctionBid { get; set; }
        User Buyer { get; set; }
        BuyerWindow BuyerWindow { get; set; }
        private void BidBtn_Click(object sender, RoutedEventArgs e)
        {
            AuctionBid.Bid(AuctionBid.Auction, Convert.ToDecimal(BidInput.Text));
            MessageBox.Show("Bid made");
            BuyerWindow newBuyerWindow = new BuyerWindow(AuctionBid.Auction, Buyer);
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
    }
}
