using System.Collections.Generic;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionProjekt.Interfaces
{
    public interface IDatabase<T>
    {
        void DatabaseCreate(T type);
        void DatabaseDelete(uint i, T type);
        List<T> DatabaseGet(T type);
        T DatabaseSelect(uint i, T type);
        T DatabaseUpdate(T type);
    }
}