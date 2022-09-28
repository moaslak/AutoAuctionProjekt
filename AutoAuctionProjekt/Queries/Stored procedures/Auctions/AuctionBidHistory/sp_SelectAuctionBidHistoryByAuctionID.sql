CREATE PROCEDURE SelectAuctionBidHistoryByAuctionID @AuctionID INT
AS
	SELECT * FROM AuctionBidHistory
	WHERE AuctionID = @AuctionID