CREATE PROC usp_DepositMoney(@accountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION
		
    BEGIN TRY
		IF(@MoneyAmount <= 0)
			BEGIN
				THROW 50010, 'Amount shound be positive.', 1;
			END

		IF(SELECT COUNT(*)
			FROM Accounts
			WHERE Id = @accountId) != 1
			BEGIN
				THROW 50011, 'Account does not exist.', 1;
			END
	END TRY
    BEGIN CATCH
    	PRINT ERROR_MESSAGE();
    END CATCH
	UPDATE Accounts 
		SET Balance += @MoneyAmount WHERE Accounts.Id = @accountId;

	COMMIT
GO

SELECT * FROM Accounts
EXEC usp_DepositMoney 1, 10
