Use AutoAuctionDB
CREATE TABLE AuctionBidHistory(
	ID INT IDENTITY(1,1),
	AuctionID INT FOREIGN KEY REFERENCES Auctions(ID),
	CurrentHighestBidder VARCHAR(64) FOREIGN KEY REFERENCES Users(Username),
	Bid DECIMAL(12,2),
	BidData Date,
	PRIMARY KEY(ID)
)