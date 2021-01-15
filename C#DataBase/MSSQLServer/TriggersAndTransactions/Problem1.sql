CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)



--HomeWork part
CREATE TRIGGER tr_Account_Log ON Accounts AFTER UPDATE
AS

	INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT i.Id, d.Balance ,i.Balance
			FROM inserted as i
			JOIN deleted as d ON i.Id = d.Id
GO


