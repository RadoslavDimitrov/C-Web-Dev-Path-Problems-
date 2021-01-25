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

--Country Representative 

--SELECT COUNT(i.Id),
--	c.[Name] as [CountryName],
--	d.[Name] as [DisributorName]
--	FROM Countries as c
--	JOIN Distributors as d ON d.CountryId = c.Id
--	JOIN Ingredients as i ON i.DistributorId = d.Id
--	GROUP BY d.[Name], c.[Name]
--	ORDER BY c.[Name],d.[Name]

SELECT rankQuery.[countryName],
	rankQuery.distributorName
	FROM
(SELECT c.[Name] as [countryName],
	d.[Name] as [distributorName],
	RANK() OVER (PARTITION BY c.Id ORDER BY COUNT(i.Id) DESC) as [rank]
	FROM Countries as c
	JOIN Distributors as d ON d.CountryId = c.Id
	LEFT JOIN Ingredients as i ON i.DistributorId = d.Id
	GROUP BY c.[Name], d.[Name], c.Id
	) as [rankQuery]
	WHERE rankQuery.rank = 1
	ORDER BY rankQuery.countryName, rankQuery.distributorName
	
SELECT *
	FROM Countries