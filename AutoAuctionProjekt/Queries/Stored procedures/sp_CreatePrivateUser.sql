CREATE PROCEDURE CreatePrivateUser @Username VARCHAR(64), @CprNumber VARCHAR(10)
as
DECLARE @userID VARCHAR(64)
begin
INSERT INTO [dbo].[Users]
	([Username])
	VALUES
	(@Username)
	SET @userID = SCOPE_IDENTITY()
	end
	INSERT INTO [dbo].[PrivateUser]
	([Username]
	,[CPRNumber])
	VALUES
	(@userID
	,@CprNumber)