  CREATE PROCEDURE SelectPrivateUserByID @ID INT
  AS
  SELECT * FROM PrivateUserView WHERE PrivateUserView.ID = @ID