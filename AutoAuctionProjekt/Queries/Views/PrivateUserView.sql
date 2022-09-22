CREATE VIEW PrivateUserView as SELECT PrivateUser.ID, Users.ID as UserID, PrivateUser.Username, PrivateUser.CPRNumber, Users.PasswordHash, 
	Users.UserZipCode, Users.Balance, Users.ZipcodeSeller FROM PrivateUser
join Users on PrivateUser.Username = Users.Username