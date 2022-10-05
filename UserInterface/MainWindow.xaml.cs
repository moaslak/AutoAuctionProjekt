using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database database = new Database();
        public MainWindow(User user)
        {
            InitializeComponent();
            this.User = user;
            this.Auctions = database.DatabaseGet(auction);
            this.MyAuctions = database.DatabaseGetForUser(auction, User);

            foreach (Auction a in MyAuctions)
            {
                if (a.ClosingDate.CompareTo(DateTime.Now) < 0)
                {
                    a.CloseAuction();
                    database.DatabaseUpdate(a);
                }
                    

                if (!(a.Closed))
                    auctionListBx.Items.Add(a);
            }
            foreach (Auction a in Auctions)
            {
                if (a.ClosingDate.CompareTo(DateTime.Now) < 0)
                {
                    a.CloseAuction();
                    database.DatabaseUpdate(a);
                }

                if (!(a.Closed) && !(a.Seller.UserName == User.UserName || a.Buyer.UserName == User.UserName))
                    allAuctionListBx.Items.Add(a);
            }
        }

        public MainWindow(User user, List<Auction> auctions, List<Auction> myAuctions)
        {
            InitializeComponent();
            this.User = user;
            this.Auctions = auctions;
            this.MyAuctions = myAuctions;

            foreach (Auction a in MyAuctions)
            {
                if (a.ClosingDate.CompareTo(DateTime.Now) < 0)
                    a.CloseAuction();

                if (!(a.Closed))
                    auctionListBx.Items.Add(a);
            }
            foreach (Auction a in Auctions)
            {
                if (a.ClosingDate.CompareTo(DateTime.Now) < 0)
                    a.CloseAuction();

                if (!(a.Closed) && !(a.Seller.UserName == User.UserName || a.Buyer.UserName == User.UserName))
                    allAuctionListBx.Items.Add(a);
            }
        }

        public User User { get; set; }
        public List<Auction> Auctions { get; set; }
        public List<Auction> MyAuctions { get; set; }
        private Auction auction { get; set; }
        public object ItemsSource { get; }

        private void auctionBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void infoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void auctionListBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selectedAuction = auctionListBx.SelectedItem;
            BuyerWindow buyerWindow = new BuyerWindow((Auction)selectedAuction, User);
            this.Close();
            buyerWindow.Show();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            SetForSaleWindow setForSaleWindow = new SetForSaleWindow(User);
            this.Close();
            setForSaleWindow.Show();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void allAuctionListBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selectedAuction = allAuctionListBx.SelectedItem;
            BuyerWindow buyerWindow = new BuyerWindow((Auction)selectedAuction, User);
            this.Hide();
            buyerWindow.Show();
        }

        private void bidHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            BidHistoryWindow bidHistoryWindow = new BidHistoryWindow(User);
            bidHistoryWindow.Show();
        }

        private void profileBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ProfileWindow profileWindow = new ProfileWindow(User);
            profileWindow.Show();
        }
    }
}
