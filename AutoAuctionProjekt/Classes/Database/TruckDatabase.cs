using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AutoAuctionProjekt.Interfaces;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase
    {
        public void DatabaseCreate()
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.Createtruck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = truck.Name;
            cmd.Parameters.Add("@Km", SqlDbType.Decimal).Value = truck.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = truck.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = truck.Year;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = truck.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = truck.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = truck.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = truck.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = truck.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = truck.EnergyClass;
            cmd.Parameters.Add("@Height", SqlDbType.Decimal).Value = truck.VehicleDimensions.Height;
            cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = truck.VehicleDimensions.Length;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = truck.VehicleDimensions.Weight;
            cmd.Parameters.Add("@LoadCapacity", SqlDbType.Decimal).Value = truck.LoadCapacity;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = truck.NewPrice;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Truck DatabaseSelect()
        {
            throw new NotImplementedException();
        }

        public List<Truck> DatabaseGet()
        {
            throw new NotImplementedException();
        }

        public Truck DatabaseUpdate()
        {
            throw new NotImplementedException();
        }

        public Truck DatabaseDelete()
        {
            throw new NotImplementedException();
        }
    }
}
