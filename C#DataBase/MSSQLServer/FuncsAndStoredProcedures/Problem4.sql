CREATE OR ALTER PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(MAX))
AS
	SELECT FirstName, LastName
		FROM Employees as E
		JOIN Addresses as A ON A.AddressID = E.AddressID
		JOIN Towns as T ON T.TownID = A.TownID
		WHERE T.Name = @TownName
GO

