CREATE PROCEDURE UpdateAuction @ID INT, @VehicleID INT, @Seller VARCHAR(64), @Buyer VARCHAR(64), @MinimumPrice DECIMAL(12,2), @StandingBid DECIMAL(12,2), @ClosingDate DATE, @Closed BIT
AS
UPDATE [dbo].[Auctions]
   SET [VehicleID] = @VehicleID
      ,[Seller] = @Seller
      ,[Buyer] = @Buyer
      ,[MinimumPrice] = @MinimumPrice
      ,[StandingBid] = @StandingBid
      ,[ClosingDate] = @ClosingDate
      ,[Closed] = @Closed
 WHERE ID = @ID