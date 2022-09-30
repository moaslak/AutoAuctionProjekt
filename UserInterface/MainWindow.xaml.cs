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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();
            this.User = user;
        }

        public MainWindow(User user, List<Auction> auctions)
        {
            InitializeComponent();
            this.User = user;
            this.Auctions = auctions;
                
            foreach (Auction auction in Auctions)
            {
                allAuctionListBx.Items.Add(auction);  
            }

                
                    
        }

        public User User { get; set; }
        public List<Auction> Auctions { get; set; }
        private Auction auction { get; set; } 

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

        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            //CreateAuction createAuction = new CreateAuction();
            SetForSaleWindow setForSaleWindow = new SetForSaleWindow(User);
            this.Hide();
            setForSaleWindow.Show();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void allAuctionListBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void bidHistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void profileBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
