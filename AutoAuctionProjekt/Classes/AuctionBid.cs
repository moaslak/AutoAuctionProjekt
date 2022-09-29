using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class AuctionBid
    {
        public AuctionBid(Auction auction, User bidder)
        {
            this.Auction = auction;
            this.Bidder = bidder;
        }

        public uint ID { get; private set; }
        public void SetID(uint id)
        {
            this.ID = this.Auction.ID;
        }

        public Auction Auction { get; set; }
        public User Bidder { get; set; }
        public DateTime BidDate {get; set;} = DateTime.Now;
    }
}
