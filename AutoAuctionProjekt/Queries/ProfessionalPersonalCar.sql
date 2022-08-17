SELECT        dbo.PersonalCar.NumberOfSeats, dbo.PersonalCar.TrunkHeight, dbo.PersonalCar.TrunkWidth, dbo.PersonalCar.TrunkDepth, dbo.Vehicle.Name, dbo.Vehicle.Km, dbo.Vehicle.RegistrationNumber, dbo.Vehicle.Year, 
                         dbo.Vehicle.NewPrice, dbo.Vehicle.HasTowBar, dbo.Vehicle.EngineSize, dbo.Vehicle.KmPrLiter, dbo.Vehicle.DriversLicense, dbo.Vehicle.FuelType, dbo.Vehicle.EnergyClass, dbo.ProfessionalPersonalCar.ID, 
                         dbo.ProfessionalPersonalCar.HasSaftyBar, dbo.ProfessionalPersonalCar.LoadCapacity
FROM            dbo.Vehicle INNER JOIN
                         dbo.PersonalCar ON dbo.Vehicle.ID = dbo.PersonalCar.ID INNER JOIN
                         dbo.ProfessionalPersonalCar ON dbo.Vehicle.ID = dbo.ProfessionalPersonalCar.ID