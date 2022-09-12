CREATE PROCEDURE GetPrivatePersonalCars
as
SELECT Vehicle.ID, PrivatePersonalCar.HasISOFittings,
	Vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber, PersonalCar.NumberOfSeats, PersonalCar.TrunkHeight, 
	PersonalCar.TrunkWidth, PersonalCar.TrunkDepth, Vehicle.Year, Vehicle.NewPrice, Vehicle.hasTowBar, Vehicle.EngineSize, Vehicle.KmPrLiter,
	Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass FROM [dbo].[PrivatePersonalCar]
	join PersonalCar on PrivatePersonalCar.PersonalCarID = PersonalCar.ID
	join Vehicle on PersonalCar.VehicleID = Vehicle.ID