using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<Bus>
    {
        public void DatabaseDelete(uint Id, Bus bus)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeleteBus", connection);
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

        public void DatabaseCreate(Bus bus)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.Createbus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = bus.Name;
            cmd.Parameters.Add("@Km", SqlDbType.Decimal).Value = bus.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = bus.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = bus.Year;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = bus.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = bus.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = bus.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = bus.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = bus.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = bus.EnergyClass;
            cmd.Parameters.Add("@Height", SqlDbType.Decimal).Value = bus.VehicleDimensions.Height;
            cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = bus.VehicleDimensions.Length;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = bus.VehicleDimensions.Weight;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = bus.NewPrice;
            cmd.Parameters.Add("@numberOfSeats", SqlDbType.Int).Value = bus.NumberOfSeats;
            cmd.Parameters.Add("@numberOfSleepingSpaces", SqlDbType.Int).Value = bus.NumberOfSleepingSpaces;
            cmd.Parameters.Add("@hasToilet", SqlDbType.Bit).Value = bus.HasToilet;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<Bus> DatabaseGet(Bus b)
        {
            List<Bus> buses = new List<Bus>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetBuses", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bus bus = new Bus("", 0, "", 5, 5, false, 5, 5, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(0, 0, 0), 0, 0, Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, false);
                bus.SetId(Convert.ToUInt16(reader.GetValue(0)));
                bus.NumberOfSeats = (Convert.ToUInt16(reader.GetValue(1)));
                bus.NumberOfSleepingSpaces = (Convert.ToUInt16(reader.GetValue(2)));
                bus.HasToilet = (Convert.ToBoolean(reader.GetValue(3)));
                bus.VehicleDimensions = new HeavyVehicle.VehicleDimensionsStruct(
                    Convert.ToDouble(reader.GetValue(4)), Convert.ToDouble(reader.GetValue(5)),
                    Convert.ToDouble(reader.GetValue(6)));
                bus.Name = Convert.ToString(reader.GetValue(7));
                bus.Km = Convert.ToDouble(reader.GetValue(8));
                bus.RegistrationNumber = Convert.ToString(reader.GetValue(9));
                bus.Year = Convert.ToInt32(reader.GetValue(10));
                bus.NewPrice = Convert.ToDecimal(reader.GetValue(11));
                bus.HasTowbar = Convert.ToBoolean(reader.GetValue(12));
                bus.EngineSize = Convert.ToDouble(reader.GetValue(13));
                bus.KmPerLiter = Convert.ToDouble(reader.GetValue(14));

                string driversLicense = Convert.ToString(reader.GetValue(15));
                switch (driversLicense)
                {
                    case "A":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(16));
                switch (fuelType)
                {
                    case "Diesel":
                        bus.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        bus.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(17));
                switch (energyClass)
                {
                    case "A":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
                buses.Add(bus);
            }
            connection.Close();
            return buses;
        }

        public Bus DatabaseSelect(uint Id, Bus bus)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectTruck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            //Bus bus = new Bus("1",2,"3",4,5,true,6,7,Vehicle.FuelTypeEnum.Diesel,new HeavyVehicle.VehicleDimensionsStruct(8,9,10),11,12,Vehicle.EnergyClassEnum.A,Vehicle.DriversLisenceEnum.A,false);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bus.SetId(Convert.ToUInt16(reader.GetValue(0)));
                bus.NumberOfSeats = Convert.ToUInt16(reader.GetValue(1));
                bus.NumberOfSleepingSpaces = Convert.ToUInt16(reader.GetValue(2));
                bus.HasToilet = Convert.ToBoolean(reader.GetValue(3));
                bus.VehicleDimensions = new HeavyVehicle.VehicleDimensionsStruct(
                    Convert.ToDouble(reader.GetValue(4)), Convert.ToDouble(reader.GetValue(5)),
                    Convert.ToDouble(reader.GetValue(6)));
                bus.Name = Convert.ToString(reader.GetValue(7));
                bus.Km = Convert.ToDouble(reader.GetValue(8));
                bus.RegistrationNumber = Convert.ToString(reader.GetValue(9));
                bus.Year = Convert.ToInt32(reader.GetValue(10));
                bus.NewPrice = Convert.ToDecimal(reader.GetValue(11));
                bus.HasTowbar = Convert.ToBoolean(reader.GetValue(12));
                bus.EngineSize = Convert.ToDouble(reader.GetValue(13));
                bus.KmPerLiter = Convert.ToDouble(reader.GetValue(14));

                string driversLicense = Convert.ToString(reader.GetValue(15));
                switch (driversLicense)
                {
                    case "A":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        bus.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(16));
                switch (fuelType)
                {
                    case "Diesel":
                        bus.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        bus.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(17));
                switch (energyClass)
                {
                    case "A":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        bus.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
            }
            connection.Close();
            return bus;
        }

        public Bus DatabaseUpdate(Bus updatedBus)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdateBus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = updatedBus.Name;
            cmd.Parameters.Add("@Km", SqlDbType.Decimal).Value = updatedBus.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = updatedBus.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = updatedBus.Year;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = updatedBus.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = updatedBus.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = updatedBus.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = updatedBus.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = updatedBus.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = updatedBus.EnergyClass;
            cmd.Parameters.Add("@Height", SqlDbType.Decimal).Value = updatedBus.VehicleDimensions.Height;
            cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = updatedBus.VehicleDimensions.Length;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = updatedBus.VehicleDimensions.Weight;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = updatedBus.NewPrice;
            cmd.Parameters.Add("@numberOfSeats", SqlDbType.Int).Value = updatedBus.NumberOfSeats;
            cmd.Parameters.Add("@numberOfSleepingSpaces", SqlDbType.Int).Value = updatedBus.NumberOfSleepingSpaces;
            cmd.Parameters.Add("@hasToilet", SqlDbType.Bit).Value = updatedBus.HasToilet;
            cmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = updatedBus.ID;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(Convert.ToUInt16(updatedBus.ID), updatedBus);
        }
    }
}
