CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel NVARCHAR(10))
AS
	SELECT FirstName,
		LastName
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
GO

EXEC usp_EmployeesBySalaryLevel 'Average'