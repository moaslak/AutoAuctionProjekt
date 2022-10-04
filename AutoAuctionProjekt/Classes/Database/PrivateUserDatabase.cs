using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<PrivateUser>
    {
        public void DatabaseCreate(PrivateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.CreatePrivateUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = type.UserName;

            string encryptedPassword = "";
            foreach (byte b in type.PasswordHash)
                encryptedPassword = encryptedPassword + b.ToString();

            //cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = encryptedPassword;
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = type.Password;
            cmd.Parameters.Add("@UserZipCode", SqlDbType.VarChar).Value = type.UserZipCode;
            cmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = type.Balance;
            if (type.Zipcode != null)
                cmd.Parameters.Add("@ZipcodeSeller", SqlDbType.VarChar).Value = type.Zipcode;
            else
                cmd.Parameters.Add("@ZipcodeSeller", SqlDbType.VarChar).Value = 0;
            cmd.Parameters.Add("@CPRNumber", SqlDbType.VarChar).Value = type.CPRNumber;

            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            
            connection.Close();

            cmd = new SqlCommand("dbo.CreateUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            string formatUsername = type.UserName.Replace(" ", "_");
            formatUsername = formatUsername.Replace(".", "");
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = formatUsername;
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

        public void DatabaseDelete(uint Id, PrivateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeletePrivateUser", connection);
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

        public List<PrivateUser> DatabaseGet(PrivateUser type)
        {
            List<PrivateUser> privateUsers = new List<PrivateUser>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetPrivateUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PrivateUser privateUser = new PrivateUser("","","","");
                privateUser.SetID(Convert.ToUInt16(reader.GetValue(0)));
                privateUser.UserName = reader.GetString(2);
                privateUser.CPRNumber = reader.GetString(3);
                //TODO: VALIDATE PASSWORD
                privateUser.Password = reader.GetString(4);
                privateUser.UserZipCode = reader.GetString(5);
                privateUser.Balance = Convert.ToDecimal(reader.GetValue(6));
                privateUser.Zipcode = reader.GetString(7);
                privateUsers.Add(privateUser);
            }
            return privateUsers;
        }

        public PrivateUser DatabaseSelect(uint id, PrivateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectPrivateUserByID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            while (reader.Read())
            {
                privateUser.SetID(Convert.ToUInt16(reader.GetValue(1)));
                privateUser.UserName = reader.GetString(2);
                privateUser.CPRNumber = reader.GetString(3);
                //TODO: VALIDATE PASSWORD
                privateUser.Password = reader.GetString(4);
                privateUser.UserZipCode = reader.GetString(5);
                privateUser.Balance = Convert.ToDecimal(reader.GetValue(6));
                privateUser.Zipcode = reader.GetString(7);
            }
            return privateUser;
        }

        public PrivateUser DatabaseSelect(string userName, PrivateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectPrivateUserByUserName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            bool userFound = false;
            while (reader.Read())
            {
                privateUser.SetID(Convert.ToUInt16(reader.GetValue(1)));
                privateUser.UserName = reader.GetString(2);
                privateUser.CPRNumber = reader.GetString(3);
                //TODO: VALIDATE PASSWORD
                privateUser.Password = reader.GetString(4);
                privateUser.UserZipCode = reader.GetString(5);
                privateUser.Balance = Convert.ToDecimal(reader.GetValue(6));
                privateUser.Zipcode = reader.GetString(7);
                userFound = true;
            }
            if (userFound)
                return privateUser;
            else
                return null;
        }

        public PrivateUser DatabaseUpdate(PrivateUser updatedType)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdatePrivateUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = updatedType.ID;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = updatedType.UserName;

            string encryptedPassword = "";
            foreach (byte b in updatedType.PasswordHash)
                encryptedPassword = encryptedPassword + b.ToString();

            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = encryptedPassword; //TODO: ENCRYPT PASSWORD !!!
            cmd.Parameters.Add("@UserZipCode", SqlDbType.VarChar).Value = updatedType.UserZipCode;
            cmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = updatedType.Balance;
            cmd.Parameters.Add("@ZipcodeSeller", SqlDbType.VarChar).Value = updatedType.Zipcode;
            cmd.Parameters.Add("@CPRNumber", SqlDbType.VarChar).Value = updatedType.CPRNumber;
            
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(updatedType.UserName, updatedType);

        }
    }
}
