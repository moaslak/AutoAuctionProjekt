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
            List<AuctionBid> auctionBids = database.SelectAuctionBidHistory(User.UserName);
            if(auctionBids.Count > 0)
            {
                List<Auction> auctions = database.DatabaseGetForUser(auctionBids[0].Auction, User);
                
                Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
                Truck truck = new Truck("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), EnergyClassEnum.A, DriversLisenceEnum.A, 0);
                PrivatePersonalCar privatePersonalCar = new PrivatePersonalCar("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, 0, new PersonalCar.TrunkDimentionsStruct(0, 0, 0), false, DriversLisenceEnum.A, EnergyClassEnum.A);
                ProfessionalPersonalCar professionalPersonalCar = new ProfessionalPersonalCar("", 0, "", 0, 5, 5, 5, FuelTypeEnum.Diesel, 0, new PersonalCar.TrunkDimentionsStruct(0, 0, 0), false, 0, DriversLisenceEnum.A, EnergyClassEnum.A);
                List<Bus> buses = database.DatabaseGet(bus);
                List<Truck> trucks = database.DatabaseGet(truck);
                List<PrivatePersonalCar> privatePersonalCars = database.DatabaseGet(privatePersonalCar);
                List<ProfessionalPersonalCar> professionalPersonalCars = database.DatabaseGet(professionalPersonalCar);

                List<uint> busIDs = new List<uint>();
                List<uint> truckIDs = new List<uint>();
                List<uint> privateCarIDs = new List<uint>();
                List<uint> profCarIDs = new List<uint>();

                foreach (Bus b in buses)
                    busIDs.Add(b.ID);
                foreach (Truck t in trucks)
                    truckIDs.Add(t.ID);
                foreach (PrivatePersonalCar p in privatePersonalCars)
                    privateCarIDs.Add(p.ID);
                foreach (ProfessionalPersonalCar professional in professionalPersonalCars)
                    profCarIDs.Add(professional.ID);

                foreach (Auction a in auctions)
                {
                    if (busIDs.Contains(a.Vehicle.ID))
                    {
                        a.Vehicle = database.DatabaseSelect(a.Vehicle.ID, bus);
                    }
                    if (truckIDs.Contains(a.Vehicle.ID))
                    {
                        a.Vehicle = database.DatabaseSelect(a.Vehicle.ID, truck);
                    }
                    if (privateCarIDs.Contains(a.Vehicle.ID))
                    {
                        a.Vehicle = database.DatabaseSelect(a.Vehicle.ID, privatePersonalCar);
                    }
                    if (profCarIDs.Contains(a.Vehicle.ID))
                    {
                        a.Vehicle = database.DatabaseSelect(a.Vehicle.ID, professionalPersonalCar);
                    }
                }

                for(int j = 0; j < auctionBids.Count; j++)
                {
                    for(int i = 0; i < auctions.Count; i++)
                    {
                        if (auctionBids[j].Auction.ID == auctions[i].ID)
                            auctionBids[j].Auction.Vehicle = auctions[i].Vehicle;
                    }
                }

                foreach (AuctionBid ab in auctionBids)
                    auctionBidsListBx.Items.Add(ab);
            }
        }

        public User User { get; set; }

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
