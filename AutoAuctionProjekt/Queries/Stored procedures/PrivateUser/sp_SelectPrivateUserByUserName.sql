  CREATE PROCEDURE SelectPrivateUserByUserName @Username VARCHAR(64)
  AS
  SELECT * FROM PrivateUserView WHERE PrivateUserView.Username = @Username