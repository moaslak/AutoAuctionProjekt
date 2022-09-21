using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, string password, uint zipCode, uint cprNumber) : base(userName, password, zipCode)
        {
            this.CPRNumber = cprNumber;
            //TODO: U11 - Add to database and set ID
            throw new NotImplementedException();
        }
        public uint CPRNumber { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Cpr number: " + CPRNumber;
        }
    }
}
