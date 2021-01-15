CREATE TABLE NotificationEmails
(
	Id INT IDENTITY PRIMARY KEY,
	--AccountId
	Recipient INT REFERENCES Accounts(Id),
	[Subject] NVARCHAR(MAX) NOT NULL,
	Body NVARCHAR(MAx) NOT NULL
)

CREATE OR ALTER TRIGGER tr_AddEmailNotificationOnAccountsInsert ON Logs AFTER INSERT
AS
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT i.AccountId, 
		'Balance change for account: ' + CAST(i.AccountId as nvarchar(max)),
		'On ' + CONVERT(NVARCHAR(max), GETDATE(), 100) + ' your balance was changed from ' + CAST(i.OldSum as nvarchar(max)) + ' to ' + CAST(i.NewSum as nvarchar(max))'.'
		FROM inserted as i

GO


UPDATE Accounts SET Balance -= 20000 WHERE Accounts.Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails