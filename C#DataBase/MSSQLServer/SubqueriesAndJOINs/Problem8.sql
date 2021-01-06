SELECT e.EmployeeID,e.FirstName ,
	CASE 
		WHEN p.StartDate > '12.31.2004' THEN NULL --CHECK for 'NULL' with no ''
		ELSE p.Name 
		END AS 'ProjectName'
	FROM Employees as e
	LEFT JOIN EmployeesProjects as ep ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects as p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24