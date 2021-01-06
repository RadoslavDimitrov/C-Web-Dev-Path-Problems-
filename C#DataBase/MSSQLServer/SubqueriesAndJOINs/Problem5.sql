SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM EmployeesProjects as ep
	FULL OUTER JOIN Employees as e ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects as p ON p.ProjectID = ep.ProjectID
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID ASC
	
