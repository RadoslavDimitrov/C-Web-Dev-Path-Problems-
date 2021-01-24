--Select all military journeys 

SELECT Id,
	FORMAT([JourneyStart],'dd/MM/yyyy') as [JourneyStart],
	FORMAT([JourneyEnd],'dd/MM/yyyy') as [JourneyStart]
	FROM Journeys as j
	WHERE Purpose IN ('Military')
	ORDER BY j.JourneyStart ASC

--Select all pilots 

SELECT c.Id,
	c.FirstName + ' ' + c.LastName as [full_name]
	FROM Colonists as c
	JOIN TravelCards as tc ON tc.ColonistId = c.Id
	WHERE tc.JobDuringJourney IN ('Pilot')
	ORDER BY c.Id ASC


--Count colonists 

SELECT COUNT(*)
	FROM Journeys as j
	JOIN TravelCards as tc ON tc.JourneyId = j.Id
	JOIN Colonists as c ON tc.ColonistId = c.Id
	WHERE j.Purpose IN ('Technical')

--Select spaceships with pilots younger than 30 years 

SELECT s.[Name],
	s.[Manufacturer]
	FROM TravelCards as tc
	JOIN Colonists as c ON tc.ColonistId = c.Id
	JOIN Journeys as j ON tc.JourneyId = j.Id
	JOIN Spaceships as s ON j.SpaceshipId = s.Id
	WHERE tc.JobDuringJourney IN ('Pilot') 
		AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
	ORDER BY s.[Name] ASC


--Select all planets and their journey count 

SELECT p.[Name],
	COUNT(*) as [JourneysCount]
	FROM Spaceports as s
	JOIN Journeys as j ON j.DestinationSpaceportId = s.Id
	JOIN Planets as p ON s.PlanetId = p.Id
	GROUP BY p.[Name]
	ORDER BY [JourneysCount] DESC, p.[Name] ASC


--Select Second Oldest Important Colonist 
--NOT WORKING
SELECT tc.JobDuringJourney,
	c.FirstName + ' ' + c.LastName as [FullName],
	RANK() OVER(PARTITION BY JobDuringJourney 
									ORDER BY DATEDIFF(YEAR, c.BirthDate, j.JourneyEnd) ASC) as [JobRank]
	FROM Colonists as c
	JOIN TravelCards as tc ON tc.ColonistId = c.Id
	JOIN Journeys as j ON tc.JourneyId = j.Id
	ORDER BY [JobRank] DESC

