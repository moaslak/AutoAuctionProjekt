CREATE PROCEDURE GetAuctionBidHistory
AS
	SELECT * FROM AuctionBidHistory
	ORDER BY AuctionID ASC, BidDate DESC