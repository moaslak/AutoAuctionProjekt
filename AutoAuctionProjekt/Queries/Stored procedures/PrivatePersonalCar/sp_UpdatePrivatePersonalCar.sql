CREATE PROCEDURE UpdatePrivatePersonalCar @name VARCHAR(32), @Km DECIMAL(12,2), @RegistrationNumber VARCHAR(16),
	@Year int, @NewPrice DECIMAL(12,2), @HasTowbar BIT, @EngineSize DECIMAL(8,2), @KmPrLiter DECIMAL(8,2),
	@DriversLicense VARCHAR(4), @FuelType VARCHAR(8), @EnergyClass VARCHAR(8),@numberOfSeats DECIMAL(12,2), @TrunkHeight DECIMAL(12,2),
	@TrunkWidth DECIMAL(12,2), @TrunkDepth DECIMAL(12,2),@hasISOFix Bit, @vehicleID INT
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

		DECLARE @PersonalCarID INT
		UPDATE [dbo].[PersonalCar]
		SET  [NumberOfSeats] = @numberOfSeats
		,[TrunkHeight] = @TrunkHeight
		,[TrunkWidth] = @TrunkWidth
		,[TrunkDepth] = @TrunkDepth
		
		WHERE PersonalCar.VehicleID = @VehicleID
		SET @PersonalCarID = (SELECT PersonalCar.ID FROM PersonalCar WHERE PersonalCar.VehicleID = @vehicleID)  
		UPDATE [dbo].[PrivatePersonalCar]
		SET [HasISOFittings] = @hasISOFix
		WHERE PrivatePersonalCar.PersonalCarID = @PersonalCarID
GO