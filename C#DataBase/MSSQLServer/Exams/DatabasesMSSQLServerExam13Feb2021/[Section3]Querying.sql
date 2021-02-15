--Problem 5 - Commits

SELECT Id,
	[Message],
	RepositoryId,
	ContributorId
	FROM Commits
	ORDER BY Id, [Message], RepositoryId, ContributorId

--Problem 6 - Front-end 

SELECT Id,
	[Name], 
	Size
	FROM Files
	WHERE Size > 1000 AND [Name] LIKE '%HTML'
	ORDER BY Size DESC, Id, [Name]

--Problem 7 -Issue Assignment 

SELECT I.Id,
	u.Username + ' : ' + i.Title as [IssueAssignee]
	FROM Issues as I
	JOIN Users as u ON I.AssigneeId = u.Id
	ORDER BY I.Id DESC, [IssueAssignee]

-- Problem 8 - Single Files 

SELECT Id,
	F.[Name],
	CONCAT(Size, 'KB') as [Size]
	FROM Files as F
	WHERE F.Id NOT IN (SELECT CASE
							WHEN ParentId IS NULL THEN 0
							ELSE ParentId
							END AS [query]
								FROM Files)
	ORDER BY F.Id, F.[Name], F.Size DESC

--Problem 9 -Commits in Repositories 

SELECT TOP(5) R.Id,
	R.[Name],
	COUNT(*) as [Commits]
	FROM Commits as C
	JOIN Repositories as R ON C.RepositoryId = R.Id
	JOIN RepositoriesContributors as RC ON R.Id = RC.RepositoryId
	GROUP BY R.Id, R.[Name]
	ORDER BY [Commits] DESC, R.Id, R.[Name]

--Problem 10 - Average Size 

SELECT U.Username,
	AVG(F.Size) as [Size]
	FROM Commits as C
	JOIN Users as U ON C.ContributorId = U.Id
	JOIN Files as F ON F.CommitId = C.Id
	GROUP BY U.Username
	ORDER BY [Size] DESC, U.Username

