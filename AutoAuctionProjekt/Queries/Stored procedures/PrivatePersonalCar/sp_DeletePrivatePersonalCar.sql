CREATE PROCEDURE DeletePrivatePersonalCar @ID INT 
	as
		DECLARE @PersonalCarID INT
		SET @PersonalCarID = (SELECT PrivatePersonalCar.PersonalCarID FROM PrivatePersonalCar WHERE PrivatePersonalCar.ID = @ID)
		
		DECLARE @VehicleID INT
		SET @VehicleID = (SELECT PersonalCar.VehicleID FROM PersonalCar WHERE PersonalCar.ID = @PersonalCarID)

		DELETE FROM [dbo].[PrivatePersonalCar]
			WHERE PrivatePersonalCar.ID = @ID
		DELETE FROM [dbo].[PersonalCar]
			WHERE PersonalCar.ID = @PersonalCarID
		DELETE FROM [dbo].[Vehicle]
			WHERE Vehicle.ID = @VehicleID
