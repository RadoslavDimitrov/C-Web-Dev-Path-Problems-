USE Geography

SELECT 
	p.PeakName,
	r.RiverName,
	LOWER(CONCAT(p.PeakName, SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1))) AS MIX
	FROM Peaks AS p
		JOIN Rivers AS r ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
		ORDER BY MIX
	
