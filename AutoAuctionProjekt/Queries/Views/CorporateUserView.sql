CREATE VIEW CorporateUserView as SELECT CorporateUser.ID, Users.ID as UserID, CorporateUser.Username, CorporateUser.CVRNumber, CorporateUser.Credit, Users.PasswordHash, 
	Users.UserZipCode, Users.Balance, Users.ZipcodeSeller FROM CorporateUser
join Users on CorporateUser.Username = Users.Username