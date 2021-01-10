SELECT TOP(5) Country,
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
		END AS [Highest Peak Name],
	CASE 
		WHEN Elevation IS NULL THEN '0'
		ELSE Elevation
		END AS [Highest Peak Elevation],
	CASE 
		WHEN Mountain IS NULL THEN '(no mountain)'
		ELSE Mountain
		END AS [Mountain]
	FROM
		(SELECT *,
			DENSE_RANK() OVER(PARTITION BY Country ORDER BY Elevation DESC)
				AS PeakRank
			FROM
				(SELECT CountryName as Country,
					p.PeakName,
					p.Elevation,
					m.MountainRange as Mountain
				FROM Countries as C
				LEFT JOIN MountainsCountries as MC ON MC.CountryCode = C.CountryCode
				LEFT JOIN Mountains as M ON MC.MountainId = M.Id
				LEFT JOIN Peaks as P ON p.MountainId = M.Id) AS Query)
					AS PeakQuery
		WHERE PeakRank = 1
		ORDER BY Country, [Highest Peak Name]