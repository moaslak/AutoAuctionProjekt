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
    public partial class Database
    {
        public static Database Instance { get; private set; }

        static Database()
        {
            Instance = new Database();
        }
    }
}

