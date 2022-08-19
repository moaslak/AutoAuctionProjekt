CREATE PROCEDURE DeleteProfessionalPersonalCar @ID INT 
	as
		DECLARE @PersonalCarID INT
		SET @PersonalCarID = (SELECT ProfessionalPersonalCar.PersonalCarID FROM ProfessionalPersonalCar WHERE ProfessionalPersonalCar.ID = @ID)
		
		DECLARE @VehicleID INT
		SET @VehicleID = (SELECT PersonalCar.VehicleID FROM PersonalCar WHERE PersonalCar.ID = @PersonalCarID)

		DELETE FROM [dbo].[ProfessionalPersonalCar]
			WHERE ProfessionalPersonalCar.ID = @ID
		DELETE FROM [dbo].[PersonalCar]
			WHERE PersonalCar.ID = @PersonalCarID
		DELETE FROM [dbo].[Vehicle]
			WHERE Vehicle.ID = @VehicleID