CREATE PROCEDURE UpdateBus @name VARCHAR(32), @Km DECIMAL(12,2), @RegistrationNumber VARCHAR(16),
	@Year int, @NewPrice DECIMAL(12,2), @HasTowbar BIT, @EngineSize DECIMAL(8,2), @KmPrLiter DECIMAL(8,2),
	@DriversLicense VARCHAR(4), @FuelType VARCHAR(8), @EnergyClass VARCHAR(8), @Height DECIMAL(12,2),
	@Weight DECIMAL(12,2), @Length DECIMAL(12,2), @numberOfSeats INT, @numberOfSleepingSpaces INT,
	@hasToilet BIT, @vehicleID INT
	as
	UPDATE [dbo].[Vehicle]
		SET [Name] = @name
			,[Km] = @Km
			,[RegistrationNumber] = @RegistrationNumber
			,[Year] = @Year
			,[NewPrice] = @NewPrice
			,[HasTowBar] = @HasTowbar
			,[EngineSize] = @EngineSize
			,[KmPrLiter] = @KmPrLiter
			,[DriversLicense] = @DriversLicense
			,[FuelType] = @FuelType
			,[EnergyClass] = @EnergyClass
		WHERE Vehicle.ID = @vehicleID

		DECLARE @heavyVehicleID INT
		UPDATE [dbo].[HeavyVehicle]
		SET  [VehicleHeight] = @Height
		,[VehicleWeight] = @Weight
		,[VehicleLength] = @Length
		
		WHERE VehicleID = @VehicleID
		SET @heavyVehicleID = (SELECT HeavyVehicle.ID FROM HeavyVehicle WHERE HeavyVehicle.VehicleID = @vehicleID)  
		UPDATE [dbo].[Bus]
		SET [NumberOfSeats] = @numberOfSeats
			,[NumberOfSleepingSpaces] = @numberOfSleepingSpaces
			,[HasToilet] = @hasToilet
		WHERE Bus.HeavyVehicleID = @heavyVehicleID
GO