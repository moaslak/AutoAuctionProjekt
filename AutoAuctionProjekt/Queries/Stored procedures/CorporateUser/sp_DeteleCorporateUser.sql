CREATE PROCEDURE DeleteCorporateUser @ID INT
AS
DECLARE @Username VARCHAR(32)
SET @Username = (SELECT CorporateUserView.Username FROM CorporateUserView WHERE CorporateUserView.UserID = @ID)
DELETE FROM CorporateUser WHERE CorporateUser.Username = @Username
DELETE FROM Users WHERE Users.Username = @Username