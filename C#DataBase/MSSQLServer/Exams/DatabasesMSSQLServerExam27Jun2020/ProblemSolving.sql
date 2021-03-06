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


--9.	Past Expenses


SELECT j.JobId,
			SUM(p.Price)
			FROM Jobs as j
			JOIN PartsNeeded as pn ON j.JobId = pn.JobId
			JOIN Parts as p ON p.PartId = pn.PartId
			WHERE j.[Status] LIKE 'Finished'
			GROUP BY j.JobId
		ORDER BY SUM(p.Price) DESC, j.JobId ASC

--10.	Missing Parts
--NOT DONE
SELECT P.PartId, P.Description, PN.Quantity as [Requared], P.StockQty as [In Stock], OP.Quantity as [Ordered]
	FROM Jobs as J
	LEFT JOIN PartsNeeded as PN ON J.JobId = PN.JobId
	LEFT JOIN Parts as P ON P.PartId = PN.PartId
	LEFT JOIN OrderParts as OP ON OP.PartId = PN.PartId
	LEFT JOIN Orders as O ON O.JobId = J.JobId
	WHERE J.Status LIKE 'In Progress'
	AND O.Delivered = 0

	GROUP BY P.PartId, P.Description, PN.Quantity, P.StockQty, OP.Quantity

--SECTION 4 

--	11.	Place Order

CREATE PROC usp_PlaceOrder(@jobId INT, @partSerial NVARCHAR(50), @quantity INT)
AS

	IF(@quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1;

	IF(@jobId IN (SELECT JobId
							FROM Jobs
								WHERE Jobs.[Status] LIKE 'FINISHED'))
		THROW 50011, 'This job is not active!', 1;

	IF(@partSerial NOT IN (SELECt P.SerialNumber
							FROM Parts as P))
		THROW 50014, 'Part not found!', 1;

	IF(@jobId NOT IN (SELECT JobId	
							FROM Jobs))
		THROW 50013, 'Job not found!', 1;

	IF(@jobId IN (SELECT JobId 
						FROM Jobs) AND (SELECT IssueDate
												FROM Orders
												WHERE JobId = @jobId) IS NULL)
			BEGIN TRANSACTION
			DECLARE @partId INT = (SELECT PartId 
									FROM Parts as P
									WHERE P.SerialNumber = @partSerial);

			DECLARE @orderId INT = (SELECT OrderId
									FROM Orders as O
									WHERE O.JobId = @jobId AND IssueDate IS NULL);

			IF(@orderId IN (SELECT OrderId
									FROM Orders) AND
									@partId IN (SELECT O.PartId
													FROM OrderParts as O))
					BEGIN
						UPDATE OrderParts
						SET Quantity += @quantity
						WHERE OrderId = @orderId AND PartId = @partId
					END
			ELSE
					BEGIN
						INSERT INTO OrderParts(OrderId, PartId, Quantity)
						VALUES(@orderId, @partId, @quantity)
					END
	COMMIT
GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
    EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY
BEGIN CATCH
    SET @err_msg = ERROR_MESSAGE();
    SELECT @err_msg
END CATCH
--Part quantity must be more than zero!