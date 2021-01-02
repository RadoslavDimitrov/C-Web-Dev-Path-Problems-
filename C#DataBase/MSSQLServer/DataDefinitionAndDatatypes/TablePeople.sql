USE Minions

--Problem 7 START
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2048 * 1024),
	Height DECIMAL(18,2),
	[Weight] DECIMAL(18,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)


INSERT INTO People([Name], Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Pesho1', '180', '80', 'm', '08.15.2000', 'Hello'),
('Pesho2', '180', '80', 'm', '08.15.2000', 'Hello'),
('Pesho3', '180', '80', 'm', '08.15.2000', 'Hello'),
('Pesho4', '180', '80', 'f', '08.15.2000', 'Hello'),
('Pesho5', '180', '80', 'f', '08.15.2000', 'Hello')

--END
SELECT * FROM People