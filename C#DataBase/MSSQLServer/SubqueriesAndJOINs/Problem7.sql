SELECT e.EmployeeID,e.FirstName,p.Name AS 'ProjectName'
	FROM Employees as e
	LEFT JOIN EmployeesProjects as ep ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects as p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID ASC