CREATE PROCEDURE SelectAuctionBidHistoryByUsername @Username VARCHAR(64)
AS
	SELECT * FROM AuctionBidHistory
	WHERE CurrentHighestBidder = @Username
	ORDER BY BidDate DESC