CREATE PROCEDURE CreateCorporateUser @Username VARCHAR(64), @PasswordHash VARCHAR(64), @UserZipCode VARCHAR(8),
	@Balance DECIMAL(12,2), @ZipcodeSeller VARCHAR(8), @CVRNumber VARCHAR(12), @Credit MONEY 
	as 
	DECLARE @UserID INT
	begin
	INSERT INTO [dbo].[Users]
	(
		[Username]
		,[PasswordHash]
		,[UserZipCode]
		,[Balance]
		,[ZipcodeSeller]
	)
	VALUES
	(
		@Username
		,@PasswordHash
		,@UserZipCode
		,@Balance
		,@ZipcodeSeller
	)
	SET @UserID = SCOPE_IDENTITY()
	end
	DECLARE @CorporateUserName VARCHAR(64)
	SET @CorporateUserName = (SELECT Users.Username FROM Users WHERE Users.ID = @UserID)
	INSERT INTO [dbo].[CorporateUser]
	(
		[Username]
		,[CVRNumber]
		,[Credit]
	)
	VALUES
	(
		@CorporateUserName
		,@CVRNumber
		,@Credit
	)