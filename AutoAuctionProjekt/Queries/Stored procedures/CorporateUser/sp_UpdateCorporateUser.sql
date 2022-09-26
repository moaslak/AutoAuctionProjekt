CREATE PROCEDURE UpdateCorporateUser @ID INT, @Username VARCHAR(64), @PasswordHash VARCHAR(64), @UserZipCode VARCHAR(8), @Balance DECIMAL(12,2),
	@ZipcodeSeller VARCHAR(8), @CVRNumber VARCHAR(12), @Credit MONEY
AS
UPDATE [dbo].[Users]
	SET [Username] = @Username
		,[PasswordHash] = @PasswordHash
		,[UserZipCode] = @UserZipCode
		,[Balance] = @Balance
		,[ZipcodeSeller] = @ZipcodeSeller
	WHERE Users.ID = @ID
UPDATE [dbo].[CorporateUser]
	SET [Username] = (SELECT Users.Username FROM Users WHERE Users.Username = @Username)
	,[CVRNumber] = @CVRNumber
	,[Credit] = @Credit
	WHERE CorporateUser.Username = @Username