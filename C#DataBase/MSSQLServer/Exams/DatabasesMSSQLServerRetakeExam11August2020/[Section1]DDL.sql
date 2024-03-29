CREATE DATABASE Bakery

USE Bakery

CREATE TABLE Countries
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25) NOT NULL,
	[LastName] NVARCHAR(25) NOT NULL,
	[Gender] CHAR(1) NOT NULL
		CHECK ([Gender] IN ('M', 'F')),
	[Age] INT NOT NULL
		CHECK ([Age] >= 0),
	[PhoneNumber] NCHAR(10) NOT NULL,
	[CountryId] INT REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250),
	[Recipe] NVARCHAR(MAX) NOT NULL,
	[Price] DECIMAL(15,2) NOT NULL
		CHECK([Price] > 0)
 
)

CREATE TABLE Feedbacks 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(250),
	[Rate] DECIMAL(5,2) NOT NULL
		CHECK ([Rate] BETWEEN 0 AND 10),
	[ProductId] INT REFERENCES Products(Id) NOT NULL,
	[CustomerId] INT REFERENCES Customers(Id) NOT NULL
)

CREATE TABLE Distributors
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[AddressText] NVARCHAR(30) NOT NULL,
	[Summary] NVARCHAR(200) NOT NULL,
	[CountryId] INT REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(200),
	[OriginCountryId] INT REFERENCES Countries(Id),
	[DistributorId] INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	[ProductId] INT REFERENCES Products(Id) NOT NULL,
	[IngredientId] INT REFERENCES Ingredients(Id) NOT NULL,
		PRIMARY KEY ([ProductId],[IngredientId])
)