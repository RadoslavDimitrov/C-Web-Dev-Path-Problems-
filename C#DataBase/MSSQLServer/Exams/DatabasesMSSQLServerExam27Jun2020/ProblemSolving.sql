CREATE DATABASE WMS

--Part 1
CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone VARCHAR(12) CHECK (LEN(Phone) = 12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE 
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) CHECK ([Status] IN ('Pending','In Progress','Finished'))
		DEFAULT 'Pending',
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT NOT NULL DEFAULT 0,
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	[Description] VARCHAR(255),
	Price DECIMAL(6,2) CHECK (Price > 0) NOT NULL,
	VendorId INT REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL REFERENCES Orders(OrderId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1
		PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1
		PRIMARY KEY(JobId, PartId)
)

SELECT * FROM PartsNeeded
--BACKUP DATABASE WMS TO DISK = 'C:\BackUpsz'

--Part 2
 INSERT INTO Clients(FirstName, LastName , Phone)
	VALUES ('Teri', 'Ennaco', '570-889-5187'),
		   ('Merlyn', 'Lawler', '201-588-7810'),
		   ('Georgene', 'Montezuma', '925-615-5185'),
		   ('Jettie', 'Mconnell', '908-802-3564'),
		   ('Lemuel', 'Latzke', '631-748-6479'),
		   ('Melodie', 'Knipp', '805-690-1682'),
		   ('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId)
	VALUES ('WP8182119', 'Door Boot Seal', 117.86, 2),
       ('W10780048', 'Suspension Rod', 42.81, 1),
       ('W10841140', 'Silicone Adhesive ', 6.77, 4),
       ('WPY055980', 'High Temperature Adhesive', 13.94, 3)
 --3
 --UPDATE
 SELECT MechanicId 
	FROM Mechanics WHERE Mechanics.FirstName LIKE 'Ryan' -- id 3

SELECT COUNT(*)
FROM Jobs
WHERE Status LIKE 'Pending'

UPDATE Jobs
	SET MechanicId = 3, [Status] = 'In Progress'
	WHERE Status LIKE 'Pending'

--4
--DELETE
DELETE FROM OrderParts WHERE OrderId = 19
DELETE FROM Orders WHERE OrderId = 19

--5

SELECT FirstName + ' ' + LastName as [Mechanic],
		j.Status as [Status],
		IssueDate
	FROM Mechanics as m
	JOIN Jobs as j ON j.MechanicId = m.MechanicId
	ORDER BY m.MechanicId, IssueDate, JobId

--6.	Current Clients

SELECT c.FirstName + ' ' + c.LastName as [Client],
		DATEDIFF(DAY, j.IssueDate, '04-24-2017') as [Days going],
		j.Status as [Status]
	FROM Clients as c
	JOIN Jobs as j ON j.ClientId = c.ClientId
	WHERE j.Status NOT LIKE 'Finished'
	ORDER BY [Days going] DESC, c.ClientId ASC

--7. Mechanic Performance

SELECT CONCAT_WS(' ', m.FirstName, m.LastName) as [Mechanic],
	AVG(DATEDIFF(DAY, IssueDate, FinishDate)) as [Diff]
	FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	GROUP BY m.FirstName, m.LastName,m.MechanicId
	ORDER BY m.MechanicId ASC

--8.	Available Mechanics

SELECT mAv.Available
	FROM
		(SELECT m.FirstName + ' ' + m.LastName as [Available],
			j.MechanicId
			FROM Mechanics as m
			LEFT JOIN Jobs as j ON m.MechanicId = j.MechanicId
			WHERE j.[Status] LIKE 'Finished'
			GROUP BY m.FirstName, m.LastName, j.MechanicId) AS [mAv]
		ORDER BY mAv.MechanicId ASC
