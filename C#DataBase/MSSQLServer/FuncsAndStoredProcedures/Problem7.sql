CREATE FUNCTION ufn_IsWordComprised(@setOfLetters nvarchar(max), @word nvarchar(max))
RETURNS BIT
AS
BEGIN
	DECLARE @wordLength INT = LEN(@word);
	DECLARE @index INT = 1;

	WHILE(@index <= @wordLength)
	BEGIN
		DECLARE @currChar NCHAR = SUBSTRING(@word, @index, 1);
		IF(CHARINDEX(@currChar, @setOfLetters) = 0)
			RETURN 0

		SET @index += 1;
	END
	
	RETURN 1
END


SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia');
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves');
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob');
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy');