CREATE OR ALTER PROC usp_GetTownsStartingWith(@Param NVARCHAR(MAX))
AS
	SELECT [Name] as [Town]
		FROM Towns
		WHERE [Name] LIKE @Param + '%'
GO
