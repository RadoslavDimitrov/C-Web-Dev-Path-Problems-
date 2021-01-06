SELECT COUNT(*) FROM
(SELECT c.CountryName
	FROM Countries as c
	FULL OUTER JOIN MountainsCountries as mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL
	) as CountriesWithoutMountains
	