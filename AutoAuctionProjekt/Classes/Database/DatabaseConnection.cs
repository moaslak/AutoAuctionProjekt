using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoAuctionProjekt.Classes
{
    public class DatabaseConnection
    {
        public SqlConnection SetSqlConnection(string database)
        {
            SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            SqlConnectionStringBuilder.DataSource = ".";
            SqlConnectionStringBuilder.ConnectTimeout = 5;

            SqlConnectionStringBuilder["Trusted_Connection"] = true;

            SqlConnectionStringBuilder.InitialCatalog = database;
            SqlConnection SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ConnectionString);
            return SqlConnection;
        }

        public SqlConnection SetSqlConnection()
        {
            SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            SqlConnectionStringBuilder.DataSource = "docker.data.techcollege.dk,20001";
            SqlConnectionStringBuilder.ConnectTimeout = 10;
            SqlConnectionStringBuilder.UserID = "mort40f4"; //TODO: indlæses fra GUI
            SqlConnectionStringBuilder.Password = "Test1234!"; //TODO: indlæses fra GUI
            //string database = File.ReadAllText("..\\Data\\CONFIG.txt"); //TODO: relative path
            //database = database.Replace("Database=", "");
            string database = "AutoAuctionDB";
            SqlConnectionStringBuilder.InitialCatalog = database;
            SqlConnection SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ConnectionString);
            return SqlConnection;
        }
    }
}