CREATE PROCEDURE GetProfessionalPersonalCars
as
SELECT Vehicle.ID, ProfessionalPersonalCar.HasSaftyBar, ProfessionalPersonalCar.LoadCapacity,
	Vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber, PersonalCar.NumberOfSeats, PersonalCar.TrunkHeight, 
	PersonalCar.TrunkWidth, PersonalCar.TrunkDepth, Vehicle.Year, Vehicle.NewPrice, Vehicle.hasTowBar, Vehicle.EngineSize, Vehicle.KmPrLiter,
	Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass FROM [dbo].[ProfessionalPersonalCar]
	join PersonalCar on ProfessionalPersonalCar.PersonalCarID = PersonalCar.ID
	join Vehicle on PersonalCar.VehicleID = Vehicle.ID