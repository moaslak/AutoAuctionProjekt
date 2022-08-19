CREATE VIEW PrivatePersonalCarView as select vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber, Vehicle.Year, Vehicle.NewPrice, Vehicle.HasTowBar,
	Vehicle.EngineSize, Vehicle.KmPrLiter, Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass, PersonalCar.NumberOfSeats,
	PersonalCar.TrunkHeight, PersonalCar.TrunkWidth, PersonalCar.TrunkDepth, PrivatePersonalCar.HasISOFittings from PrivatePersonalCar
join PersonalCar on PrivatePersonalCar.PersonalCarID = PersonalCar.ID
join Vehicle on PersonalCar.VehicleID = Vehicle.id