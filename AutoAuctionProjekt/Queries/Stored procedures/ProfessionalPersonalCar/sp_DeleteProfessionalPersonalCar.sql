CREATE PROCEDURE DeleteProfessionalPersonalCar @ID INT 
	as
		DECLARE @PersonalCarID INT
		SET @PersonalCarID = (SELECT PersonalCar.ID FROM PersonalCar WHERE PersonalCar.VehicleID = @ID)
		
		DELETE FROM [dbo].[ProfessionalPersonalCar]
			WHERE ProfessionalPersonalCar.PersonalCarID = @PersonalCarID
		DELETE FROM [dbo].[PersonalCar]
			WHERE PersonalCar.ID = @PersonalCarID
		DELETE FROM [dbo].[Vehicle]
			WHERE Vehicle.ID = @ID