﻿Use AutoAuctionDB
CREATE TABLE Auctions(
	ID INT IDENTITY(1,1),
	VehicleID INT FOREIGN KEY REFERENCES Vehicle(ID),
	Seller VARCHAR(64) FOREIGN KEY REFERENCES Users(Username),
	Buyer VARCHAR(64) FOREIGN KEY REFERENCES Users(Username),
	MinimumPrice DECIMAL(12,2),
	StandingBid DECIMAL(12,2),
	PRIMARY KEY(ID)
)
ALTER TABLE Auctions
ADD ClosingDate DateTime

ALTER TABLE Auctions
ADD Closed BIT
