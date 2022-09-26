using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<CorporateUser>
    {
        public void DatabaseCreate(CorporateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.CreateCorporateUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = type.UserName;

            string encryptedPassword = "";
            foreach (byte b in type.PasswordHash)
                encryptedPassword = encryptedPassword + b.ToString();

            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = encryptedPassword;
            cmd.Parameters.Add("@UserZipCode", SqlDbType.VarChar).Value = type.UserZipCode;
            cmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = type.Balance;
            if (type.Zipcode != null)
                cmd.Parameters.Add("@ZipcodeSeller", SqlDbType.VarChar).Value = type.Zipcode;
            else
                cmd.Parameters.Add("@ZipcodeSeller", SqlDbType.VarChar).Value = 0;
            cmd.Parameters.Add("@CVRNumber", SqlDbType.VarChar).Value = type.CVRNumber;
            cmd.Parameters.Add("Credit", SqlDbType.Money).Value = type.Credit;

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

        public void DatabaseDelete(uint Id, CorporateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.DeleteCorporateUser", connection);
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

        public List<CorporateUser> DatabaseGet(CorporateUser type)
        {
            List<CorporateUser> corporateUsers = new List<CorporateUser>();
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.GetCorporateUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CorporateUser corporateUser = new CorporateUser("", "", "", "",0);
                corporateUser.SetID(Convert.ToUInt16(reader.GetValue(1)));
                corporateUser.UserName = reader.GetString(2);
                corporateUser.CVRNumber = reader.GetString(3);
                corporateUser.Credit = Convert.ToDecimal(reader.GetValue(4));
                //TODO: VALIDATE PASSWORD
                corporateUser.Password = reader.GetString(5);
                corporateUser.UserZipCode = reader.GetString(6);
                corporateUser.Balance = Convert.ToDecimal(reader.GetValue(7));
                corporateUser.Zipcode = reader.GetString(8);
                corporateUsers.Add(corporateUser);
            }
            return corporateUsers;
        }

        public CorporateUser DatabaseSelect(uint id, CorporateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectCorporateUserByID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            CorporateUser corporateUser = new CorporateUser("", "", "", "",0);
            while (reader.Read())
            {
                corporateUser.SetID(Convert.ToUInt16(reader.GetValue(1)));
                corporateUser.UserName = reader.GetString(2);
                corporateUser.CVRNumber = reader.GetString(3);
                corporateUser.Credit = Convert.ToDecimal(reader.GetValue(4));
                //TODO: VALIDATE PASSWORD
                corporateUser.Password = reader.GetString(5);
                corporateUser.UserZipCode = reader.GetString(6);
                corporateUser.Balance = Convert.ToDecimal(reader.GetValue(7));
                corporateUser.Zipcode = reader.GetString(8);
            }
            return corporateUser;
        }

        public CorporateUser DatabaseSelect(string userName, CorporateUser type)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.SelectCorporateUserByUserName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            CorporateUser corporateUser = new CorporateUser("", "", "", "",0);
            while (reader.Read())
            {
                corporateUser.SetID(Convert.ToUInt16(reader.GetValue(1)));
                corporateUser.UserName = reader.GetString(2);
                corporateUser.CVRNumber = reader.GetString(3);
                corporateUser.Credit = Convert.ToDecimal(reader.GetValue(4));
                //TODO: VALIDATE PASSWORD
                corporateUser.Password = reader.GetString(5);
                corporateUser.UserZipCode = reader.GetString(6);
                corporateUser.Balance = Convert.ToDecimal(reader.GetValue(7));
                corporateUser.Zipcode = reader.GetString(8);
            }
            return corporateUser;
            throw new NotImplementedException();
        }

        public CorporateUser DatabaseUpdate(CorporateUser updatedType)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlConnection connection = databaseConnection.SetSqlConnection();
            SqlCommand cmd = new SqlCommand("dbo.UpdateCorporateUser", connection);
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
            cmd.Parameters.Add("@CVRNumber", SqlDbType.VarChar).Value = updatedType.CVRNumber;
            cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = updatedType.Credit;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return DatabaseSelect(updatedType.ID, updatedType);
        }
    }
}
