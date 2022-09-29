  CREATE PROCEDURE SelectCorporateUserByUsername @Username VARCHAR(64)
  AS
  SELECT * FROM CorporateUserView WHERE CorporateUserView.Username = @Username