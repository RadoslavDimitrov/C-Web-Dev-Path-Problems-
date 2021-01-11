USE SoftUniCRUD

SELECT DepartmentID,
	MAX(Salary) as [MaxSalary]
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000