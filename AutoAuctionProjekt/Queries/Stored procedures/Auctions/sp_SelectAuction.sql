﻿CREATE PROCEDURE SelectAuction @ID INT
AS
SELECT * FROM Auctions
WHERE ID = @ID