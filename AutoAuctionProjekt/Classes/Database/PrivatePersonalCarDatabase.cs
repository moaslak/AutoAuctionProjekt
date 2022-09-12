using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<PrivatePersonalCar>
    {
        public void DatabaseCreate(PrivatePersonalCar privatePersonalCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.CreatePrivatePersonalCar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = privatePersonalCar.Name;
            cmd.Parameters.Add("@km", SqlDbType.Decimal).Value = privatePersonalCar.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = privatePersonalCar.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = privatePersonalCar.Year;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = privatePersonalCar.NewPrice;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = privatePersonalCar.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = privatePersonalCar.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = privatePersonalCar.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = privatePersonalCar.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = privatePersonalCar.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = privatePersonalCar.EnergyClass;
            cmd.Parameters.Add("@numberOfSeats", SqlDbType.Decimal).Value = privatePersonalCar.NumberOfSeat;
            cmd.Parameters.Add("@TrunkHeight", SqlDbType.Decimal).Value = privatePersonalCar.TrunkDimentions.Height;
            cmd.Parameters.Add("@TrunkWidth", SqlDbType.Decimal).Value = privatePersonalCar.TrunkDimentions.Width;
            cmd.Parameters.Add("@TrunkDepth", SqlDbType.Decimal).Value = privatePersonalCar.TrunkDimentions.Depth;
            cmd.Parameters.Add("@hasISOfitting", SqlDbType.Bit).Value = privatePersonalCar.HasIsofixFittings;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DatabaseDelete(uint Id, PrivatePersonalCar privatePersonalCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeletePrivatePersonalCar", connection);
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

        public List<PrivatePersonalCar> DatabaseGet(PrivatePersonalCar ppc)
        {
            List<PrivatePersonalCar> privatePersonalCars = new List<PrivatePersonalCar>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetPrivatePersonalCars", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PrivatePersonalCar privatePersonalCar = new PrivatePersonalCar("1",2,"3",4,5,false,6,7,Vehicle.FuelTypeEnum.Diesel, 8, new PersonalCar.TrunkDimentionsStruct(9,10,11),false,Vehicle.DriversLisenceEnum.A,Vehicle.EnergyClassEnum.A);
                privatePersonalCar.SetId(Convert.ToUInt16(reader.GetValue(0)));
                privatePersonalCar.HasIsofixFittings = Convert.ToBoolean(reader.GetValue(1));
                privatePersonalCar.Name = reader.GetValue(2).ToString();
                privatePersonalCar.Km = Convert.ToDouble(reader.GetValue(3));
                privatePersonalCar.RegistrationNumber = reader.GetValue(4).ToString();
                privatePersonalCar.NumberOfSeat = Convert.ToUInt16(reader.GetValue(5));
                privatePersonalCar.TrunkDimentions = new PersonalCar.TrunkDimentionsStruct(Convert.ToDouble(reader.GetValue(6)),
                    Convert.ToDouble(reader.GetValue(7)), Convert.ToDouble(reader.GetValue(8)));
                privatePersonalCar.Year = Convert.ToInt32(reader.GetValue(9));
                privatePersonalCar.NewPrice = Convert.ToDecimal(reader.GetValue(10));
                privatePersonalCar.HasTowbar = Convert.ToBoolean(reader.GetValue(11));
                privatePersonalCar.EngineSize = Convert.ToDouble(reader.GetValue(12));
                privatePersonalCar.KmPerLiter = Convert.ToDouble(reader.GetValue(13));


                string driversLicense = Convert.ToString(reader.GetValue(14));
                switch (driversLicense)
                {
                    case "A":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(15));
                switch (fuelType)
                {
                    case "Diesel":
                        privatePersonalCar.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        privatePersonalCar.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(16));
                switch (energyClass)
                {
                    case "A":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
                privatePersonalCars.Add(privatePersonalCar);
            }
            connection.Close();
            return privatePersonalCars;
        }

        public PrivatePersonalCar DatabaseSelect(uint Id, PrivatePersonalCar ppc)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectPrivatePersonalCar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            PrivatePersonalCar privatePersonalCar = new PrivatePersonalCar("1", 2, "3", 4, 5, false, 6, 7, Vehicle.FuelTypeEnum.Diesel, 8, new PersonalCar.TrunkDimentionsStruct(9, 10, 11), false, Vehicle.DriversLisenceEnum.A, Vehicle.EnergyClassEnum.A);
            
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                privatePersonalCar.SetId(Convert.ToUInt16(reader.GetValue(0)));
                privatePersonalCar.HasIsofixFittings = Convert.ToBoolean(reader.GetValue(1));
                privatePersonalCar.Name = reader.GetValue(2).ToString();
                privatePersonalCar.Km = Convert.ToDouble(reader.GetValue(3));
                privatePersonalCar.RegistrationNumber = reader.GetValue(4).ToString();
                privatePersonalCar.NumberOfSeat = Convert.ToUInt16(reader.GetValue(5));
                privatePersonalCar.TrunkDimentions = new PersonalCar.TrunkDimentionsStruct(Convert.ToDouble(reader.GetValue(6)),
                    Convert.ToDouble(reader.GetValue(7)), Convert.ToDouble(reader.GetValue(8)));
                privatePersonalCar.Year = Convert.ToInt32(reader.GetValue(9));
                privatePersonalCar.NewPrice = Convert.ToDecimal(reader.GetValue(10));
                privatePersonalCar.HasTowbar = Convert.ToBoolean(reader.GetValue(11));
                privatePersonalCar.EngineSize = Convert.ToDouble(reader.GetValue(12));
                privatePersonalCar.KmPerLiter = Convert.ToDouble(reader.GetValue(13));


                string driversLicense = Convert.ToString(reader.GetValue(14));
                switch (driversLicense)
                {
                    case "A":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        privatePersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(15));
                switch (fuelType)
                {
                    case "Diesel":
                        privatePersonalCar.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        privatePersonalCar.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(16));
                switch (energyClass)
                {
                    case "A":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        privatePersonalCar.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
            }
            connection.Close();
            return privatePersonalCar;
        }

        public PrivatePersonalCar DatabaseUpdate(PrivatePersonalCar updatedPrivatelPersonalCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdatePrivatePersonalCar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = updatedPrivatelPersonalCar.Name;
            cmd.Parameters.Add("@km", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = updatedPrivatelPersonalCar.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = updatedPrivatelPersonalCar.Year;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.NewPrice;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = updatedPrivatelPersonalCar.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = updatedPrivatelPersonalCar.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = updatedPrivatelPersonalCar.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = updatedPrivatelPersonalCar.EnergyClass;
            cmd.Parameters.Add("@numberOfSeats", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.NumberOfSeat;
            cmd.Parameters.Add("@TrunkHeight", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.TrunkDimentions.Height;
            cmd.Parameters.Add("@TrunkWidth", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.TrunkDimentions.Width;
            cmd.Parameters.Add("@TrunkDepth", SqlDbType.Decimal).Value = updatedPrivatelPersonalCar.TrunkDimentions.Depth;
            cmd.Parameters.Add("@hasSaftyBar", SqlDbType.Bit).Value = updatedPrivatelPersonalCar.HasTowbar;
            cmd.Parameters.Add("@vehicleID", SqlDbType.Int).Value = updatedPrivatelPersonalCar.ID;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(Convert.ToUInt16(updatedPrivatelPersonalCar.ID), updatedPrivatelPersonalCar);
        }
    }
}
