﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace AutoAuctionProjekt.Classes
{
/*
 * Domæne model
interface polymorfi via interface
interface til at kunne køde og sælge til

køber og sælger som interfaces

privat og company som klasser
 */

    public abstract class User : ISeller, IBuyer
    {
        protected User(string userName, string password, uint zipCode)
        {
            this.UserName = userName;
            this.Password = password;
            this.UserZipCode = zipCode;
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            this.PasswordHash = result;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public uint UserZipCode { get; set; }
        /// <summary>
        /// ID proberty
        /// </summary>
        public uint ID { get; private set; }

        public void SetID(uint ID)
        {
            this.ID = ID;
        }
        /// <summary>
        /// PasswordHash proberty
        /// </summary>
        private byte[] PasswordHash { get; set; }
        public decimal Balance { get; set; }
        public uint Zipcode { get; set; }

        /// <summary>
        /// A method that ...
        /// </summary>
        /// <returns>Whether login is valid</returns>
        private bool ValidateLogin(string loginUserName, string loginPassword)
        {
            //TODO: U5 - Implement the rest of validation for password and user name

            HashAlgorithm sha = SHA256.Create(); //Make a HashAlgorithm object for makeing hash computations.
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(loginPassword)); //Encodes the password into a hash in a Byte array.

            return PasswordHash == result;

            throw new NotImplementedException();
        }

        

        /// <summary>
        /// Returns the User in a string with relivant information.
        /// </summary>
        /// <returns>...</returns>
        public override string ToString()
        {
            return "ID: " + ID
                + "PasswordHash: " + PasswordHash
                + "User name: " + UserName
                + "Password: " + Password
                + "Zip code: " + UserZipCode;
        }

        //TODO: U4 - Implement interface proberties and methods.
        public string ReceiveBidNodification(string message)
        {
            //TODO: expand this. 
            return message;
        }
    }
}
