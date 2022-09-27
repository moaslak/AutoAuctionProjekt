SELECT        dbo.Auctions.ID, dbo.Vehicle.ID AS VehicleID, dbo.Users.Username, dbo.Users.PasswordHash, dbo.Users.UserZipCode, dbo.Users.Balance, dbo.Users.ZipcodeSeller, dbo.Vehicle.Name, dbo.Vehicle.Km, 
                         dbo.Vehicle.RegistrationNumber, dbo.Vehicle.Year, dbo.Vehicle.NewPrice, dbo.Vehicle.HasTowBar, dbo.Vehicle.EngineSize, dbo.Vehicle.KmPrLiter, dbo.Vehicle.DriversLicense, dbo.Vehicle.FuelType, dbo.Vehicle.EnergyClass, 
                         dbo.Auctions.Seller, dbo.Auctions.Buyer, dbo.Auctions.MinimumPrice, dbo.Auctions.StandingBid, dbo.Auctions.ClosingDate, dbo.Auctions.Closed
FROM            dbo.Auctions INNER JOIN
                         dbo.Vehicle ON dbo.Auctions.VehicleID = dbo.Vehicle.ID INNER JOIN
                         dbo.Users ON dbo.Auctions.Seller = dbo.Users.Username AND dbo.Auctions.Buyer = dbo.Users.Username