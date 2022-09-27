CREATE PROCEDURE CreateAuction @VehicleID INT, @Seller VARCHAR(64), @Buyer VARCHAR(64), @MinimumPrice DECIMAL(12,2), @StandingBid DECIMAL(12,2), @ClosingDate DATE, @Closed BIT 
AS INSERT INTO [dbo].[Auctions]
           ([VehicleID]
           ,[Seller]
           ,[Buyer]
           ,[MinimumPrice]
           ,[StandingBid]
           ,[ClosingDate]
           ,[Closed])
     VALUES
           (@VehicleID
           ,@Seller
           ,@Buyer
           ,@MinimumPrice
           ,@StandingBid
           ,@ClosingDate
           ,@Closed)