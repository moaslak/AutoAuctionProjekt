CREATE PROCEDURE CreateTruck @name VARCHAR(32), @Km DECIMAL(12,2), @RegistrationNumber VARCHAR(16),
	@Year int, @NewPrice DECIMAL(12,2), @HasTowbar BIT, @EngineSize DECIMAL(8,2), @KmPrLiter DECIMAL(8,2),
	@DriversLicense VARCHAR(4), @FuelType VARCHAR(8), @EnergyClass VARCHAR(8), @Height DECIMAL(12,2),
	@Weight DECIMAL(12,2), @Length DECIMAL(12,2), @loadCapacity DECIMAL(12,2)
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
	INSERT INTO [dbo].[HeavyVehicle]
           ([VehicleID]
           ,[VehicleHeight]
           ,[VehicleWeight]
           ,[VehicleLength])
     VALUES
           (@VehicleID
           ,@Height
           ,@Weight
           ,@Length)
	DECLARE @HeavyVehicleID INT
	SET @HeavyVehicleID = SCOPE_IDENTITY()
	INSERT INTO [dbo].[Truck]
           ([HeavyVehicleID]
           ,[LoadCapacity])
     VALUES
           (@HeavyVehicleID
           ,@loadCapacity)