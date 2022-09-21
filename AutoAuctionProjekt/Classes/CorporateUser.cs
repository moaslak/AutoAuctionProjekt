using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class CorporateUser : User
    {
        public CorporateUser(string userName, string password, uint zipCode, uint cvrNumber, decimal credit) : base(userName, password, zipCode)
        {
            this.CVRNumber = cvrNumber;
            this.Credit = credit;
            //TODO: U8 - Add to database and set ID
            throw new NotImplementedException();
        }
        public uint CVRNumber { get; set; }
        public decimal Credit { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", CVR number: " + CVRNumber
                + ", Credit: " + Credit;
        }
    }
}
