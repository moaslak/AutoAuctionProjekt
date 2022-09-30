CREATE PROCEDURE [dbo].[SelectAuctionsForUser] @Username VARCHAR(64)
AS
SELECT * FROM Auctions
WHERE Seller = @Username OR Buyer = @Username