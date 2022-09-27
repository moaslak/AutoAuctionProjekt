using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using static AutoAuctionProjekt.Classes.Vehicle;
using System.Xml.Linq;

namespace AutoAuctionProjekt.Classes.Database
{
    partial class Database : IDatabase<Auction>
    {
        public void DatabaseCreate(Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.CreateAucion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public void DatabaseDelete(uint i, Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeleteAucion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public List<Auction> DatabaseGet(Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetAucions", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public Auction DatabaseSelect(uint id, Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectAucion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Bus bus = new Bus("",0,"",0,0,false,5,0,FuelTypeEnum.Diesel,new HeavyVehicle.VehicleDimensionsStruct(0,0,0),0,0,EnergyClassEnum.A,DriversLisenceEnum.A,false);
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            Auction auction = new Auction(bus,privateUser,0);
            while (reader.Read())
            {
                auction.Vehicle.SetId(Convert.ToUInt16(reader.GetValue(1)));
                auction.Seller.UserName = reader.GetValue(2).ToString();
                auction.Buyer.UserName = reader.GetValue(3).ToString();
                auction.MinimumPrice = Convert.ToDecimal(reader.GetValue(4));
                auction.StandingBid = Convert.ToDecimal(reader.GetValue(5));
                auction.ClosingDate = Convert.ToDateTime(reader.GetValue(6));
                auction.Closed = Convert.ToBoolean(reader.GetValue(7));
            }
            connection.Close();

            auction.Vehicle = DatabaseSelect(auction.Vehicle.ID, auction.Vehicle);

            return auction;
        }

        public Auction DatabaseUpdate(Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdateAucion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        }
    }
}
