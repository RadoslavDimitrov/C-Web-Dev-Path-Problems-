SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries as c
	FULL OUTER JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
	FULL OUTER JOIN Rivers as r ON cr.RiverId = r.Id
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName ASC