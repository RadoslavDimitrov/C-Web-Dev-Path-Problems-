--EEE-Mails 

SELECT a.FirstName,
	a.LastName,
	FORMAT(a.BirthDate, 'MM-dd-yyyy') as [BirthDate],
	c.Name as [HomeTown],
	a.Email
	FROM Accounts as a
	JOIN Cities as c ON a.CityId = c.Id
	WHERE Email LIKE 'e%'
	ORDER BY c.Name ASC


--City Statistics 

SELECT c.Name,
	COUNT(*) as Hotels
	FROM Hotels as h
	JOIN Cities as c ON h.CityId = c.Id
	GROUP BY c.Name
	ORDER BY COUNT(*) DESC, c.Name ASC