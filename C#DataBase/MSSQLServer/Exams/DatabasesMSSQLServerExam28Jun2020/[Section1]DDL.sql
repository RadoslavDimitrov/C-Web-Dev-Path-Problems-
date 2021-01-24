CREATE DATABASE ColonialJourney

USE ColonialJourney

CREATE TABLE Planets
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PlanetId] INT NOT NULL,
	
	CONSTRAINT FK_Spaceports_Planets
		FOREIGN KEY ([PlanetId]) 
			REFERENCES [Planets](Id)
)

CREATE TABLE Spaceships
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL,
	[LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE Colonists
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[Ucn] VARCHAR(10) NOT NULL UNIQUE,
	[BirthDate] DATE NOT NULL
)

CREATE TABLE Journeys
(
	[Id] INT PRIMARY KEY IDENTITY,
	[JourneyStart] DATETIME NOT NULL,
	[JourneyEnd] DATETIME NOT NULL,
	[Purpose] VARCHAR(11)
		CHECK ([Purpose] IN ('Medical', 'Technical', 'Educational', 'Military')),
	[DestinationSpaceportId] INT NOT NULL,
	[SpaceshipId] INT NOT NULL,

	CONSTRAINT FK_Journeys_Spaceports
		FOREIGN KEY ([DestinationSpaceportId])
			REFERENCES [Spaceports](Id),

	CONSTRAINT FK_Journeys_Spaceships
		FOREIGN KEY ([SpaceshipId])
			REFERENCES [Spaceships](Id)
)

CREATE TABLE TravelCards
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CardNumber] CHAR(10) NOT NULL UNIQUE,
	[JobDuringJourney] VARCHAR(8)
		CHECK ([JobDuringJourney] IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook' )),
	[ColonistId] INT NOT NULL,
	[JourneyId] INT NOT NULL,

	CONSTRAINT FK_TravelCards_Colonists
		FOREIGN KEY ([ColonistId])
			REFERENCES [Colonists](Id),

	CONSTRAINT FK_TravelCards_Journeys
		FOREIGN KEY ([JourneyId])
			REFERENCES [Journeys](Id)
)
