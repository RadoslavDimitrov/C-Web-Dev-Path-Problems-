USE Diablo

SELECT *
	FROM UsersGames


CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(max))
RETURNS TABLE
AS 
	RETURN
		SELECT SUM(Cash) as [SumCash]
			FROM
				(
					SELECT g.Name,
							ug.Cash,
						ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) as [RowRanking]
						FROM Games as g
						JOIN UsersGames as ug ON g.Id = ug.GameId
						WHERE g.Name = @gameName
				)
				as [RowQuery]
			WHERE [RowRanking] % 2 <> 0;

SELECT * FROM  dbo.ufn_CashInUsersGames('Love in a mist')
