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