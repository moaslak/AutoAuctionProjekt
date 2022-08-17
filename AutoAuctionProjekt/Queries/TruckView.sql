SELECT        dbo.Truck.ID, dbo.Truck.LoadCapacity, dbo.HeavyVehicle.VehicleHeight, dbo.HeavyVehicle.VehicleWeight, dbo.HeavyVehicle.VehicleLength, dbo.Vehicle.Name, dbo.Vehicle.Km, dbo.Vehicle.RegistrationNumber, 
                         dbo.Vehicle.Year, dbo.Vehicle.NewPrice, dbo.Vehicle.HasTowBar, dbo.Vehicle.EngineSize, dbo.Vehicle.KmPrLiter, dbo.Vehicle.DriversLicense, dbo.Vehicle.FuelType, dbo.Vehicle.EnergyClass
FROM            dbo.Vehicle INNER JOIN
                         dbo.HeavyVehicle ON dbo.Vehicle.ID = dbo.HeavyVehicle.ID INNER JOIN
                         dbo.Truck ON dbo.Vehicle.ID = dbo.Truck.ID