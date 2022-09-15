-- TRUCK --
CREATE PROCEDURE FindTruckByRegNumber @RegistrationNumber VARCHAR(64)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE RegistrationNumber LIKE @RegistrationNumber

CREATE PROCEDURE FindTruckByID @ID INT
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE VehicleID = @ID

CREATE PROCEDURE FindTruckByName @Name VARCHAR(64)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE Name LIKE @Name

CREATE PROCEDURE FindTruckByKm @KmMin DECIMAL(12,2), @KmMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE Km >= @KmMin AND Km <= @KmMax

CREATE PROCEDURE FindTrcukByYear @YearMin INT, @YearMax INT
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE Year >= @YearMin AND Year <= @YearMax

CREATE PROCEDURE FindTruckByNewPrice @NewPriceMin DECIMAL(12,2), @NewPriceMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE NewPrice >= @NewPriceMin AND NewPrice <= @NewPriceMax

CREATE PROCEDURE FindTruckByHasTowBar @HasTowBar BIT
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE HasTowBar = @HasTowBar

CREATE PROCEDURE FindTruckByEngineSize @EngineSizeMin DECIMAL(8,2), @EngineSizeMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE EngineSize >= @EngineSizeMin AND EngineSize <= @EngineSizeMax

CREATE PROCEDURE FindTruckByKmPrLiter @KmPrLiterMin DECIMAL(8,2), @KmPrLiterMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE KmPrLiter >= @KmPrLiterMin AND KmPrLiter <= @KmPrLiterMax

CREATE PROCEDURE FindTruckByDriversLicense @DriversLicense VARCHAR(4)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE DriversLicense LIKE @DriversLicense

CREATE PROCEDURE FindTruckByFuelType @FuelType VARCHAR(16)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE FuelType LIKE @FuelType

CREATE PROCEDURE FindTruckByEnergyClass @EnergyClass VARCHAR(8)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE EnergyClass LIKE @EnergyClass

CREATE PROCEDURE FindTruckByVehicleHeight @VehicleHeightMin DECIMAL(12,2), @VehicleHeightMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE VehicleHeight >= @VehicleHeightMin AND VehicleHeight <= @VehicleHeightMax


CREATE PROCEDURE FindTruckByVehicleWeight @VehicleWeightMin DECIMAL(12,2), @VehicleWeightMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE VehicleWeight >= @VehicleWeightMin AND VehicleWeight <= @VehicleWeightMax


CREATE PROCEDURE FindTruckByVehicleLength @VehicleLengthMin DECIMAL(12,2), @VehicleLengthMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE VehicleLength >= @VehicleLengthMin AND VehicleLength <= @VehicleLengthMax


CREATE PROCEDURE FindTruckByLoadCapacity @LoadCapacityMin DECIMAL(12,2), @LoadCapacityMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[TruckView]
	WHERE LoadCapacity >= @LoadCapacityMin AND LoadCapacity <= @LoadCapacityMax

-- BUS --
CREATE PROCEDURE FindBusByRegNumber @RegistrationNumber VARCHAR(64)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE RegistrationNumber LIKE @RegistrationNumber

CREATE PROCEDURE FindBusByID @ID INT
AS
	SELECT * FROM [dbo].[BusView]
	WHERE VehicleID = @ID

CREATE PROCEDURE FindBusByName @Name VARCHAR(64)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE Name LIKE @Name

CREATE PROCEDURE FindBusByKm @KmMin DECIMAL(12,2), @KmMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE Km >= @KmMin AND Km <= @KmMax

CREATE PROCEDURE FindBusByYear @YearMin INT, @YearMax INT
AS
	SELECT * FROM [dbo].[BusView]
	WHERE Year >= @YearMin AND Year <= @YearMax

CREATE PROCEDURE FindBusByNewPrice @NewPriceMin DECIMAL(12,2), @NewPriceMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE NewPrice >= @NewPriceMin AND NewPrice <= @NewPriceMax

CREATE PROCEDURE FindBusByHasTowBar @HasTowBar BIT
AS
	SELECT * FROM [dbo].[BusView]
	WHERE HasTowBar = @HasTowBar

CREATE PROCEDURE FindBusByEngineSize @EngineSizeMin DECIMAL(8,2), @EngineSizeMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE EngineSize >= @EngineSizeMin AND EngineSize <= @EngineSizeMax

CREATE PROCEDURE FindBusByKmPrLiter @KmPrLiterMin DECIMAL(8,2), @KmPrLiterMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE KmPrLiter >= @KmPrLiterMin AND KmPrLiter <= @KmPrLiterMax

CREATE PROCEDURE FindBusByDriversLicense @DriversLicense VARCHAR(4)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE DriversLicense LIKE @DriversLicense

CREATE PROCEDURE FindBusByFuelType @FuelType VARCHAR(16)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE FuelType LIKE @FuelType

CREATE PROCEDURE FindBusByEnergyClass @EnergyClass VARCHAR(8)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE EnergyClass LIKE @EnergyClass

CREATE PROCEDURE FindBusByVehicleHeight @VehicleHeightMin DECIMAL(12,2), @VehicleHeightMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE VehicleHeight >= @VehicleHeightMin AND VehicleHeight <= @VehicleHeightMax

CREATE PROCEDURE FindBusByVehicleWeight @VehicleWeightMin DECIMAL(12,2), @VehicleWeightMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE VehicleWeight >= @VehicleWeightMin AND VehicleWeight <= @VehicleWeightMax

CREATE PROCEDURE FindBusByVehicleLength @VehicleLengthMin DECIMAL(12,2), @VehicleLengthMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE VehicleLength >= @VehicleLengthMin AND VehicleLength <= @VehicleLengthMax

CREATE PROCEDURE FindBusByNumberOfSeats @NumberOfSeatsMin DECIMAL(12,2), @NumberOfSeatsMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE NumberOfSeats >= @NumberOfSeatsMin AND NumberOfSeats <= @NumberOfSeatsMax

CREATE PROCEDURE FindBusByNumberOfSleepingSpaces @NumberOfSleepingSpacesMin DECIMAL(12,2), @NumberOfSleepingSpacesMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[BusView]
	WHERE NumberOfSleepingSpaces >= @NumberOfSleepingSpacesMin AND NumberOfSleepingSpaces <= @NumberOfSleepingSpacesMax

CREATE PROCEDURE FindBusByHasToilet @HasToilet BIT
AS
	SELECT * FROM [dbo].[BusView]
	WHERE HasToilet LIKE @HasToilet


-- Professional personal car --
CREATE PROCEDURE FindProfessionalCarByRegNumber @RegistrationNumber VARCHAR(64)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE RegistrationNumber LIKE @RegistrationNumber

CREATE PROCEDURE FindProfessionalCarByID @ID INT
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE VehicleID = @ID

CREATE PROCEDURE FindProfessionalCarByName @Name VARCHAR(64)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE Name LIKE @Name

CREATE PROCEDURE FindProfessionalCarByKm @KmMin DECIMAL(12,2), @KmMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE Km >= @KmMin AND Km <= @KmMax

CREATE PROCEDURE FindProfessionalCarByYear @YearMin INT, @YearMax INT
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE Year >= @YearMin AND Year <= @YearMax

CREATE PROCEDURE FindProfessionalCarByNewPrice @NewPriceMin DECIMAL(12,2), @NewPriceMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE NewPrice >= @NewPriceMin AND NewPrice <= @NewPriceMax

CREATE PROCEDURE FindProfessionalCarByHasTowBar @HasTowBar BIT
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE HasTowBar = @HasTowBar

CREATE PROCEDURE FindProfessionalCarByEngineSize @EngineSizeMin DECIMAL(8,2), @EngineSizeMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE EngineSize >= @EngineSizeMin AND EngineSize <= @EngineSizeMax

CREATE PROCEDURE FindProfessionalCarByKmPrLiter @KmPrLiterMin DECIMAL(8,2), @KmPrLiterMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE KmPrLiter >= @KmPrLiterMin AND KmPrLiter <= @KmPrLiterMax

CREATE PROCEDURE FindProfessionalCarByDriversLicense @DriversLicense VARCHAR(4)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE DriversLicense LIKE @DriversLicense

CREATE PROCEDURE FindProfessionalCarByFuelType @FuelType VARCHAR(16)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE FuelType LIKE @FuelType

CREATE PROCEDURE FindProfessionalCarByEnergyClass @EnergyClass VARCHAR(8)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE EnergyClass LIKE @EnergyClass

CREATE PROCEDURE FindProfessionalCarByNumberOfSeats @NumberOfSeatsMin DECIMAL(12,2), @NumberOfSeatsMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE NumberOfSeats >= @NumberOfSeatsMin AND NumberOfSeats <= @NumberOfSeatsMax

CREATE PROCEDURE FindProfessionalCarByTrunkHeight @TrunkHeightMin DECIMAL(12,2), @TrunkHeightMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE TrunkHeight >= @TrunkHeightMin AND TrunkHeight <= @TrunkHeightMax

CREATE PROCEDURE FindProfessionalCarByTrunkWidth @TrunkWidthMin DECIMAL(12,2), @TrunkWidthMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE TrunkWidth >= @TrunkWidthMin AND TrunkWidth <= @TrunkWidthMax

CREATE PROCEDURE FindProfessionalCarByTrunkDepth @TrunkDepthMin DECIMAL(12,2), @TrunkDepthMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE TrunkDepth >= @TrunkDepthMin AND TrunkDepth <= @TrunkDepthMax

CREATE PROCEDURE FindProfessionalCarByHasSaftyBar @HasSaftyBar BIT
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE HasSaftyBar LIKE @HasSaftyBar

CREATE PROCEDURE FindProfessionalCarByLoadCapacity @LoadCapacityMin DECIMAL(12,2), @LoadCapacityMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[ProfessionalPersonalCarView]
	WHERE LoadCapacity >= @LoadCapacityMin AND LoadCapacity <= @LoadCapacityMax


-- Private personal car -- 
CREATE PROCEDURE FindPrivateCarByRegNumber @RegistrationNumber VARCHAR(64)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE RegistrationNumber LIKE @RegistrationNumber

CREATE PROCEDURE FindPrivateCarByID @ID INT
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE VehicleID = @ID

CREATE PROCEDURE FindPrivateCarByName @Name VARCHAR(64)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE Name LIKE @Name

CREATE PROCEDURE FindPrivateCarByKm @KmMin DECIMAL(12,2), @KmMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE Km >= @KmMin AND Km <= @KmMax

CREATE PROCEDURE FindPrivateCarByYear @YearMin INT, @YearMax INT
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE Year >= @YearMin AND Year <= @YearMax

CREATE PROCEDURE FindPrivateCarByNewPrice @NewPriceMin DECIMAL(12,2), @NewPriceMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE NewPrice >= @NewPriceMin AND NewPrice <= @NewPriceMax

CREATE PROCEDURE FindPrivateCarByHasTowBar @HasTowBar BIT
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE HasTowBar = @HasTowBar

CREATE PROCEDURE FindPrivateCarByEngineSize @EngineSizeMin DECIMAL(8,2), @EngineSizeMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE EngineSize >= @EngineSizeMin AND EngineSize <= @EngineSizeMax

CREATE PROCEDURE FindPrivateCarByKmPrLiter @KmPrLiterMin DECIMAL(8,2), @KmPrLiterMax DECIMAL(8,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE KmPrLiter >= @KmPrLiterMin AND KmPrLiter <= @KmPrLiterMax

CREATE PROCEDURE FindPrivateCarByDriversLicense @DriversLicense VARCHAR(4)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE DriversLicense LIKE @DriversLicense

CREATE PROCEDURE FindPrivateCarByFuelType @FuelType VARCHAR(16)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE FuelType LIKE @FuelType

CREATE PROCEDURE FindPrivateCarByEnergyClass @EnergyClass VARCHAR(8)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE EnergyClass LIKE @EnergyClass

CREATE PROCEDURE FindPrivateCarByNumberOfSeats @NumberOfSeatsMin DECIMAL(12,2), @NumberOfSeatsMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE NumberOfSeats >= @NumberOfSeatsMin AND NumberOfSeats <= @NumberOfSeatsMax

CREATE PROCEDURE FindPrivateCarByTrunkHeight @TrunkHeightMin DECIMAL(12,2), @TrunkHeightMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE TrunkHeight >= @TrunkHeightMin AND TrunkHeight <= @TrunkHeightMax

CREATE PROCEDURE FindPrivateCarByTrunkWidth @TrunkWidthMin DECIMAL(12,2), @TrunkWidthMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE TrunkWidth >= @TrunkWidthMin AND TrunkWidth <= @TrunkWidthMax

CREATE PROCEDURE FindPrivateCarByTrunkDepth @TrunkDepthMin DECIMAL(12,2), @TrunkDepthMax DECIMAL(12,2)
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE TrunkDepth >= @TrunkDepthMin AND TrunkDepth <= @TrunkDepthMax

CREATE PROCEDURE FindPrivateCarByISOFittings @HasISOFittings BIT
AS
	SELECT * FROM [dbo].[PrivatePersonalCarView]
	WHERE HasISOFittings LIKE @HasISOFittings

