--Select all military journeys 

SELECT Id,
	FORMAT([JourneyStart],'dd/MM/yyyy') as [JourneyStart],
	FORMAT([JourneyEnd],'dd/MM/yyyy') as [JourneyStart]
	FROM Journeys as j
	WHERE Purpose IN ('Military')
	ORDER BY j.JourneyStart ASC