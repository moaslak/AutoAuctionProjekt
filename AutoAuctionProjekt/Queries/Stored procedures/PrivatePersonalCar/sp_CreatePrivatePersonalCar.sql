CREATE PROCEDURE CreatePrivatePersonalCar @name VARCHAR(32), @Km DECIMAL(12,2), @RegistrationNumber VARCHAR(16),
	@Year int, @NewPrice DECIMAL(12,2), @HasTowbar BIT, @EngineSize DECIMAL(8,2), @KmPrLiter DECIMAL(8,2),
	@DriversLicense VARCHAR(4), @FuelType VARCHAR(8), @EnergyClass VARCHAR(8),@numberOfSeats DECIMAL(12,2), @TrunkHeight DECIMAL(12,2),
	@TrunkWidth DECIMAL(12,2), @TrunkDepth DECIMAL(12,2),@hasISOfitting BIT
	as 
	DECLARE @VehicleID INT
	
	begin
	INSERT INTO [dbo].[Vehicle]
           ([Name]
           ,[Km]
           ,[RegistrationNumber]
           ,[Year]
           ,[NewPrice]
           ,[HasTowBar]
           ,[EngineSize]
           ,[KmPrLiter]
           ,[DriversLicense]
           ,[FuelType]
           ,[EnergyClass])	
     VALUES
           (@name
           ,@Km
           ,@RegistrationNumber
           ,@Year
           ,@NewPrice
           ,@HasTowbar
           ,@EngineSize
           ,@KmPrLiter
           ,@DriversLicense
           ,@FuelType
           ,@EnergyClass)
	SET @VehicleID = SCOPE_IDENTITY()
	end
	INSERT INTO [dbo].[PersonalCar]
           ([VehicleID]
           ,[NumberOfSeats]
           ,[TrunkHeight]
           ,[TrunkWidth]
           ,[TrunkDepth])
     VALUES
           (@VehicleID
           ,@numberOfSeats
           ,@TrunkHeight
           ,@TrunkWidth
           ,@TrunkDepth)
	DECLARE @PersonalCarID INT
	SET @PersonalCarID = SCOPE_IDENTITY()
	INSERT INTO [dbo].[PrivatePersonalCar]
           ([PersonalCarID]
           ,[HasISOFittings])
     VALUES
           (@PersonalCarID
           ,@hasISOfitting)