using System.Collections.Generic;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionProjekt.Interfaces
{
    public interface IDatabase<T>
    {
        void DatabaseCreate(T type);
        void DatabaseDelete(ushort i);
        List<T> DatabaseGet();
        T DatabaseSelect(ushort i);
        T DatabaseUpdate(T type);
    }
}