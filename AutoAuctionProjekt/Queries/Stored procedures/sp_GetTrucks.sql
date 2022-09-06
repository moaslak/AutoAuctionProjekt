CREATE PROCEDURE GetTrucks
as
SELECT truck.ID, truck.LoadCapacity, HeavyVehicle.VehicleHeight, HeavyVehicle.VehicleWeight, 
	HeavyVehicle.VehicleLength, Vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber,
	Vehicle.Year, Vehicle.NewPrice, Vehicle.hasTowBar, Vehicle.EngineSize, Vehicle.KmPrLiter,
	Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass FROM [dbo].[truck]
	join HeavyVehicle on Truck.HeavyVehicleID = HeavyVehicle.ID
	join Vehicle on HeavyVehicle.VehicleID = Vehicle.ID
