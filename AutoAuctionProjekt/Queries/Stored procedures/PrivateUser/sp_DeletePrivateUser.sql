CREATE PROCEDURE DeletePrivateUser @ID INT
AS
DECLARE @Username VARCHAR(32)
SET @Username = (SELECT PrivateUserView.Username FROM PrivateUserView WHERE PrivateUserView.UserID = @ID)
DELETE FROM PrivateUser WHERE PrivateUser.Username = @Username
DELETE FROM Users WHERE Users.Username = @Username
