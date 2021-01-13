CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
	SELECT acc.Id as [Account Id],
			ah.FirstName as [First Name],
			ah.LastName as [Last Name],
			acc.Balance as [Current Balance],
			dbo.ufn_CalculateFutureValue(acc.Balance,@interestRate, 5) as [Balance in 5 years]
		FROM Accounts as acc
		JOIN AccountHolders as ah ON acc.AccountHolderId = ah.Id
		WHERE acc.Id = @accountId

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1