CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(14,4))
AS
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @SenderId, @Amount

		EXEC usp_DepositMoney @ReceiverId, @Amount
	COMMIT
GO

EXEC usp_TransferMoney 5, 1, 5000

SElECT * FROM Accounts WHERE Accounts.Id IN (1,5)
SELECT * FROM Logs
SELECT * FROM NotificationEmails