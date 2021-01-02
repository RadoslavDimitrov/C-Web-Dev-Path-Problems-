CREATE DATABASE Movies
-- Problem 13
USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
	VALUES
	('Pesho'),
	('Pesho1'),
	('Pesho2'),
	('Pesho3'),
	('Pesho4')

INSERT INTO Genres(GenreName)
	VALUES
		('Action'),
		('Comedy'),
		('Drama'),
		('Horror'),
		('Sport')

INSERT INTO Categories(CategoryName)
	VALUES
		('Fantasy'),
		('Mystery'),
		('Romance'),
		('Thriller'),
		('Western')

INSERT INTO Movies(Title, DirectorId,CopyrightYear, [Length], GenreId, CategoryId)
	VALUES
		('Movie1', 5, '12.05.2000', '2:30:25', 1, 1),
		('Movie2', 1, '11.05.2000', '2:20:25', 2, 5),
		('Movie3', 2, '10.05.2000', '2:32:25', 3, 4),
		('Movie4', 3, '09.05.2000', '2:40:25', 5, 3),
		('Movie5', 4, '08.05.2000', '2:00:25', 4, 2)

