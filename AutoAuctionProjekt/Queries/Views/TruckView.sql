CREATE VIEW TruckView as select Vehicle.Name, Vehicle.Km, Vehicle.RegistrationNumber, Vehicle.NewPrice, Vehicle.Year, Vehicle.HasTowBar, Vehicle.EngineSize, Vehicle.KmPrLiter, 
	Vehicle.DriversLicense, Vehicle.FuelType, Vehicle.EnergyClass, HeavyVehicle.VehicleHeight, HeavyVehicle.VehicleLength, HeavyVehicle.VehicleWeight,
	truck.LoadCapacity From Truck
  join HeavyVehicle on truck.HeavyVehicleID = HeavyVehicle.ID
  join Vehicle on HeavyVehicle.VehicleID = Vehicle.ID