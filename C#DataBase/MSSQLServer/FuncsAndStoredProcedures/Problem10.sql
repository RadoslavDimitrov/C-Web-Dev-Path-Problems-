CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(18,4))
AS
	SELECT FirstName, LastName
		FROM AccountHolders as A
		JOIN Accounts as acc ON acc.AccountHolderId = a.Id
		GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @number
		ORDER BY FirstName, LastName	
GO


