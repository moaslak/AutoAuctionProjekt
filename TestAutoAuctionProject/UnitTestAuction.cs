using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static AutoAuctionProjekt.Classes.Vehicle;
using AutoAuctionProjekt.Classes;
using System.Data.SqlClient;

namespace TestAutoAuctionProject
{
    public class UnitTestAuction
    {
        DatabaseConnection connection = new DatabaseConnection();
        Database database = new AutoAuctionProjekt.Classes.Database();

        PrivateUser privateUser = new PrivateUser("John C. Kiwi", "1234", "1234", "124");
        Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);


        [Fact]
        public void TestCreateAuction()
        {
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
            database.DatabaseCreate(bus);
            database.DatabaseCreate(privateUser);
            List<Bus> busList = database.DatabaseGet(bus);
            List<PrivateUser> privateUsers = database.DatabaseGet(privateUser);
            bus.SetId(busList[busList.Count - 1].ID);
            privateUser.SetID(privateUsers[privateUsers.Count - 1].ID);
            Auction auction = new Auction(bus, privateUser, 0, DateTime.Now);
            auction.Buyer = privateUser;
            auction.Seller = privateUser;
            database.DatabaseCreate(auction);
            List<Auction> auctions = database.DatabaseGet(auction);
            auction.SetID(auctions[auctions.Count - 1].ID);
            auction.Buyer = privateUser;
            auction.Buyer.UserName = privateUser.UserName;

            AuctionBid auctionBid = new AuctionBid(auction, privateUser);
            bool success = false;
            try
            {
                database.AddBidToHistory(auctionBid);
                success = true;
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            List<AuctionBid> auctionBids = database.GetAuctionBidHistory();
            Assert.True(auctionBids.Count > 0);
            Assert.True(success);

            database.DatabaseDelete(bus.ID, bus);
            database.DatabaseDelete(privateUser.ID, privateUser);
        }

        [Fact]
        public void TestBid()
        {
            //TODO: generate test auctions
            Auction auction = new Auction(bus, privateUser, 500, new DateTime(2023, 10, 10, 10, 10, 10));
            auction.Buyer = privateUser;
            database.DatabaseCreate(bus);
            database.DatabaseCreate(privateUser);
            List<Bus> busList = database.DatabaseGet(bus);
            List<PrivateUser> privateUsers = database.DatabaseGet(privateUser);
            bus.SetId(busList[busList.Count - 1].ID);
            privateUser.SetID(privateUsers[privateUsers.Count - 1].ID);

            //database.DatabaseCreate(auction);
            List<Auction> auctions = database.DatabaseGet(auction);
            auction = auctions[auctions.Count-1];

            auction = database.DatabaseSelect(14, auction);

            AuctionBid auctionBid = new AuctionBid(auction, privateUser);
            Decimal newBid = auction.StandingBid;
            auctionBid.Bid(auction, newBid);
            Assert.True(auction.StandingBid >= newBid);

            auction = database.DatabaseSelect(13, auction);
            newBid = auction.StandingBid+1;
            auctionBid.Auction = auction;
            auctionBid.Bid(auction, newBid);
            Assert.True(auctionBid.Auction.StandingBid == newBid);

            auction.ClosingDate = new DateTime(2000, 10, 10, 10, 10, 10, 10);
            auctionBid.Bid(auction, newBid);
            Assert.True(auctionBid.Auction == auction);


            database.DatabaseDelete(bus.ID, bus);
            database.DatabaseDelete(privateUser.ID, privateUser);
        }
    }
}
