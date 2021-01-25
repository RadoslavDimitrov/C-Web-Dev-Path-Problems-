---Products by Price 

SELECT p.[Name],
	p.Price,
	p.Description
	FROM Products as p
	ORDER BY Price DESC, [Name] ASC


--Negative Feedback 

		--Filter only feedbacks which have rate below 5.0

SELECT f.ProductId,
	f.Rate,
	f.[Description],
	f.CustomerId,
	c.Age,
	c.Gender
	FROM [Feedbacks] as f
	JOIN Customers as c ON f.CustomerId = c.Id
	WHERE f.Rate < 5.0
	ORDER BY f.ProductId DESC, f.Rate ASC


--Customers without Feedback 

SELECT c.FirstName + ' ' + c.LastName as [CustomerName],
	c.PhoneNumber,
	c.Gender
	FROM Customers as c
	WHERE c.Id NOT IN (SELECT CustomerId
							FROM Feedbacks)
		ORDER BY c.Id ASC
