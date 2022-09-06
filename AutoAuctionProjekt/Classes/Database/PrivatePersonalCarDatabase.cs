using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    partial class Database : IDatabase<PrivatePersonalCar>
    {
        public void DatabaseCreate(PrivatePersonalCar type)
        {
            throw new NotImplementedException();
        }

        public void DatabaseDelete(uint i, PrivatePersonalCar type)
        {
            throw new NotImplementedException();
        }

        public List<PrivatePersonalCar> DatabaseGet(PrivatePersonalCar type)
        {
            throw new NotImplementedException();
        }

        public PrivatePersonalCar DatabaseSelect(uint i, PrivatePersonalCar type)
        {
            throw new NotImplementedException();
        }

        public PrivatePersonalCar DatabaseUpdate(PrivatePersonalCar type)
        {
            throw new NotImplementedException();
        }
    }
}
