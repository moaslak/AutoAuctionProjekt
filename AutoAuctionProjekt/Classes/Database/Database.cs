using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace AutoAuctionProjekt.Classes
{
    internal partial class Database
    {
        public static Database Instance { get; private set; }

        static Database()
        {
            Instance = new Database();
        }
    }
}

