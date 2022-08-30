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
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_Add_contact", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
            //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;

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
