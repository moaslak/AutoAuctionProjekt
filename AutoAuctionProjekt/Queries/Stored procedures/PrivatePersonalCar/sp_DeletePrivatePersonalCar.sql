CREATE PROCEDURE DeletePrivatePersonalCar @ID INT 
	as
		DECLARE @PersonalCarID INT
		SET @PersonalCarID = (SELECT PersonalCar.ID FROM PersonalCar WHERE VehicleID = @ID)
		
		DELETE FROM [dbo].[PrivatePersonalCar]
			WHERE PrivatePersonalCar.PersonalCarID = @PersonalCarID
		DELETE FROM [dbo].[PersonalCar]
			WHERE PersonalCar.VehicleID = @ID
		DELETE FROM [dbo].[Vehicle]
			WHERE Vehicle.ID = @ID