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
        public MainWindow(User user)
        {
            InitializeComponent();
            this.User = user;
        }

        public MainWindow(User user, List<Auction> auctions, List<Auction> myAuctions)
        {
            InitializeComponent();
            this.User = user;
            this.Auctions = auctions;
            this.MyAuctions = myAuctions;

            Database database = new Database();
            /*Bus b = new Bus("4", 4, "4", 4, 4, false, 5, 5, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(4, 4, 4), 4, 4, Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, false);
            Bus b1 = new Bus("5", 5, "5", 5000, 5, false, 5, 5, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(4, 4, 4), 4, 4, Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, false);

            Bus b2 = database.DatabaseSelect(Auctions[0].Vehicle.ID,b);

            Auction a = new Auction(b, User, 500, DateTime.Now);
            Auction a1 = new Auction(b1, User, 500, DateTime.Now);
            Auction a2 = new Auction(b2, User, 500, DateTime.Now);
            List<Auction> list = new List<Auction>();
            list.Add(a1);
            list.Add(a);
            list.Add(a2);
            foreach(Auction auc in list)
            {
                allAuctionListBx.Items.Add(auc);
            }*/
            //auctionListBx.Items.Add(MyAuctions[0]);
            foreach(Auction a in MyAuctions)
            {
                auctionListBx.Items.Add(a);
            }
            foreach(Auction a in Auctions)
            {
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
