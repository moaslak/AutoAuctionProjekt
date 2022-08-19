CREATE VIEW BusView as select Bus.ID, Vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber, Vehicle.NewPrice, Vehicle.Year, Vehicle.HasTowBar, Vehicle.EngineSize, Vehicle.KmPrLiter, 
	Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass, HeavyVehicle.VehicleHeight, HeavyVehicle.VehicleLength, HeavyVehicle.VehicleWeight,
	bus.NumberOfSeats, bus.NumberOfSleepingSpaces, bus.HasToilet From Bus
  join HeavyVehicle on bus.HeavyVehicleID = HeavyVehicle.ID
  join Vehicle on HeavyVehicle.VehicleID = Vehicle.ID