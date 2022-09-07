CREATE PROCEDURE DeleteTruck @ID INT 
	as
		DECLARE @HeavyVehicleID INT
		SET @HeavyVehicleID = (SELECT Truck.HeavyVehicleID FROM Truck WHERE Truck.ID = @ID)
		
		DECLARE @VehicleID INT
		SET @VehicleID = (SELECT HeavyVehicle.VehicleID FROM HeavyVehicle WHERE HeavyVehicle.ID = @HeavyVehicleID)

		DELETE FROM [dbo].[Truck]
			WHERE Truck.ID = @ID
		DELETE FROM [dbo].[HeavyVehicle]
			WHERE HeavyVehicle.ID = @HeavyVehicleID
		DELETE FROM [dbo].[Vehicle]
			WHERE Vehicle.ID = @VehicleID