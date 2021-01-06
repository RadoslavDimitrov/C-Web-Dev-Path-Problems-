SELECT TOP(50) e.EmployeeID,
		e.FirstName + ' ' + e.LastName as 'EmployeeName',
		m.FirstName + ' ' + m.LastName as 'ManagerName',
		d.Name as 'DepartmentName'
	FROM Employees as e
	JOIN Employees as m ON e.ManagerID = m.EmployeeID
	JOIN Departments as d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID