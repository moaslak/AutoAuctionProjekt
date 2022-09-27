using AutoAuctionProjekt.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Interfaces;

namespace TestAutoAuctionProject
{
    public class UnitTestUsers
    {
        DatabaseConnection connection = new DatabaseConnection();
        Database database = new AutoAuctionProjekt.Classes.Database();
        PrivateUser privateUser = new PrivateUser("John R Deathclaw", "31337", "1337", "12345567");
        CorporateUser corporateUser = new CorporateUser("John C. Kiwi", "1337", "123467", "876543", 500);
        List<PrivateUser> privateUsers = new List<PrivateUser>();
        List<CorporateUser> corporateUsers = new List<CorporateUser>();

        [Fact]
        private void TestGetUsers()
        {
            bool success = false;
            try
            {
                privateUsers = database.DatabaseGet(privateUser);
                corporateUsers = database.DatabaseGet(corporateUser);
                success = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Assert.True(success);
        }

        [Fact]
        private void TestCreateSelectUpdateDeleteUsers()
        {
            int countPrivateUsers = database.DatabaseGet(privateUser).Count;
            int countCorporateUsers = database.DatabaseGet(corporateUser).Count;
            try
            {
                database.DatabaseCreate(privateUser);
                database.DatabaseCreate(corporateUser);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            privateUsers = database.DatabaseGet(privateUser);
            corporateUsers = database.DatabaseGet(corporateUser);
            Assert.Equal(countPrivateUsers+1, privateUsers.Count);
            Assert.Equal(countCorporateUsers+1, corporateUsers.Count);

            privateUsers = database.DatabaseGet(privateUser);
            corporateUsers = database.DatabaseGet(corporateUser);

            PrivateUser deletePrivateUser = database.DatabaseSelect(privateUsers[privateUsers.Count - 1].ID,privateUser);
            CorporateUser deleteCorporateUser = database.DatabaseSelect(corporateUsers[corporateUsers.Count - 1].ID, corporateUser);

            Assert.Equal(privateUser.UserName, deletePrivateUser.UserName);
            Assert.Equal(corporateUser.UserName, deleteCorporateUser.UserName);

            string oldPrivateName = deletePrivateUser.UserName;
            string oldCorporateName = deleteCorporateUser.UserName;
            string newPrivateUsername = "NewPrivateUserName";
            string newCorporateUsername = "NewCorporateUserName";
            deletePrivateUser.UserName = newPrivateUsername;
            deleteCorporateUser.UserName = newCorporateUsername;

            deletePrivateUser = database.DatabaseUpdate(deletePrivateUser);
            deleteCorporateUser = database.DatabaseUpdate(deleteCorporateUser);

            Assert.Equal(newPrivateUsername, deletePrivateUser.UserName);
            Assert.Equal(newCorporateUsername, deleteCorporateUser.UserName);

            database.DatabaseDelete(deletePrivateUser.ID, deletePrivateUser);
            database.DatabaseDelete(deleteCorporateUser.ID, deleteCorporateUser);

            privateUsers = database.DatabaseGet(privateUser);
            corporateUsers = database.DatabaseGet(corporateUser);

            Assert.Equal(countPrivateUsers, database.DatabaseGet(privateUser).Count);
            Assert.Equal(countCorporateUsers, database.DatabaseGet(corporateUser).Count);
        }
    }
}
