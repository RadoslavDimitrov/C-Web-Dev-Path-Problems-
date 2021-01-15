USE Diablo

--1

CREATE TRIGGER tr_RestrictionInsertHigherLevelItems ON UserGameItems
	INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO UserGameItems
		SELECT i.Id, ug.Id 
			FROM inserted
				JOIN UsersGames as Ug ON UserGameId = Ug.Id
				JOIN Items as i ON ItemId = Ug.Id
			WHERE Ug.Level >= i.MinLevel
END
GO

--2
				UPDATE UsersGames
SET Cash += 50000
FROM UsersGames as ug
		JOIN Games as g ON g.Id = ug.GameId
		JOIN Users as u ON u.Id = ug.UserId
		WHERE g.Name LIKE 'Bali'
			AND u.Username 
				IN ('baleremuda',
				'loosenoise',
				'inguinalself',
				'buildingdeltoid',
				'monoxidecos')

SELECT * FROM UsersGames

--3

CREATE OR ALTER PROC usp_BuyItems(@username NVARCHAR(MAX))
AS
	DECLARE @userId INT = 
		(SELECT u.Id FROM Users as u WHERE u.Username = @username)

	DECLARE @gameId INT = 
		(SELECT Id FROM Games as g where g.Name = 'Bali')

	DECLARE @userGameId INT = 
		(SELECT Id FROM UsersGames as ug
			WHERE ug.UserId = @userId 
				AND ug.GameId = @gameId)

	DECLARE @userLvl INT =
		(SELECT [Level] FROM UsersGames as ug
			WHERE ug.Id = @userGameId)

	DECLARE @counter INT = 251;

	WHILE(@counter <= 539)
		BEGIN
			
			DECLARE @itemId INT = @counter;
				
			DECLARE @itemPrice MONEY = 
				(SELECT Price FROM Items
					WHERE Items.Id = @itemId)
			
			DECLARE @itemMinLvl INT = 
				(SELECT MinLevel FROM Items
					WHERE Items.Id = @itemId)
			
			DECLARE @userGameMoney MONEY = 
				(SELECT Cash FROM UsersGames AS ug
					WHERE ug.Id = @userGameId)

			IF(@userGameMoney >= @itemPrice AND @userLvl >= @itemMinLvl)
			BEGIN
				UPDATE UsersGames
				SET Cash -= @itemPrice
				WHERE Id = @userGameId
				INSERT INTO UserGameItems
				VALUES(@itemId, @userGameId)
			END

			SET @counter += 1;

			IF(@counter =300)
			BEGIN
				SET @counter = 501;
			END
		END
GO

EXEC usp_BuyItems 'baleremuda'
EXEC usp_BuyItems 'loosenoise'
EXEC usp_BuyItems 'inguinalself'
EXEC usp_BuyItems 'buildingdeltoid'
EXEC usp_BuyItems 'monoxidecos'


--4

SELECT u2.Username AS Username,
       g.Name      AS Name,
       Cash,
       i.Name      AS [Item Name]
FROM UsersGames
         JOIN Users U2 ON U2.Id = UsersGames.UserId
         JOIN Games G ON G.Id = UsersGames.GameId
		 JOIN UserGameItems as UGI ON UGI.UserGameId = UsersGames.Id
         JOIN Items I ON I.Id = UGI.ItemId
WHERE G.Name = 'Bali'
ORDER BY Username, [Item Name]
GO