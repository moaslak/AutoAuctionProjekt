using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.ComponentModel;

namespace AutoAuctionProjekt.Classes
{
    internal partial class Database
    {
        public static Database Instance { get; private set; }

        static Database()
        {
            Instance = new Database();
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            string query = "SELECT * FROM [dbo].[Vehicle]";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            //TODO: Reader implelement

            return vehicles;
        }
    }
}

