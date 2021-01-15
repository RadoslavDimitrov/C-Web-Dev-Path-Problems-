CREATE VIEW V_EmployeeNameJobTitle AS

SELECT FirstName + ' ' + ISNULL (MiddleName, '') + ' ' + LastName AS [Full Name],
			 JobTitle AS 'Job Title'
	FROM Employees

DROP VIEW V_EmployeeNameJobTitle
USE SoftUniCRUD

SELECT *
	FROM V_EmployeeNameJobTitle