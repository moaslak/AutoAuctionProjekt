﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database
    {
        /// <summary>
        /// Adds an entry to the Auction bid history table
        /// </summary>
        /// <param name="auction"></param>
        /// <param name="bidder"></param>
        public void AddBidToHistory(AuctionBid auctionBid)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.AddBid", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuctionID", SqlDbType.Int).Value = auctionBid.Auction.ID;
            cmd.Parameters.Add("@CurrentHighestBidder", SqlDbType.VarChar).Value = auctionBid.Bidder;
            cmd.Parameters.Add("@StandingBid", SqlDbType.Decimal).Value = auctionBid.Auction.StandingBid;
            cmd.Parameters.Add("@BidDate", SqlDbType.DateTime).Value = auctionBid.BidDate;
            string status = auctionBid.Status;
            if (status == null)
                status = "";
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;

            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            connection.Close();
        }

        public List<AuctionBid> GetAuctionBidHistory()
        {
            List<AuctionBid> list = new List<AuctionBid>();
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 5, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, false);
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            DateTime dateTime = Convert.ToDateTime("2022-10-10 00:00:00.000");
            Auction auction = new Auction(bus, privateUser, 0, dateTime);
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetAuctionBidHistory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AuctionBid auctionBid = new AuctionBid(auction, privateUser.UserName);
                auctionBid.SetID(Convert.ToUInt16(reader.GetValue(0)));
                auctionBid.Auction.SetID(Convert.ToUInt16(reader.GetValue(1)));
                auctionBid.Bidder = reader.GetValue(2).ToString();
                auctionBid.Auction.StandingBid = Convert.ToDecimal(reader.GetValue(3));
                auctionBid.BidDate = Convert.ToDateTime(reader.GetValue(4));
                bool status = Convert.ToBoolean(reader.GetValue(5));
                if (status)
                    auctionBid.Auction.CloseAuction();              
                else
                    auctionBid.Auction.OpenAuction();
                list.Add(auctionBid);
            }
            connection.Close();
            return list;
        }

        public List<AuctionBid> SelectAuctionBidHistory(uint AuctionID)
        {
            List<AuctionBid> list = new List<AuctionBid>();
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 5, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, false);
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            DateTime dateTime = Convert.ToDateTime("2022-10-10 00:00:00.000");
            Auction auction = new Auction(bus, privateUser, 0, dateTime);
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectAuctionBidHistoryByAuctionID", connection);
            cmd.Parameters.Add("@AuctionID", SqlDbType.Int).Value = AuctionID;
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AuctionBid auctionBid = new AuctionBid(auction, privateUser.UserName);
                auctionBid.SetID(Convert.ToUInt16(reader.GetValue(0)));
                auctionBid.Auction.SetID(Convert.ToUInt16(reader.GetValue(1)));
                auctionBid.Bidder = reader.GetValue(2).ToString();
                auctionBid.Auction.StandingBid = Convert.ToDecimal(reader.GetValue(3));
                auctionBid.BidDate = Convert.ToDateTime(reader.GetValue(4));
                bool status = Convert.ToBoolean(reader.GetValue(5));
                if (status)
                    auctionBid.Auction.CloseAuction();
                else
                    auctionBid.Auction.OpenAuction();
                list.Add(auctionBid);
            }
            connection.Close();
            return list;
        }

        public List<AuctionBid> SelectAuctionBidHistory(string username)
        {
            List<AuctionBid> list = new List<AuctionBid>();
            
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectAuctionBidHistoryByUsername", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bus bus = new Bus("", 0, "", 0, 0, false, 5, 5, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, false);
                PrivateUser privateUser = new PrivateUser("", "", "", "");
                DateTime dateTime = Convert.ToDateTime("2022-10-10 00:00:00.000");
                Auction auction = new Auction(bus, privateUser, 0, dateTime);
                AuctionBid auctionBid = new AuctionBid(auction, privateUser.UserName);
                auctionBid.SetID(Convert.ToUInt16(reader.GetValue(0)));
                auctionBid.Auction.SetID(Convert.ToUInt16(reader.GetValue(1)));
                auctionBid.Bidder = reader.GetValue(2).ToString();
                auctionBid.Auction.StandingBid = Convert.ToDecimal(reader.GetValue(3));
                auctionBid.BidDate = Convert.ToDateTime(reader.GetValue(4));
                auctionBid.Status = reader.GetValue(5).ToString();
                
                list.Add(auctionBid);
            }
            connection.Close();
            
            for(int i = 0; i < list.Count; i++)
            {
                list[i].Auction = DatabaseSelect(list[i].Auction.ID, list[i].Auction);
            }
            return list;
        }
    }
}
