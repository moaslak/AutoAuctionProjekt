using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using static AutoAuctionProjekt.Classes.Vehicle;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<Auction>
    {
        public void DatabaseCreate(Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.CreateAuction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = type.Vehicle.ID;
            cmd.Parameters.Add("@Seller", SqlDbType.VarChar).Value = type.Seller.UserName;
            if (type.Buyer == null)
                cmd.Parameters.Add("@Buyer", SqlDbType.VarChar).Value = "";
            else
                cmd.Parameters.Add("@Buyer", SqlDbType.VarChar).Value = type.Buyer.UserName;
            cmd.Parameters.Add("@MinimumPrice", SqlDbType.Decimal).Value = type.MinimumPrice;
            cmd.Parameters.Add("@StandingBid", SqlDbType.Decimal).Value = type.StandingBid;
            cmd.Parameters.Add("@ClosingDate", SqlDbType.DateTime).Value = type.ClosingDate;
            cmd.Parameters.Add("Closed", SqlDbType.Bit).Value = type.Closed;

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

        public void DatabaseDelete(uint Id, Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeleteAuction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("SQL ERROR!!!");
            }
        }

        public List<Auction> DatabaseGet(Auction type)
        {
            List<Auction> auctions = new List<Auction>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetAuctions", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bus b = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
                PrivateUser privateUser = new PrivateUser("", "", "", "");
                Auction auction = new Auction(b, privateUser, 0, DateTime.Now);
                auction.Buyer = privateUser;
                auction.SetID(Convert.ToUInt16(reader.GetValue(0)));
                auction.Vehicle.SetId(Convert.ToUInt16(reader.GetValue(1)));
                auction.Seller.UserName = reader.GetValue(2).ToString();
                auction.Buyer.UserName = reader.GetValue(3).ToString();
                auction.MinimumPrice = Convert.ToDecimal(reader.GetValue(4));
                auction.StandingBid = Convert.ToDecimal(reader.GetValue(5));
                auction.ClosingDate = Convert.ToDateTime(reader.GetValue(6));
                bool closed = Convert.ToBoolean(reader.GetValue(7));

                if (closed)
                    auction.CloseAuction();
                else
                    auction.OpenAuction();
                auctions.Add(auction);
            }
            connection.Close();
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
            Truck truck = new Truck("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), EnergyClassEnum.A, DriversLisenceEnum.A, 0);
            PrivatePersonalCar privatePersonalCar = new PrivatePersonalCar("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, 0, new PersonalCar.TrunkDimentionsStruct(0, 0, 0), false, DriversLisenceEnum.A, EnergyClassEnum.A);
            ProfessionalPersonalCar professionalPersonalCar = new ProfessionalPersonalCar("", 0, "", 0, 5, 5, 5, FuelTypeEnum.Diesel, 0, new PersonalCar.TrunkDimentionsStruct(0, 0, 0), false, 0, DriversLisenceEnum.A, EnergyClassEnum.A);
            List<Bus> buses = DatabaseGet(bus);
            List<Truck> trucks = DatabaseGet(truck);
            List<PrivatePersonalCar> privatePersonalCars = DatabaseGet(privatePersonalCar);
            List<ProfessionalPersonalCar> professionalPersonalCars = DatabaseGet(professionalPersonalCar);

            List<uint> busIDs = new List<uint>();
            List<uint> truckIDs = new List<uint>();
            List<uint> privateCarIDs = new List<uint>();
            List<uint> profCarIDs = new List<uint>();
            
            foreach(Bus b in buses)
                busIDs.Add(b.ID);
            foreach(Truck t in trucks)
                truckIDs.Add(t.ID);
            foreach(PrivatePersonalCar p in privatePersonalCars)
                privateCarIDs.Add(p.ID);
            foreach (ProfessionalPersonalCar professional in professionalPersonalCars)
                profCarIDs.Add(professional.ID);

            foreach(Auction a in auctions)
            {
                if (busIDs.Contains(a.Vehicle.ID))
                {
                    a.Vehicle = DatabaseSelect(a.Vehicle.ID, bus);
                }
                if (truckIDs.Contains(a.Vehicle.ID))
                {
                    a.Vehicle = DatabaseSelect(a.Vehicle.ID, truck);
                }
                if (privateCarIDs.Contains(a.Vehicle.ID))
                {
                    a.Vehicle = DatabaseSelect(a.Vehicle.ID, privatePersonalCar);
                }
                if (profCarIDs.Contains(a.Vehicle.ID))
                {
                    a.Vehicle = DatabaseSelect(a.Vehicle.ID, professionalPersonalCar);
                }
            }

            return auctions;
        }

        public Auction DatabaseSelect(uint id, Auction type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectAuction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            Bus bus = new Bus("", 0, "", 0, 0, false, 5, 0, FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, EnergyClassEnum.A, DriversLisenceEnum.A, false);
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            Auction auction = new Auction(bus, privateUser, 0, DateTime.Now);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                auction.Buyer = privateUser;
                auction.SetID(Convert.ToUInt16(reader.GetValue(0)));
                auction.Vehicle.SetId(Convert.ToUInt16(reader.GetValue(1)));
                auction.Seller.UserName = reader.GetValue(2).ToString();
                auction.Buyer.UserName = reader.GetValue(3).ToString();
                auction.MinimumPrice = Convert.ToDecimal(reader.GetValue(4));
                auction.StandingBid = Convert.ToDecimal(reader.GetValue(5));
                auction.ClosingDate = Convert.ToDateTime(reader.GetValue(6));
                bool closed = Convert.ToBoolean(reader.GetValue(7));

                if (closed)
                    auction.CloseAuction();
                else
                    auction.OpenAuction();
            }
            connection.Close();
            return auction;
        }

        public Auction DatabaseUpdate(Auction updatedType)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdateAuction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = updatedType.ID;
            cmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = updatedType.Vehicle.ID;
            cmd.Parameters.Add("@Seller", SqlDbType.VarChar).Value = updatedType.Seller.UserName;
            cmd.Parameters.Add("@Buyer", SqlDbType.VarChar).Value = updatedType.Buyer.UserName;
            cmd.Parameters.Add("@MinimumPrice", SqlDbType.Decimal).Value = updatedType.MinimumPrice;
            cmd.Parameters.Add("@StandingBid", SqlDbType.Decimal).Value = updatedType.StandingBid;
            cmd.Parameters.Add("@ClosingDate", SqlDbType.DateTime).Value = updatedType.ClosingDate;
            cmd.Parameters.Add("Closed", SqlDbType.Bit).Value = updatedType.Closed;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(updatedType.ID, updatedType);
        }
    }
}
