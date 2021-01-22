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