USE Geography

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries as c
	JOIN MountainsCountries as mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains as m ON mc.MountainId = m.Id
	JOIN Peaks as p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC