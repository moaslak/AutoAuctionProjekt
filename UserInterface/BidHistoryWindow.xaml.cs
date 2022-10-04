using AutoAuctionProjekt.Classes;
using System;
using System.CodeDom;
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
using static AutoAuctionProjekt.Classes.Vehicle;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for BidHistoryWindow.xaml
    /// </summary>
    public partial class BidHistoryWindow : Window
    {
        public BidHistoryWindow(User user)
        {
            InitializeComponent();
            this.User = user;
            Database database = new Database();
            this.AuctionBids = database.SelectAuctionBidHistory(User.UserName);
            
            foreach (AuctionBid ab in AuctionBids)
            {
                if (ab.Auction.Buyer.UserName == User.UserName && ab.Auction.Closed)
                    ab.Status = "WON";
                else if ((ab.Auction.Buyer.UserName != User.UserName && ab.Auction.Closed))
                    ab.Status = "Sold for " + ab.Auction.StandingBid.ToString();
                else
                    ab.Status = "";
                auctionBidsListBx.Items.Add(ab);
            }
                
            
        }

        public User User { get; set; }
        public List<AuctionBid> AuctionBids { get; set; }   

        private void auctionListBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow(User);
            mainWindow.Show();
        }
    }
}
