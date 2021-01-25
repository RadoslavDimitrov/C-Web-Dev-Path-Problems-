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

SELECT (c.FirstName + ' ' + c.LastName) as [CustomerName],
	c.PhoneNumber as PhoneNumber,
	c.Gender as Gender
	FROM Customers as c
	LEFT JOIN [Feedbacks] as f ON f.CustomerId = c.Id
	WHERE f.CustomerId IS NULL
		ORDER BY c.Id 


--Customers by Criteria 


SELECT c.FirstName,
	c.Age,
	c.PhoneNumber
	FROM Customers as c
	JOIN Countries as cou ON c.CountryId = cou.Id
	WHERE (Age >= 21 AND c.FirstName LIKE '%an%') OR (c.PhoneNumber LIKE '%38' AND cou.[Name] NOT IN ('Greece'))
	ORDER BY c.FirstName ASC, c.Age DESC


--Middle Range Distributors 

SELECT 
	d.[Name] as [DistributorName],
	i.[Name] as [IngredientName],
	p.[Name] as [ProductName],
	AVG(f.Rate) as [AverageRate]
	FROM Products as p
	JOIN ProductsIngredients As [pi] ON [pi].ProductId = p.Id
	JOIN Ingredients as i ON [pi].IngredientId = i.Id
	JOIN Distributors as d ON d.Id = i.DistributorId
	JOIN Feedbacks as f ON f.ProductId = p.Id
	GROUP BY d.[Name], i.[Name], p.[Name]
	HAVING AVG(f.Rate) BETWEEN 5 AND 8
	ORDER BY d.[Name], i.[Name],p.[Name]