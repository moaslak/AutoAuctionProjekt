using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database
    {
        public void CreateTruck()
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

        public Truck SelectTruck(UInt32 TruckID)
        {
            new NotImplementedException();
        }

        public List<Truck> GetTrucks()
        {
            new NotImplementedException();
        }

        public Truck UpdateTruck(Truck truck)
        {
            new NotImplementedException();
            return truck;
        }
    
        public Truck DeleteTruck(UInt32 TruckID)
        {
            new NotImplementedException();
        }
    }
}
