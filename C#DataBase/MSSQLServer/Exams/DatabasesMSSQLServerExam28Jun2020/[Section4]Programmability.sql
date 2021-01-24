--Get Colonists Count 

CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN
		DECLARE @result INT = (SELECT
									COUNT(*) as [COUNT]
										FROM TravelCards as tc 
											JOIN Journeys as j ON tc.JourneyId = j.Id
											JOIN Spaceports as s ON j.DestinationSpaceportId = s.Id
											JOIN Planets as p ON s.PlanetId = p.Id
									WHERE p.Name = @PlanetName
									GROUP BY p.Name)
	
		IF(@result >= 0)
		BEGIN
		RETURN @result;
		END
		ELSE
		BEGIN
		RETURN 0;
		END

		return ''
END
GO

SELECT dbo.udf_GetColonistsCount('Mars') 


--Change Journey Purpose

CREATE OR ALTER PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
	BEGIN TRANSACTION
	IF((SELECT Id
		FROM Journeys
		WHERE Id = @JourneyId) IS NULL)
		BEGIN
			THROW 50001, 'The journey does not exist!', 1;
		END

	IF((SELECT TOP(1) Purpose
		FROM Journeys
		WHERE Purpose = @NewPurpose AND Id = @JourneyId) IS NOT NULL)
		BEGIN
			THROW 50002, 'You cannot change the purpose!', 1;
		END

	UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
		
COMMIT
END

EXEC usp_ChangeJourneyPurpose 2, 'Educational' 

--You cannot change the purpose! 

EXEC usp_ChangeJourneyPurpose 196, 'Technical'
--The journey does not exist!

EXEC usp_ChangeJourneyPurpose 4, 'Technical' 