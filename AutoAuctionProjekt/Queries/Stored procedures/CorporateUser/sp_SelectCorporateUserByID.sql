  CREATE PROCEDURE SelectCorporateUserByID @ID INT
  AS
  SELECT * FROM CorporateUserView WHERE CorporateUserView.UserID = @ID