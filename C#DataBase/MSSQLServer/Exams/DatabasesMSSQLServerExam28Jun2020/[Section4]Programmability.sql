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