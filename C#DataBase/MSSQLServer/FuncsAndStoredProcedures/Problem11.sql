CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @interestRate FLOAT, @numOfYears FLOAT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @index INT = 1;

	WHILE(@index <= @numOfYears)
	BEGIN
		SET @sum += @sum * @interestRate;
		SET @index +=1;
	END

	RETURN @sum;
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)