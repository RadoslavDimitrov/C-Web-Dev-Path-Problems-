CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName,LastName, Title, Notes)
	VALUES
		('Ivan', 'Ivanov', 'Receptionist',NULL),
		('Pesho', 'Peshov', 'Manager',NULL),
		('Cveta','Cvetkova', 'Maid', NULL)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	EmergencyName NVARCHAR(20) NOT NULL,
	EmergencyNumber NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber,Notes)
	VALUES
		('1','Stamat','Stamatov','7728594','kiko','321', NULL),
		('2','Stamat','Stamatov','7728594','kiko','321', NULL),
		('3','Stamat','Stamatov','7728594','kiko','321', NULL)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus, Notes)
	VALUES
		('FREE AND CLEAN', NULL),
		('FREE, NOT CLEAN', NULL),
		('OCCUPIED', NULL)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType, Notes)
	VALUES
		('Suit',NULL),
		('Family', NULL),
		('Single', NULL)

CREATE TABLE BedTypes(
	BedType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType, Notes)
	VALUES
		('OnePerson', NULL),
		('TwoPersons', NULL),
		('KingBed', NULL)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(5,2),
	RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
	VALUES
		('Suit','KingBed', 85,'OCCUPIED',NULL),
		('Family','TwoPersons', 65,'FREE, NOT CLEAN',NULL),
		('Single','OnePerson', 35,'FREE AND CLEAN',NULL)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(5,2) NOT NULL,
	TaxRate DECIMAL(3,2) NOT NULL,
	TaxAmount AS AmountCharged * TaxRate,
	PaymentTotal DECIMAL(5,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber,
FirstDateOccupied, LastDateOccupied,
AmountCharged, TaxRate,
PaymentTotal, Notes)
	VALUES
		('1','2020-05-20','1','2020-05-20','2020-05-25',220,0.2,
		260,NULL),
		('2','2020-05-20','2','2020-05-20','2020-05-25',220,0.2,
		260,NULL),
		('3','2020-05-20','3','2020-05-20','2020-05-25',220,0.2,
		260,NULL)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME2,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(4,2),
	PhoneCharge DECIMAL(4,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge,Notes)
	VALUES
		(1,'2020-05-20','1',1,25.5, 30, NULL),
		(2,'2020-05-20','2',2,25.5, 30, NULL),
		(3,'2020-05-20','3',3,25.5, 30, NULL)

-- END OF PROBLEM 15

-- PROBLEM 23 

UPDATE Payments
SET TaxRate += 0.03

SELECT TaxRate FROM Payments

-- PROBLEM 24

TRUNCATE TABLE Occupancies


