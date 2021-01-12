CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryAmount NVARCHAR(10);

	IF(@salary < 30000)
		SET @salaryAmount = 'Low';
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
		SET @salaryAmount = 'Average';
	ELSE 
		SET @salaryAmount = 'High';
	RETURN @salaryAmount
END


