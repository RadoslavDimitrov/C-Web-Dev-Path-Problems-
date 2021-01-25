--Customers with Countries 

CREATE VIEW v_UserWithCountries
AS
	SELECT c.FirstName + ' ' + c.LastName as [CustomerName],
			c.Age as [Age],
			c.Gender as [Gender],
			cou.[Name] as [CountryName]
		FROM Customers as c
		JOIN Countries as cou ON c.CountryId = cou.Id

SELECT TOP 5 * 

  FROM v_UserWithCountries 

 ORDER BY Age 


 --Delete Products 

 --DELETE FROM Products WHERE Id = 7 
 CREATE OR ALTER TRIGGER afterDelete ON [Products]
 INSTEAD OF DELETE
 AS
	DECLARE @deletedProduct INT = (SELECT Id
										FROM deleted)
	DELETE FROM ProductsIngredients
		WHERE ProductId = @deletedProduct

	DELETE FROM Feedbacks
		WHERE ProductId = @deletedProduct

	DELETE FROM Products
		WHERE Id = @deletedProduct
 GO

