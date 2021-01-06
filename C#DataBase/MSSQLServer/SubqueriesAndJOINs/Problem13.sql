SELECT c.CountryCode,
	COUNT(m.MountainRange) as 'MountainRanges'
	FROM Countries as c
	JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains m ON m.Id = mc.MountainId
	WHERE c.CountryCode IN ('BG', 'RU', 'US')
	GROUP BY c.CountryCode
