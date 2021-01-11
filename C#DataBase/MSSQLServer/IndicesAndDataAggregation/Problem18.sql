USE SoftUniCRUD

SELECT DepartmentID, FORMAT(Salary, 'F2') as ThirdHightestSalary
	FROM
		(SELECT DepartmentID,
			Salary,
			DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) as SalaryRank
			FROM Employees
			GROUP BY DepartmentID,Salary) as SalaryRankQuery
		WHERE SalaryRank = 3