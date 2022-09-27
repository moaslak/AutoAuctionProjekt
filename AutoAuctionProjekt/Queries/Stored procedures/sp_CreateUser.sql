CREATE PROCEDURE [dbo].[CreateUser] @UserName VARCHAR(64)
AS
DECLARE @query VARCHAR(max)
SET @query = 'CREATE USER ' + @UserName + ' FOR LOGIN mort40f4'
exec(@query)