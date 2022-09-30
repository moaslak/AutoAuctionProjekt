  CREATE PROCEDURE AddBid @AuctionID INT, @CurrentHighestBidder VARCHAR(64), @StandingBid DECIMAL(12,2), @BidDate DATETIME, @Status BIT
  AS
INSERT INTO [dbo].[AuctionBidHistory]
           ([AuctionID]
           ,[CurrentHighestBidder]
           ,[StandingBid]
           ,[BidDate]
           ,[Status])
     VALUES
           (@AuctionID
           ,@CurrentHighestBidder
           ,@StandingBid
           ,@BidDate
           ,@Status)