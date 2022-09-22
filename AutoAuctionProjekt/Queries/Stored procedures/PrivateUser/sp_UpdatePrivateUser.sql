CREATE PROCEDURE UpdatePrivateUser @ID INT, @Username VARCHAR(64), @PasswordHash VARCHAR(64), @UserZipCode VARCHAR(8), @Balance DECIMAL(12,2),
	@ZipcodeSeller VARCHAR(8), @CPRNumber VARCHAR(10)
AS
UPDATE [dbo].[Users]
	SET [Username] = @Username
		,[PasswordHash] = @PasswordHash
		,[UserZipCode] = @UserZipCode
		,[Balance] = @Balance
		,[ZipcodeSeller] = @ZipcodeSeller
	WHERE Users.ID = @ID
UPDATE [dbo].[PrivateUser]
	SET [Username] = (SELECT Users.Username FROM Users WHERE Users.Username = @Username)
	,[CPRNumber] = @CPRNumber
	WHERE PrivateUser.Username = @Username