using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, string password, string zipCode, string cprNumber) : base(userName, password, zipCode)
        {
            this.CPRNumber = cprNumber;
            //TODO: U11 - Add to database and set ID
        }
        public string CPRNumber { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Cpr number: " + CPRNumber;
        }
    }
}
