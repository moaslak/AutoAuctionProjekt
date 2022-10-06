using System.Collections.Generic;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionProjekt.Interfaces
{
    public interface IDatabase<T>
    {
        /// <summary>
        /// Method for creating an entry in the database
        /// </summary>
        /// <param name="type"></param>
        void DatabaseCreate(T type);
        
        /// <summary>
        /// Method for deleting an entry in the database
        /// </summary>
        /// <param name="i"></param>
        /// <param name="type"></param>
        void DatabaseDelete(uint i, T type);
        
        /// <summary>
        /// Method for getting a list from the database
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List of same type as argument</returns>
        List<T> DatabaseGet(T type);
        
        /// <summary>
        /// Method for selecting a single entry of a type from the datebase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="type"></param>
        /// <returns>Object of same type as argument</returns>
        T DatabaseSelect(uint i, T type);

        /// <summary>
        /// Method for updating an entry in the datebase
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Object of same type as argument</returns>
        T DatabaseUpdate(T type);
    }
}