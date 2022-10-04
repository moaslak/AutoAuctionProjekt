using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class AuctionBid
    {
        public AuctionBid(Auction auction, string bidder)
        {
            this.Auction = auction;
            this.Bidder = bidder;
        }

        public uint ID { get; private set; }
        public void SetID(uint id)
        {
            this.ID = id;
        }

        public Auction Auction { get; set; }
        public string Bidder { get; set; }
        public DateTime BidDate {get; set;} = DateTime.Now;

        public string Status { get; set; }

        public void Bid(Auction auction, Decimal newBid)
        {
            try
            {
                if (BidDate.CompareTo(auction.ClosingDate) < 0 && auction.Closed==false && newBid > auction.StandingBid)
                {
                    auction.StandingBid = newBid;
                    auction.Buyer.UserName = Bidder;

                    Database database = new Database();

                    database.DatabaseUpdate(auction);
                    database.AddBidToHistory(this);
                }

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }
    }
}
