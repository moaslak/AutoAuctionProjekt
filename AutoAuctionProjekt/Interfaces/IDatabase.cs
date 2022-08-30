using System.Collections.Generic;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionProjekt.Interfaces
{
    public interface IDatabase
    {
        void DatabaseCreate();
        object DatabaseDelete();
        List<object> DatabaseGet();
        object DatabaseSelect();
        object DatabaseUpdate();
    }
}