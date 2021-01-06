SELECT TOP(1) 
		(SELECT AVG(Salary) FROM Employees as e WHERE e.DepartmentID = d.DepartmentID) 
		as 'MinAverageSalary'
	FROM Departments as d
	WHERE (SELECT COUNT(*) FROM Employees as e WHERE e.DepartmentID = d.DepartmentID) > 0
	ORDER BY MinAverageSalary

--SELECT TOP(1) AVG(Salary) as 'MinAverageSalary'
--	FROM Employees
--	GROUP BY DepartmentID
--	ORDER BY 'MinAverageSalary'