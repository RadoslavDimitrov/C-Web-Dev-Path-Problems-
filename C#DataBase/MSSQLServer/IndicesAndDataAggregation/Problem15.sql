SELECT DepartmentID,
		AVG(IIF(DepartmentID = 1, Salary + 5000, Salary)) as AverageSalary
	FROM 
(SELECT *
	FROM Employees
	WHERE Salary > 30000 AND ManagerID != 42
	) AS FilteredQuery
	GROUP BY DepartmentID



/*
SELECT * INTO NewEmployeeTable
	FROM Employees
	WHERE Salary > 30000

DELETE 	
	FROM NewEmployeeTable
	WHERE ManagerID = 42

UPDATE NewEmployeeTable
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID,
		AVG(Salary) as [AverageSalary]
	FROM NewEmployeeTable
	GROUP BY DepartmentID
	*/

	

	