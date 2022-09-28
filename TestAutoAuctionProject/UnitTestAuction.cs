using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static AutoAuctionProjekt.Classes.Vehicle;
using AutoAuctionProjekt.Classes;


namespace TestAutoAuctionProject
{
    public class UnitTestAuction
    {
        DatabaseConnection connection = new DatabaseConnection();
        Database database = new AutoAuctionProjekt.Classes.Database();     

        [Fact]
        public void TestCreateAuction()
        {
            PrivateUser privateUser = new PrivateUser("John C. Kiwi", "1234", "1234", "124");
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
            database.DatabaseCreate(bus);
            database.DatabaseCreate(privateUser);
            List<Bus> busList = database.DatabaseGet(bus);
            List<PrivateUser> privateUsers = database.DatabaseGet(privateUser);
            bus.SetId(busList[busList.Count - 1].ID);
            privateUser.SetID(privateUsers[privateUsers.Count - 1].ID);
            Auction auction = new Auction(bus, privateUser, 0, DateTime.Now);
            auction.Buyer = privateUser;
            auction.Buyer.UserName = privateUser.UserName;

            List<Auction> auctions = new List<Auction>();
            int initCount = 0;
            
            try
            {
                auctions = database.DatabaseGet(auction);
                initCount = auctions.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                initCount = 1;
            }

            database.DatabaseCreate(auction);
            auctions = database.DatabaseGet(auction);
            auction.SetID(auctions[auctions.Count - 1].ID);
            Assert.True(auctions.Count == initCount + 1);

            TestDeleteAuction(auction);
            auctions = database.DatabaseGet(auction);

            Assert.True(auctions.Count == initCount);

            database.DatabaseDelete(busList[busList.Count - 1].ID,bus);
            database.DatabaseDelete(privateUsers[privateUsers.Count - 1].ID, privateUser);
        }

        public void TestDeleteAuction(Auction auction)
        {
            database.DatabaseDelete(auction.ID, auction);
        }

        [Fact]
        public void TestUpdateAuction()
        {
            PrivateUser privateUser = new PrivateUser("John C. Kiwi", "1234", "1234", "124");
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
            database.DatabaseCreate(bus);
            database.DatabaseCreate(privateUser);
            List<Bus> busList = database.DatabaseGet(bus);
            List<PrivateUser> privateUsers = database.DatabaseGet(privateUser);
            bus.SetId(busList[busList.Count - 1].ID);
            privateUser.SetID(privateUsers[privateUsers.Count - 1].ID);
            Auction auction = new Auction(bus, privateUser, 0, DateTime.Now);
            auction.Buyer = privateUser;
            auction.Buyer.UserName = privateUser.UserName;

            List<Auction> auctions = new List<Auction>();

            database.DatabaseCreate(auction);
            auctions = database.DatabaseGet(auction);
            auction.SetID(auctions[auctions.Count - 1].ID);
            Decimal newMinPrice = 1000000000;
            auction.MinimumPrice = newMinPrice;
            auction = database.DatabaseUpdate(auction);

            Assert.Equal(database.DatabaseSelect(auction.ID,auction).MinimumPrice, newMinPrice);
            database.DatabaseDelete(auction.ID, auction);

            database.DatabaseDelete(busList[busList.Count - 1].ID, bus);
            database.DatabaseDelete(privateUsers[privateUsers.Count - 1].ID, privateUser);
        }

        [Fact]
        public void TestAddBidToBidHistory()
        {
            PrivateUser privateUser = new PrivateUser("John C. Kiwi", "1234", "1234", "124");
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
            database.DatabaseCreate(bus);
            database.DatabaseCreate(privateUser);
            List<Bus> busList = database.DatabaseGet(bus);
            List<PrivateUser> privateUsers = database.DatabaseGet(privateUser);
            bus.SetId(busList[busList.Count - 1].ID);
            privateUser.SetID(privateUsers[privateUsers.Count - 1].ID);
            Auction auction = new Auction(bus, privateUser, 0, DateTime.Now);
            auction.Buyer = privateUser;
            auction.Buyer.UserName = privateUser.UserName;
            
            

        }
    }
}
