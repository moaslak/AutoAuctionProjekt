  CREATE PROCEDURE SelectCorporateUserByID @Username VARCHAR(64)
  AS
  SELECT * FROM CorporateUserView WHERE CorporateUserView.Username = @Username