using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<ProfessionalPersonalCar>
    {
        public void DatabaseCreate(ProfessionalPersonalCar professionalPersonalCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.CreateProfessionalPersonalCar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = professionalPersonalCar.Name;
            cmd.Parameters.Add("@km", SqlDbType.Decimal).Value = professionalPersonalCar.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = professionalPersonalCar.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = professionalPersonalCar.Year;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = professionalPersonalCar.NewPrice;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = professionalPersonalCar.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = professionalPersonalCar.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = professionalPersonalCar.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = professionalPersonalCar.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = professionalPersonalCar.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = professionalPersonalCar.EnergyClass;
            cmd.Parameters.Add("@numberOfSeats", SqlDbType.Decimal).Value = professionalPersonalCar.NumberOfSeat;
            cmd.Parameters.Add("@TrunkHeight", SqlDbType.Decimal).Value = professionalPersonalCar.TrunkDimentions.Height;
            cmd.Parameters.Add("@TrunkWidth", SqlDbType.Decimal).Value = professionalPersonalCar.TrunkDimentions.Width;
            cmd.Parameters.Add("@TrunkDepth", SqlDbType.Decimal).Value = professionalPersonalCar.TrunkDimentions.Depth;
            cmd.Parameters.Add("@hasSaftyBar", SqlDbType.Bit).Value = professionalPersonalCar.HasSafetyBar;
            cmd.Parameters.Add("@loadCapacity", SqlDbType.Decimal).Value = professionalPersonalCar.LoadCapacity;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DatabaseDelete(uint Id, ProfessionalPersonalCar professionalPersonalCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeleteProfessionalPersonalCar", connection);
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

        public List<ProfessionalPersonalCar> DatabaseGet(ProfessionalPersonalCar ppc)
        {
            List<ProfessionalPersonalCar> professionalPersonalCars = new List<ProfessionalPersonalCar>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetProfessionalPersonalCars", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProfessionalPersonalCar professionalPersonalCar = new ProfessionalPersonalCar("1", 2, "3", 4, 5, 6, 7, Vehicle.FuelTypeEnum.Diesel,
                    8, new ProfessionalPersonalCar.TrunkDimentionsStruct(9, 10, 11), false, 12, Vehicle.DriversLisenceEnum.A, Vehicle.EnergyClassEnum.A);
                professionalPersonalCar.SetId(Convert.ToUInt16(reader.GetValue(0)));
                professionalPersonalCar.HasSafetyBar = Convert.ToBoolean(reader.GetValue(1));
                professionalPersonalCar.LoadCapacity = Convert.ToDouble(reader.GetValue(2));
                professionalPersonalCar.Name = reader.GetValue(3).ToString();
                professionalPersonalCar.Km = Convert.ToDouble(reader.GetValue(4));
                professionalPersonalCar.RegistrationNumber = reader.GetValue(5).ToString();
                professionalPersonalCar.NumberOfSeat = Convert.ToUInt16(reader.GetValue(6));
                professionalPersonalCar.TrunkDimentions = new PersonalCar.TrunkDimentionsStruct(Convert.ToDouble(reader.GetValue(7)),
                    Convert.ToDouble(reader.GetValue(8)), Convert.ToDouble(reader.GetValue(9)));
                professionalPersonalCar.Year = Convert.ToInt32(reader.GetValue(10));
                professionalPersonalCar.NewPrice = Convert.ToDecimal(reader.GetValue(11));
                professionalPersonalCar.HasTowbar = Convert.ToBoolean(reader.GetValue(12));
                professionalPersonalCar.EngineSize = Convert.ToDouble(reader.GetValue(13));
                professionalPersonalCar.KmPerLiter = Convert.ToDouble(reader.GetValue(14));


                string driversLicense = Convert.ToString(reader.GetValue(15));
                switch (driversLicense)
                {
                    case "A":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(16));
                switch (fuelType)
                {
                    case "Diesel":
                        professionalPersonalCar.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        professionalPersonalCar.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(17));
                switch (energyClass)
                {
                    case "A":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
                professionalPersonalCars.Add(professionalPersonalCar);
            }
            connection.Close();
            return professionalPersonalCars;
        }

        public ProfessionalPersonalCar DatabaseSelect(uint Id, ProfessionalPersonalCar profCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectProfessionalPersonalCar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            ProfessionalPersonalCar professionalPersonalCar = new ProfessionalPersonalCar("1", 2, "3", 4, 5, 6, 7, Vehicle.FuelTypeEnum.Diesel,
                8, new ProfessionalPersonalCar.TrunkDimentionsStruct(9, 10, 11), false, 12, Vehicle.DriversLisenceEnum.A, Vehicle.EnergyClassEnum.A);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                professionalPersonalCar.SetId(Convert.ToUInt16(reader.GetValue(0)));
                professionalPersonalCar.HasSafetyBar = Convert.ToBoolean(reader.GetValue(1));
                professionalPersonalCar.LoadCapacity = Convert.ToDouble(reader.GetValue(2));
                professionalPersonalCar.Name = reader.GetValue(3).ToString();
                professionalPersonalCar.Km = Convert.ToDouble(reader.GetValue(4));
                professionalPersonalCar.RegistrationNumber = reader.GetValue(5).ToString();
                professionalPersonalCar.NumberOfSeat = Convert.ToUInt16(reader.GetValue(6));
                professionalPersonalCar.TrunkDimentions = new PersonalCar.TrunkDimentionsStruct(Convert.ToDouble(reader.GetValue(7)),
                    Convert.ToDouble(reader.GetValue(8)), Convert.ToDouble(reader.GetValue(9)));
                professionalPersonalCar.Year = Convert.ToInt32(reader.GetValue(10));
                professionalPersonalCar.NewPrice = Convert.ToDecimal(reader.GetValue(11));
                professionalPersonalCar.HasTowbar = Convert.ToBoolean(reader.GetValue(12));
                professionalPersonalCar.EngineSize = Convert.ToDouble(reader.GetValue(13));
                professionalPersonalCar.KmPerLiter = Convert.ToDouble(reader.GetValue(14));


                string driversLicense = Convert.ToString(reader.GetValue(15));
                switch (driversLicense)
                {
                    case "A":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.A;
                        break;
                    case "B":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.B;
                        break;
                    case "BE":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.BE;
                        break;
                    case "C":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.C;
                        break;
                    case "CE":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.CE;
                        break;
                    case "D":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.D;
                        break;
                    case "DE":
                        professionalPersonalCar.DriversLisence = Vehicle.DriversLisenceEnum.DE;
                        break;
                    default:
                        throw new ArgumentException("Invalid driver license");
                }

                string fuelType = Convert.ToString(reader.GetValue(16));
                switch (fuelType)
                {
                    case "Diesel":
                        professionalPersonalCar.FuelType = Vehicle.FuelTypeEnum.Diesel;
                        break;
                    case "Petrol":
                        professionalPersonalCar.FuelType = Vehicle.FuelTypeEnum.Petrol;
                        break;
                    default:
                        throw new ArgumentException("Invalid fuel type");
                }

                string energyClass = Convert.ToString(reader.GetValue(17));
                switch (energyClass)
                {
                    case "A":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.A;
                        break;
                    case "B":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.B;
                        break;
                    case "C":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.C;
                        break;
                    case "D":
                        professionalPersonalCar.EnergyClass = Vehicle.EnergyClassEnum.D;
                        break;
                    default:
                        throw new ArgumentException("Invalid energy class");
                }
            }
            connection.Close();
            return professionalPersonalCar;
        }

        public ProfessionalPersonalCar DatabaseUpdate(ProfessionalPersonalCar updatedProfessionalPersonalCar)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdateProfessionalPersonalCar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = updatedProfessionalPersonalCar.Name;
            cmd.Parameters.Add("@km", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.Km;
            cmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = updatedProfessionalPersonalCar.RegistrationNumber;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = updatedProfessionalPersonalCar.Year;
            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.NewPrice;
            cmd.Parameters.Add("@HasTowbar", SqlDbType.Bit).Value = updatedProfessionalPersonalCar.HasTowbar;
            cmd.Parameters.Add("@EngineSize", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.EngineSize;
            cmd.Parameters.Add("@KmPrLiter", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.KmPerLiter;
            cmd.Parameters.Add("@DriversLicense", SqlDbType.VarChar).Value = updatedProfessionalPersonalCar.DriversLisence;
            cmd.Parameters.Add("@FuelType", SqlDbType.VarChar).Value = updatedProfessionalPersonalCar.FuelType;
            cmd.Parameters.Add("@EnergyClass", SqlDbType.VarChar).Value = updatedProfessionalPersonalCar.EnergyClass;
            cmd.Parameters.Add("@numberOfSeats", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.NumberOfSeat;
            cmd.Parameters.Add("@TrunkHeight", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.TrunkDimentions.Height;
            cmd.Parameters.Add("@TrunkWidth", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.TrunkDimentions.Width;
            cmd.Parameters.Add("@TrunkDepth", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.TrunkDimentions.Depth;
            cmd.Parameters.Add("@hasSaftyBar", SqlDbType.Bit).Value = updatedProfessionalPersonalCar.HasSafetyBar;
            cmd.Parameters.Add("@loadCapacity", SqlDbType.Decimal).Value = updatedProfessionalPersonalCar.LoadCapacity;
            cmd.Parameters.Add("@vehicleID", SqlDbType.Int).Value = updatedProfessionalPersonalCar.ID;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(Convert.ToUInt16(updatedProfessionalPersonalCar.ID), updatedProfessionalPersonalCar);
        }
    }
}
