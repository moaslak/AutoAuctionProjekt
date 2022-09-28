using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionProjekt.Classes
{
    public class UserDatabase
    {
        public User SelectUser(string userName)
        {
            Database database = new Database();
            PrivateUser privateUser = new PrivateUser("", "", "", "");
            CorporateUser corporateUser = new CorporateUser("", "", "", "", 0);
            List<PrivateUser> privateUsers = database.DatabaseGet(privateUser);
            List<CorporateUser> corporateUsers = database.DatabaseGet(corporateUser);

            foreach (PrivateUser user in privateUsers)
                if(user.UserName == userName)
                    return user;
            foreach(CorporateUser user in corporateUsers)
                if(user.UserName == userName)
                    return user;
            return null;

        }
    }
}
