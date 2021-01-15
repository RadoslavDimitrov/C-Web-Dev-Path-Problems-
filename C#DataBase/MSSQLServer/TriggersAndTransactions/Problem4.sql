CREATE OR ALTER PROC usp_WithdrawMoney(@accountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION
		
		IF(@MoneyAmount <= 0)
			BEGIN
				ROLLBACK;
				THROW 50010, 'Amount shound be positive.', 1;
			END

		IF(SELECT COUNT(*)
			FROM Accounts
			WHERE Id = @accountId) != 1
			BEGIN
				ROLLBACK;
				THROW 50011, 'Account does not exist.', 1;
			END
		
		IF(
			(
				(SELECT Balance 
			FROM Accounts as a
			WHERE a.Id = @accountId) - @MoneyAmount) < 0)
			BEGIN
				ROLLBACK;
				THROW 50012, 'Not enough money', 1;
			END

	UPDATE Accounts 
		SET Balance -= @MoneyAmount WHERE Accounts.Id = @accountId;

		COMMIT

GO

SELECT * FROM Accounts
EXEC usp_WithdrawMoney 1, 20