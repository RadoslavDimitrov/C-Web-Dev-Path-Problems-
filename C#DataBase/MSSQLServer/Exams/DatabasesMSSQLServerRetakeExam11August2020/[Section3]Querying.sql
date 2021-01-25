---Products by Price 

SELECT p.[Name],
	p.Price,
	p.Description
	FROM Products as p
	ORDER BY Price DESC, [Name] ASC