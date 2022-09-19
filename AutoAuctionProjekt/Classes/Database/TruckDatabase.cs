using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using AutoAuctionProjekt.Interfaces;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<Truck>
    {
        public void DatabaseCreate(Truck truck)
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

        public Truck DatabaseSelect(uint Id, Truck truck)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectTruck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            //Truck truck = new Truck("1", 2, "3", 4, 5, false, 6, 7, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(8, 9, 10), Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, 11);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                truck.SetId(Convert.ToUInt16(reader.GetValue(0)));
                truck.LoadCapacity = Convert.ToUInt16(reader.GetValue(1));
                truck.VehicleDimensions = new HeavyVehicle.VehicleDimensionsStruct(
                    Convert.ToDouble(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)),
                    Convert.ToDouble(reader.GetValue(4)));
                truck.Name = Convert.ToString(reader.GetValue(5));
                truck.Km = Convert.ToDouble(reader.GetValue(6));
                truck.RegistrationNumber = Convert.ToString(reader.GetValue(7));
                truck.Year = Convert.ToInt32(reader.GetValue(8));
                truck.NewPrice = Convert.ToDecimal(reader.GetValue(9));
                truck.HasTowbar = Convert.ToBoolean(reader.GetValue(10));
                truck.EngineSize = Convert.ToDouble(reader.GetValue(11));
                truck.KmPerLiter = Convert.ToDouble(reader.GetValue(12));

                string driversLicense = Convert.ToString(reader.GetValue(13));
                switch (driversLicense)
                {
                    case "A":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(14));
                switch (fuelType)
                {
                    case "Diesel":
                        truck.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        truck.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(15));
                switch (energyClass)
                {
                    case "A":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
            }
            connection.Close();
            return truck;
        }

        public List<Truck> DatabaseGet(Truck t)
        {
            List<Truck> trucks = new List<Truck>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetTrucks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Truck truck = new Truck("1", 2, "3", 4, 5, false, 6, 7, Vehicle.FuelTypeEnum.Diesel, new HeavyVehicle.VehicleDimensionsStruct(8, 9, 10), Vehicle.EnergyClassEnum.A, Vehicle.DriversLisenceEnum.A, 11);
                truck.SetId(Convert.ToUInt16(reader.GetValue(0)));
                truck.LoadCapacity = Convert.ToUInt16(reader.GetValue(1));
                truck.VehicleDimensions = new HeavyVehicle.VehicleDimensionsStruct(
                    Convert.ToDouble(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)),
                    Convert.ToDouble(reader.GetValue(4)));
                truck.Name = Convert.ToString(reader.GetValue(5));
                truck.Km = Convert.ToDouble(reader.GetValue(6));
                truck.RegistrationNumber = Convert.ToString(reader.GetValue(7));
                truck.Year = Convert.ToInt32(reader.GetValue(8));
                truck.NewPrice = Convert.ToDecimal(reader.GetValue(9));
                truck.HasTowbar = Convert.ToBoolean(reader.GetValue(10));
                truck.EngineSize = Convert.ToDouble(reader.GetValue(11));
                truck.KmPerLiter = Convert.ToDouble(reader.GetValue(12));

                string driversLicense = Convert.ToString(reader.GetValue(13));
                switch (driversLicense)
                {
                    case "A":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        truck.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(14));
                switch (fuelType)
                {
                    case "Diesel":
                        truck.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        truck.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(15));
                switch(energyClass)
                {
                    case "A":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        truck.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
                trucks.Add(truck);
            }
            connection.Close();
            return trucks;
        }

        public Truck DatabaseUpdate(Truck updatedTruck)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdateTruck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = updatedTruck.Name;
            cmd.Parameters.Add("@Km", SqlDbType.Decimal).Value = updatedTruck.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = updatedTruck.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = updatedTruck.Year;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = updatedTruck.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = updatedTruck.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = updatedTruck.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = updatedTruck.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = updatedTruck.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = updatedTruck.EnergyClass;
            cmd.Parameters.Add("@Height", SqlDbType.Decimal).Value = updatedTruck.VehicleDimensions.Height;
            cmd.Parameters.Add("@Length", SqlDbType.Decimal).Value = updatedTruck.VehicleDimensions.Length;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = updatedTruck.VehicleDimensions.Weight;
            cmd.Parameters.Add("@LoadCapacity", SqlDbType.Decimal).Value = updatedTruck.LoadCapacity;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = updatedTruck.NewPrice;
            cmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = updatedTruck.ID;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(Convert.ToUInt16(updatedTruck.ID), updatedTruck);
        }

        public void DatabaseDelete(uint Id, Truck truck)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeleteTruck", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID",SqlDbType.Int).Value = Id;
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
    }
}
