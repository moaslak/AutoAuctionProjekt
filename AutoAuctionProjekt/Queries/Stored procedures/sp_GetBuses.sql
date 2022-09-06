CREATE PROCEDURE GetBuses
as
SELECT bus.ID, bus.NumberOfSeats, bus.NumberOfSleepingSpaces, bus.hasToilet, HeavyVehicle.VehicleHeight, HeavyVehicle.VehicleWeight, 
	HeavyVehicle.VehicleLength, Vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber,
	Vehicle.Year, Vehicle.NewPrice, Vehicle.hasTowBar, Vehicle.EngineSize, Vehicle.KmPrLiter,
	Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass FROM [dbo].[Bus]
	join HeavyVehicle on bus.HeavyVehicleID = HeavyVehicle.ID
	join Vehicle on HeavyVehicle.VehicleID = Vehicle.ID