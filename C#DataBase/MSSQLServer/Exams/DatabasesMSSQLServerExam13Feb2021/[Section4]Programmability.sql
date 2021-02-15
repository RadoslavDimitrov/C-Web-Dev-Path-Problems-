-- Problem 11 -All User Commits 

CREATE OR ALTER FUNCTION udf_AllUserCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
	IF(@username NOT IN (SELECT Username
						FROM Users))
		RETURN 0;

	IF((SELECT TOP(1) c.Id
			FROM Users AS u
			LEFT JOIN Commits as c ON c.ContributorId = u.Id
			where Username = @username) IS NULL)
		RETURN 0;
								
	RETURN (SELECT COUNT(*) as [Count]
		FROM Commits as C
		LEFT JOIN Issues AS I ON C.IssueId = I.Id
		LEFT JOIN Users as U ON C.ContributorId = U.id	
		WHERE U.Username = @username
		GROUP BY U.Username);
END

SELECT dbo.udf_AllUserCommits('gosho')  

SELECT *,
	dbo.udf_AllUserCommits(Username) 
	FROM Users


-- Problem 12 - Search for Files

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
	SELECT Id,
		[Name],
		CONCAT(Size, 'KB') as [Size]
		FROM Files
		WHERE [Name] LIKE '%' + @fileExtension
END

EXEC usp_SearchForFiles 'txt' 