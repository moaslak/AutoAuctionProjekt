SELECT        dbo.PrivatePersonalCar.ID, dbo.PrivatePersonalCar.HasISOFittings, dbo.PersonalCar.NumberOfSeats, dbo.PersonalCar.TrunkHeight, dbo.PersonalCar.TrunkWidth, dbo.PersonalCar.TrunkDepth, dbo.Vehicle.Name, 
                         dbo.Vehicle.Km, dbo.Vehicle.RegistrationNumber, dbo.Vehicle.Year, dbo.Vehicle.NewPrice, dbo.Vehicle.HasTowBar, dbo.Vehicle.EngineSize, dbo.Vehicle.KmPrLiter, dbo.Vehicle.DriversLicense, dbo.Vehicle.FuelType, 
                         dbo.Vehicle.EnergyClass
FROM            dbo.Vehicle INNER JOIN
                         dbo.PersonalCar ON dbo.Vehicle.ID = dbo.PersonalCar.ID INNER JOIN
                         dbo.PrivatePersonalCar ON dbo.Vehicle.ID = dbo.PrivatePersonalCar.ID