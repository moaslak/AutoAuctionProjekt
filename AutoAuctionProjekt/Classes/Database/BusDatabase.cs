using AutoAuctionProjekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class BusDatabase : IDatabase<Bus>
    {
        public void DatabaseDelete(ushort i)
        {
            throw new NotImplementedException();
        }

        void IDatabase<Bus>.DatabaseCreate(Bus type)
        {
            throw new NotImplementedException();
        }

        List<Bus> IDatabase<Bus>.DatabaseGet()
        {
            throw new NotImplementedException();
        }

        Bus IDatabase<Bus>.DatabaseSelect(ushort i)
        {
            throw new NotImplementedException();
        }

        Bus IDatabase<Bus>.DatabaseUpdate(Bus type)
        {
            throw new NotImplementedException();
        }
    }
}
