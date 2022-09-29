  CREATE PROCEDURE AddBid @AuctionID INT, @CurrentHighestBidder VARCHAR(64), @StandingBid DECIMAL(12,2), @BidDate DATETIME
  AS
INSERT INTO [dbo].[AuctionBidHistory]
           ([AuctionID]
           ,[CurrentHighestBidder]
           ,[StandingBid]
           ,[BidDate])
     VALUES
           (@AuctionID
           ,@CurrentHighestBidder
           ,@StandingBid
           ,@BidDate)