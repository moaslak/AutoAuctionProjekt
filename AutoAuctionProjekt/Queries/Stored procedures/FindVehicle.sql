DECLARE @searchParam VARCHAR(64);
SET @searchParam = 'hest'

CREATE PROCEDURE FindByRegNumber @RegistrationNumber VARCHAR(64)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE RegistrationNumber LIKE @RegistrationNumber

CREATE PROCEDURE FindByID @ID INT
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE ID = @ID

CREATE PROCEDURE FindByName @Name VARCHAR(64)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE Name LIKE @Name

CREATE PROCEDURE FindByKm @KmMin DECIMAL(12,2), @KmMax DECIMAL(12,2)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE Km >= @KmMin AND Km <= @KmMax

CREATE PROCEDURE FindByYear @YearMin INT, @YearMax INT
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE Year >= @YearMin AND Year <= @YearMax

CREATE PROCEDURE FindByNewPrice @NewPriceMin DECIMAL(12,2), @NewPriceMax DECIMAL(12,2)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE NewPrice >= @NewPriceMin AND NewPrice <= @NewPriceMax

CREATE PROCEDURE FindByHasTow @HasTowBar BIT
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE HasTowBar = @HasTowBar

CREATE PROCEDURE FindByEngineSize @EngineSizeMin DECIMAL(8,2), @EngineSizeMax DECIMAL(8,2)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE EngineSize >= @EngineSizeMin AND EngineSize <= @EngineSizeMax

CREATE PROCEDURE FindByKmPrLiter @KmPrLiterMin DECIMAL(8,2), @KmPrLiterMax DECIMAL(8,2)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE KmPrLiter >= @KmPrLiterMin AND KmPrLiter <= @KmPrLiterMax

CREATE PROCEDURE FindByDriversLicense @DriversLicense VARCHAR(4)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE DriversLicense LIKE @DriversLicense

CREATE PROCEDURE FindByFuelType @FuelType VARCHAR(16)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE FuelType LIKE @FuelType

CREATE PROCEDURE FindByEnergyClass @EnergyClass VARCHAR(8)
as
	SELECT * FROM [dbo].[Vehicle]
	WHERE EnergyClass LIKE @EnergyClass