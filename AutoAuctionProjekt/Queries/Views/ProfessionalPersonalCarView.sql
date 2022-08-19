CREATE VIEW ProfessionalPersonalCarView as select ProfessionalPersonalCar.ID, vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber, Vehicle.Year, Vehicle.NewPrice, Vehicle.HasTowBar,
	Vehicle.EngineSize, Vehicle.KmPrLiter, Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass, PersonalCar.NumberOfSeats,
	PersonalCar.TrunkHeight, PersonalCar.TrunkWidth, PersonalCar.TrunkDepth, ProfessionalPersonalCar.HasSaftyBar, ProfessionalPersonalCar.LoadCapacity from ProfessionalPersonalCar
join PersonalCar on ProfessionalPersonalCar.PersonalCarID = PersonalCar.ID
join Vehicle on PersonalCar.VehicleID = Vehicle.id