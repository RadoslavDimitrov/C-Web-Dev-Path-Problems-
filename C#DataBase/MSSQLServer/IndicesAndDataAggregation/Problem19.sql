SELECT TOP(10) emp.FirstName, emp.LastName, emp.DepartmentID
	FROM Employees as emp
	WHERE Salary >
		(	
			SELECT AVG(Salary) as ASalary
			FROM Employees as e
			WHERE e.DepartmentID = emp.DepartmentID
			GROUP BY DepartmentID)
	ORDER BY DepartmentID