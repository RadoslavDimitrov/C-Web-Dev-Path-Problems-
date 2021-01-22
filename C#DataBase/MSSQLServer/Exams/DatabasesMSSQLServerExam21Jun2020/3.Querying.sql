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

--Longest and Shortest Trips 

SELECT a.Id as AccountId,
		CONCAT(a.FirstName,' ',a.LastName) as [FullName],
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) as [LongestTrip],
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) as [ShortestTrip]
	FROM AccountsTrips as at
	JOIN Accounts as a ON at.AccountId = a.Id
	JOIN Trips as t ON at.TripId = t.Id
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
	GROUP BY a.Id, a.FirstName, a.LastName
	ORDER BY [LongestTrip] DESC, [ShortestTrip] ASC

-- Metropolis 

SELECT TOP(10) 
		c.Id,
		c.Name as [City],
		c.CountryCode as [Country],
		COUNT(*) as [Accounts]
	FROM Accounts as a
	JOIN Cities as c ON a.CityId = c.Id
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY COUNT(*) DESC


-- Romantic Getaways 

SELECT a.Id,
	a.Email,
	c.Name,
	COUNT(*) as [Trips]
	FROM Accounts as a
	JOIN AccountsTrips as at ON at.AccountId = a.Id
	JOIN Trips as t ON t.Id = at.TripId
	JOIN Rooms as r ON t.RoomId = r.Id
	JOIN Hotels as h ON r.HotelId = h.Id
	JOIN Cities as c ON a.CityId = c.Id
	WHERE a.CityId = h.CityId
	GROUP BY a.Id, a.Email, c.Name
	ORDER BY [Trips] DESC, a.Id ASC
	