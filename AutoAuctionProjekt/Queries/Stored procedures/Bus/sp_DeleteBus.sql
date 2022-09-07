CREATE PROCEDURE DeleteBus @ID INT 
	as
		DECLARE @HeavyVehicleID INT
		SET @HeavyVehicleID = (SELECT Bus.HeavyVehicleID FROM Bus WHERE Bus.ID = @ID)
		
		DECLARE @VehicleID INT
		SET @VehicleID = (SELECT HeavyVehicle.VehicleID FROM HeavyVehicle WHERE HeavyVehicle.ID = @HeavyVehicleID)

		DELETE FROM [dbo].[Bus]
			WHERE Bus.ID = @ID
		DELETE FROM [dbo].[HeavyVehicle]
			WHERE HeavyVehicle.ID = @HeavyVehicleID
		DELETE FROM [dbo].[Vehicle]
			WHERE Vehicle.ID = @VehicleID