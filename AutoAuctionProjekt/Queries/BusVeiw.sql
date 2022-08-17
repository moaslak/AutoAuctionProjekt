SELECT        dbo.Bus.ID, dbo.Bus.NumberOfSeats, dbo.Bus.NumberOfSleepingSpaces, dbo.Bus.HasToilet, dbo.HeavyVehicle.VehicleHeight, dbo.HeavyVehicle.VehicleWeight, dbo.HeavyVehicle.VehicleLength, dbo.Vehicle.Name, 
                         dbo.Vehicle.Km, dbo.Vehicle.RegistrationNumber, dbo.Vehicle.Year, dbo.Vehicle.NewPrice, dbo.Vehicle.HasTowBar, dbo.Vehicle.EngineSize, dbo.Vehicle.KmPrLiter, dbo.Vehicle.DriversLicense, dbo.Vehicle.FuelType, 
                         dbo.Vehicle.EnergyClass
FROM            dbo.Bus INNER JOIN
                         dbo.HeavyVehicle ON dbo.Bus.ID = dbo.HeavyVehicle.ID INNER JOIN
                         dbo.Vehicle ON dbo.Bus.ID = dbo.Vehicle.ID