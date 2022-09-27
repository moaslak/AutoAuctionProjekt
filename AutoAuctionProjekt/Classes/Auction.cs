using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class Auction
    {
        /// <summary>
        /// Constructor for Auction
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="seller"></param>
        /// <param name="minimumPrice"></param>
        public Auction(Vehicle vehicle, ISeller seller, decimal minimumPrice, DateTime closingDate)
        {
            this.Vehicle = vehicle;
            this.Seller = seller;
            this.MinimumPrice = minimumPrice;
            this.ClosingDate = closingDate;
        }
        /// <summary>
        /// ID of the auction
        /// </summary>
        public uint ID { get; private set; }

        public void SetID(uint Id)
        {
            this.ID = Id;
        }
        /// <summary>
        /// The minimum price of the auction
        /// </summary>
        public decimal MinimumPrice { get; set; }
        /// <summary>
        /// The standing bid of the auction
        /// </summary>
        public decimal StandingBid { get; set; }
        /// <summary>
        /// The vehicle of the auction
        /// </summary>
        internal Vehicle Vehicle { get; set; }

        public DateTime ClosingDate { get; set; }

        public bool Closed { get; private set; }

        public void CloseAuction()
        {
            this.Closed = true;
        }
        public void OpenAuction()
        {
            this.Closed = false;
        }
        /// <summary>
        /// The seller of the auction
        /// </summary>
        public ISeller Seller { get; set; }
        /// <summary>
        /// The buyer or potential buyer of the auction
        /// </summary>
        public IBuyer Buyer { get; set; }

        public IBuyer IBuyer
        {
            get => default;
            set
            {
            }
        }

        public ISeller ISeller
        {
            get => default;
            set
            {
            }
        }



        public override string ToString()
        {
            return "ID: " + this.ID
                + ", Vehicle ID: " + this.Vehicle.ID
                + ", Seller: " + this.Seller.UserName
                + ", Minimum price: " + this.MinimumPrice
                + ", Starting bid: " + this.StandingBid
                + ", Buyer: " + this.Buyer.UserName;
        }
    }
}